using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
    }

    public static class UserViewModelExtensions
    {
        public static UserViewModel ToViewModel(this User User)
        {
            return new UserViewModel()
            {
                ID = User.ID,
                UserName = User.UserName,
                Address = User.Address,
                Mobile = User.Mobile,
                Code = User.Tokens?.FirstOrDefault()?.Code
            };
        }
    }
}
