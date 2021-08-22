using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models.ViewModels
{
    public class InsertUserViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "لطفا نام خود را وارد نمایید")]
        [DisplayName("نام")]
        public string FiresName { get; set; }

        [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد نمایید")]
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "لطفاایمیل را به شکل صحیح وارد نمایید")]
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد نمایید")]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [StringLength(11)]
        //[MaxLength(11,ErrorMessage = "شماره تلفن همراه باید 11 رقمی باشد")]
        //[MinLength(11, ErrorMessage = "شماره تلفن همراه باید 11 رقمی باشد")]
        [Required(ErrorMessage = "لطفا شماره تلفن همراه خود را وارد نمایید")]
        [DisplayName("شماره تلفن همراه")]
        public string Phone { get; set; }

        public User ConvertToModel()
        {
            User user = new User();

            if (this.ID != 0)
                user.ID = this.ID;
            if (!string.IsNullOrEmpty(this.FiresName))
                user.FirstName = this.FiresName;
            if (!string.IsNullOrEmpty(this.LastName))
                user.LastName = this.LastName;
            if (!string.IsNullOrEmpty(this.Email))
                user.Email = user.Username = this.Email;
            if (!string.IsNullOrEmpty(this.Phone))
                user.Phone = user.Password = this.Phone;

            return user;
        }
    }
}