using System.ComponentModel.DataAnnotations;

namespace Building_Construction_Management_System.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string ContactDetails { get; set; }

        public string MaterialSupplied { get; set; }

        public string ContractTerms { get; set; }

        [MaxLength(50)]
        public string DeliveryStatus { get; set; }
    }
}
