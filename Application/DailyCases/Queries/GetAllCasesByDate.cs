using Application.Contracts;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DailyCases.Queries
{
    public class GetAllCasesByDate
    {
        public class Query : IRequest<List<AllCasesByDayDTO>>
        {
            public DateTime Date { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<AllCasesByDayDTO>>
        {
            private readonly IDailyCasesRepository _repository;

            public Handler(IDailyCasesRepository repository)
            {
                _repository = repository;
            }
            public async Task<List<AllCasesByDayDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAllCasesByDay(request.Date);
            }
        }
    }
}
