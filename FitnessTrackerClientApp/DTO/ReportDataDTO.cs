using System;
using System.Collections.Generic;

namespace FitnessTrackerClientApp.DTO
{
    [Serializable]
    public class ReportDataDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal AverageWeight { get; set; }

        public decimal TotolCaloriesBurned { get; set; }
        public decimal TotalCaloriesGained { get; set; }
        public List<ReportItemDataDTO> ReportItemData { get; set; }

    }
}
