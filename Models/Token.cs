using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Token")]
    public class Token: BaseModel
    {
        
        public User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        [MaxLength(500)]
        public string Code { get; set; }
    }
}
