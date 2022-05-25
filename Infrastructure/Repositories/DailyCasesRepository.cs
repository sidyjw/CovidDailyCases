using Application.Contracts;
using Application.DailyCases.DTOs;
using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DailyCasesRepository : IDailyCasesRepository
    {
        private readonly DailyCasesReportContext _context;

        public DailyCasesRepository(DailyCasesReportContext context)
        {
            _context = context;
        }
        public async Task<List<DateTime>> AvailableDatesAsync()
        {
            return await _context.DailyCasesReports
                .AsNoTracking()
                .Select(x => x.Date)
                .Distinct()
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<DailyCasesReport>> GetAllCasesAmountByDateAsync(DateTime start, DateTime end)
        {
            return await _context.DailyCasesReports
                           .AsNoTracking()
                           .Where(cases => cases.Date >= start && cases.Date <= end)
                           .ToListAsync();
        }

        public async Task<List<DailyCasesReport>> GetAllCasesByDayAsync(DateTime date)
        {
            return await _context.DailyCasesReports
                            .AsNoTracking()
                            .Where(cases => cases.Date == date)
                            .ToListAsync();
        }
    }
}
