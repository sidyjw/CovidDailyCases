﻿using Application.Contracts;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DailyCases.Queries
{
    public class GetAllCasesAmountByDate
    {
        public class Query : IRequest<List<AllCasesAmountByDateDTO>>
        {
            public string Date { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Date).Must(BeAValidDateIntervalStringPattern)
                    .WithMessage("Invalid date interval string pattern.");
            }

            private bool BeAValidDateIntervalStringPattern(string dateStringPattern)
            {
                if (!dateStringPattern.Contains('~')) return false;
                var datesInterval = dateStringPattern.Split(new[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                
                var result = true;
                try
                {
                    foreach (var date in datesInterval) DateTime.Parse(date);
                } catch 
                { 
                    result = false; 
                }
                
                return result;
            }
        }

        public class Handler : IRequestHandler<Query, List<AllCasesAmountByDateDTO>>
        {
            private readonly IDailyCasesRepository _repository;
            private readonly IValidator<Query> _validator;

            public Handler(IDailyCasesRepository repository, IValidator<Query> validator)
            {
                _repository = repository;
                _validator = validator;
            }
            public async Task<List<AllCasesAmountByDateDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync(request);
                
                if (validationResult.IsValid)
                {
                    var datesIntervals = request.Date.Split('~');
                    return await _repository.GetAllCasesAmountByDateAsync(DateTime.Parse(datesIntervals[0]), DateTime.Parse(datesIntervals[1]));
                }

               return new List<AllCasesAmountByDateDTO>();
            }
        }
    }
}
