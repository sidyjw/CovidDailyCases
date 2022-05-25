using Application.Contracts;
using Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DailyCases.Queries
{
    public class Dates
    {
        public class Query : IRequest<Result<List<DateTime>>> { }

        public class Handler : IRequestHandler<Query, Result<List<DateTime>>>
        {
            private readonly IDailyCasesRepository _repository;

            public Handler(IDailyCasesRepository repository)
            {
                _repository = repository;
            }
            public async Task<Result<List<DateTime>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _repository.AvailableDatesAsync();
                return Result<List<DateTime>>.Success(result);
            }
        }
    }
}
