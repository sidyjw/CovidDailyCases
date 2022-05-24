using Application.DailyCases.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IDailyCasesRepository
    {
       public Task<List<AvailableDatesDTO>> AvailableDatesAsync();

    }
}
