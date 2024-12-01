using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    public class SafetyInspection
    {
        [Key]
        public int InspectionId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        [ForeignKey("User")]
        public int SupervisorId { get; set; }

        public User Supervisor { get; set; }

        [Required]
        public DateTime InspectionDate { get; set; }

        public string Findings { get; set; }

        public string CorrectiveAction { get; set; }
    }
}
