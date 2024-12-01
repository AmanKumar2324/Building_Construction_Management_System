using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Column(TypeName = "decimal(18,2")]
        public decimal Budget { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        [ForeignKey("User")]
        public int ProjectManagerId { get; set; }

        public User ProjectManager { get; set; }
    }
}
