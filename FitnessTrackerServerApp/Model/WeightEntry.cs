using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackerApp.Model
{
    [Table("WeightEntry")]
    public class WeightEntry
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal Weight { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? WeightEntryId { get; set; }
    }
}
