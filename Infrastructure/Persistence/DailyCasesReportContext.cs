﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DailyCasesReportContext : DbContext
    {
        public DbSet<DailyCasesReport> DailyCasesReports { get; set; }

        public DailyCasesReportContext(DbContextOptions<DailyCasesReportContext> options) : base(options)
        {
        }
    }
}
