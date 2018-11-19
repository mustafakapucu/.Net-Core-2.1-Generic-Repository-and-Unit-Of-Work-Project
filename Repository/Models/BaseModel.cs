using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class BaseModel
    {
        [Required]
        public System.DateTime CreatedDate { get; set; }
    }
}