using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UserLoginView
    {
        [Required(ErrorMessage = "UserName Required")]
        [MaxLength(20, ErrorMessage = "Should Be At Most 10 Characters")]
        [MinLength(6, ErrorMessage = "Should Be At Less 6 Chars")]
        [EmailAddress(ErrorMessage = "Not Valid Email")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [MaxLength(20, ErrorMessage = "Should Be At Most 10 Characters")]
        [MinLength(6, ErrorMessage = "Should Be At Less 6 Chars")]
        public string Password { get; set; }
    }
}
