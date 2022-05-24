﻿using Application.DailyCases.Queries;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDailyCasesRepository
    {
        public Task<List<DateTime>> AvailableDatesAsync();
        public Task<List<AllCasesByDayDTO>> GetAllCasesByDay(DateTime date);
    }
}