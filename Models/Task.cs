using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        //public Project Project { get; set; }

        [Required]
        [MaxLength(255)]
        public string TaskName { get; set; }

        [ForeignKey("User")]
        public string? AssignedTo { get; set; }

        //public User AssignedUser { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(50)]
        public string Priority { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }
    }
}
