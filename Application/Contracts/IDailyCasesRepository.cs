using Application.DailyCases.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDailyCasesRepository
    {
        public Task<List<DateTime>> AvailableDatesAsync();
        public Task<List<AllCasesByDayDTO>> GetAllCasesByDayAsync(DateTime date);
        public Task<List<AllCasesAmountByDateDTO>> GetAllCasesAmountByDateAsync(DateTime start, DateTime end);
    }
}
