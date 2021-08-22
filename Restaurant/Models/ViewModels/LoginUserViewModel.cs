using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد نمایید")]
        [DisplayName("نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد نمایید")]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }
    }
}