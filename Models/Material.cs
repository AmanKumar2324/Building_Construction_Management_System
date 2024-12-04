using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        //public Project Project { get; set; }

        [Required]
        [MaxLength(255)]
        public string MaterialName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("Vendor")]
        public int? SupplierId { get; set; }

        //public Vendor Supplier { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }
    }
}
