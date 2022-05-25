using System.Collections.Generic;

namespace Application.DailyCases.DTOs
{
    public class AllCasesAmountByDateDTO
    {
        public string Location { get; set; }
        public List<VariantItem> VariantItems { get; set; }
    }

    public class VariantItem
    {
        public string Name { get; set; }
        public string Amount { get; set; }
    }

}
