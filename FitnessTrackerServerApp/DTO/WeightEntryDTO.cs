using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerServerApp.DTO
{
    public class WeightEntryDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public string? UserName { get; set; }
        public Guid? WeightEntryId { get; set; }
    }
}
