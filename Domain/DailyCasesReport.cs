using System;

namespace Domain
{
    public class DailyCasesReport
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Variant { get; set; }
        public int NumSequences { get; set; }
        public double PercSequences { get; set; }
        public int NumSequencesTotal { get; set; }
    }
    
}
