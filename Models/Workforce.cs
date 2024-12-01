using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    public class Workforce
    {
        [Key]
        public int WorkerId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [ForeignKey("Task")]
        public int? TaskId { get; set; }

        public Task Task { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        [MaxLength(50)]
        public string AttendanceStatus { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal? PerformanceRating { get; set; }
    }
}
