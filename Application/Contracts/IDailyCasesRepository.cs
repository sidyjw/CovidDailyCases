using Application.DailyCases.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDailyCasesRepository
    {
        public Task<List<DateTime>> AvailableDatesAsync();
        public Task<List<DailyCasesReport>> GetAllCasesByDayAsync(DateTime date);
        public Task<List<DailyCasesReport>> GetAllCasesAmountByDateAsync(DateTime start, DateTime end);
    }
}
