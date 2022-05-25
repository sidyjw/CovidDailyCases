using Application.Contracts;
using Application.Core;
using Application.DailyCases.DTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DailyCases.Queries
{
    public class GetAllCasesByDate
    {
        public class Query : IRequest<Result<List<AllCasesByDayDTO>>>
        {
            public DateTime Date { get; set; }
        }
        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Date).NotEmpty().WithMessage("Please, select a date.");
            }
        }
            public class Handler : IRequestHandler<Query, Result<List<AllCasesByDayDTO>>>
        {
            private readonly IDailyCasesRepository _repository;
            private readonly IValidator<Query> _validator;

            public Handler(IDailyCasesRepository repository, IValidator<Query> validator)
            {
                _repository = repository;
                _validator = validator;
            }
            public async Task<Result<List<AllCasesByDayDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    return Result<List<AllCasesByDayDTO>>.Failure(validationResult.Errors.FirstOrDefault().ErrorMessage);
                }
                
                var result = await _repository.GetAllCasesByDayAsync(request.Date);

                return Result<List<AllCasesByDayDTO>>.Success(result);
            }
        }
    }
}
