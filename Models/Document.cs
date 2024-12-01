using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Construction_Management_System.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        [MaxLength(50)]
        public string DocumentType { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UploadedBy { get; set; }

        public User UploadedUser { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [MaxLength(10)]
        public string VersionNumber { get; set; }
    }
}
