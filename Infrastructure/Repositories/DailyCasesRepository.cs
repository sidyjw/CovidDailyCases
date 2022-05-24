using Application.DailyCases;
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
        public async Task<List<AvailableDatesDTO>> AvailableDatesAsync()
        {
            return await _context.DailyCasesReports
                .Distinct()
                .AsNoTracking()
                .ProjectTo<AvailableDatesDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
