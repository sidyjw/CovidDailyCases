using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyCases.DTOs
{
    public class AllCasesByDayDTO
    {
        public string Location { get; set; }
        public List<string> Variant { get; set;}
    }
}
