using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class DailyCasesReportSeed
    {
        public static async Task SeedCsv(DailyCasesReportContext context)
        {
            if (!context.DailyCasesReports.Any())
            {
                using var reader = new StreamReader(GetCsvRelativePath());

                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<DailyCasesCsvConfig>().ToList();
                    foreach (var record in records)
                    {
                        context.DailyCasesReports.Add(new DailyCasesReport
                        {
                            Location = record.Location,
                            Date = record.Date,
                            NumSequences = record.NumSequences,
                            PercSequences = record.PercSequences,
                            NumSequencesTotal = record.NumSequencesTotal,
                            Variant = record.Variant
                        }); ;

                    }

                    var result =  await context.SaveChangesAsync();
                }

            }
        }

        private static string GetCsvRelativePath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var csvFile = Path.Combine(currentDirectory, @"../assets/covid-variants.csv");
            var filePath = csvFile.Replace('/', Path.DirectorySeparatorChar);
            return Path.GetFullPath(filePath);
        }

        private class DailyCasesCsvConfig
        {
            [Name("location")]
            public string Location { get; set; }
            
            [Name("date")]
            public DateTime Date { get; set; }
            
            [Name("variant")]
            public string Variant { get; set; }

            [Name("num_sequences")]
            public int NumSequences { get; set; }

            [Name("perc_sequences")]
            public double PercSequences { get; set; }

            [Name("num_sequences_total")]
            public int NumSequencesTotal { get; set; }
        }
    }

   
}
