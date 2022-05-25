using Application.Contracts;
using Application.DailyCases;
using Application.DailyCases.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;

        public DailyCasesRepository(DailyCasesReportContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<List<AllCasesAmountByDateDTO>> GetAllCasesAmountByDateAsync(DateTime start, DateTime end)
        {
            var query = from cases in await _context.Set<DailyCasesReport>()
                       .AsNoTracking()
                       .Where(cases => cases.Date >= start && cases.Date <= end)
                       .ToListAsync()
                       group cases by cases.Location
                       into casesGroup
                       select new AllCasesAmountByDateDTO { 
                            Location = casesGroup.Key, 
                            VariantItems = casesGroup.GroupBy(c => c.Variant)
                                                        .Select(v => new VariantItem { 
                                                            Name = v.Key, 
                                                            Amount = v.Sum(a => a.NumSequences).ToString()})
                                                        .ToList()
                        };
            return query.ToList();
        }

        public async Task<List<AllCasesByDayDTO>> GetAllCasesByDayAsync(DateTime date)
        {
            var query = from cases in await _context.Set<DailyCasesReport>()
                        .AsNoTracking()
                        .Where(cases => cases.Date == date )
                        .ToListAsync()
                        group cases by cases.Location
                        into casesGroup
                        select new AllCasesByDayDTO { Location = casesGroup.Key, Variant = casesGroup.Select(c => c.Variant).Distinct().ToList() };
            return query.ToList();
        }
    }
}
