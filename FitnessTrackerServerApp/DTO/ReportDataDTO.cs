using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerServerApp.DTO
{
    [Serializable]

    public class ReportDataDTO
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public decimal AverageWeight { get; set; }

        public decimal TotolCaloriesBurned { get; set; }
        public decimal TotalCaloriesGained { get; set; }
        public List<ReportItemDataDTO>? ReportItemData { get; set; }

    }
}
