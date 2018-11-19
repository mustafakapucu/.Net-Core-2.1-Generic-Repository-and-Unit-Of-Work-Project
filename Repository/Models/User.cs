using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    [Table("User")]
    public class User : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }
        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        [StringLength(100)]
        [Required]
        public string Password { get; set; }
    }
}