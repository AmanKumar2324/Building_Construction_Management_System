using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        [MaxLength(50)]
        public string ReportType { get; set; }

        [Required]
        public DateTime GeneratedDate { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        [ForeignKey("User")]
        public int CreatedBy { get; set; }

        public User Creator { get; set; }
    }
}
