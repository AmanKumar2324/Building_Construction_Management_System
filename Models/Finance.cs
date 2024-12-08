using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    public class Finance
    {
        [Key]
        public int FinanceId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        //public Project Project { get; set; }

        [Required]
        [MaxLength(50)]
        public string ExpenseType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(50)]
        public string PaymentStatus { get; set; }
    }
}
