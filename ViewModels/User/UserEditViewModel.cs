using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace ViewModels
{
    public class UserEditViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "UserName Required")]
        [MaxLength(20, ErrorMessage = "Should Be At Most 10 Characters")]
        [MinLength(6, ErrorMessage = "Should Be At Less 6 Chars")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MaxLength(20, ErrorMessage = "Should Be At Most 10 Characters")]
        [MinLength(6, ErrorMessage = "Should Be At Less 6 Chars")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile Required")]
        [MaxLength(15)]
        public string Mobile { get; set; }
    }

    public static class UserEditViewModelExtensions
    {
        public static User ToModel(this UserEditViewModel model)
        {
            return new User()
            {
                ID = model.ID,
                UserName = model.UserName,
                Password = model.Password,
                Mobile = model.Mobile,
                Address = model.Address
            };
        }

        public static UserEditViewModel ToEditableModel(this User model)
        {
            return new UserEditViewModel()
            {
                ID = model.ID,
                UserName = model.UserName,
                Password = model.Password,
                Mobile = model.Mobile,
                Address = model.Address
            };
        }


    }
}
