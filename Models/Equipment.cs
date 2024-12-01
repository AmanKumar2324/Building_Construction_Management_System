using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        [MaxLength(255)]
        public string EquipmentName { get; set; }

        [MaxLength(50)]
        public string Condition { get; set; }

        public DateTime? MaintenanceSchedule { get; set; }

        public string UsageLogs { get; set; }
    }
}
