using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("User")]
    public class User : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required]
        [MaxLength(15)]
        public string Mobile { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
