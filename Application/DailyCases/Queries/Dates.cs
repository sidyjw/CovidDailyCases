using Application.Contracts;
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
        public class Query : IRequest<List<DateTime>> { }

        public class Handler : IRequestHandler<Query, List<DateTime>>
        {
            private readonly IDailyCasesRepository _repository;

            public Handler(IDailyCasesRepository repository)
            {
                _repository = repository;
            }
            public async Task<List<DateTime>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.AvailableDatesAsync();
            }
        }
    }
}
