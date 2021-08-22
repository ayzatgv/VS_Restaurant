using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Restaurant.Models.ViewModels
{
    public class EditSelfUserViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "لطفا نام خود را وارد نمایید")]
        [DisplayName("نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد نمایید")]
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد نمایید")]
        [DisplayName("نام کاربری")]
        public string Username { get; set; }


        [EmailAddress(ErrorMessage = "لطفاایمیل را به شکل صحیح وارد نمایید")]
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد نمایید")]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا شماره تلفن همراه خود را وارد نمایید")]
        [DisplayName("شماره تلفن همراه")]
        public string Phone { get; set; }

        public EditSelfUserViewModel()
        {

        }

        public EditSelfUserViewModel(User oldUser)
        {
            this.ID = oldUser.ID;
            this.FirstName = oldUser.FirstName;
            this.LastName = oldUser.LastName;
            this.Username = oldUser.Username;
            this.Email = oldUser.Email;
            this.Phone = oldUser.Phone;
        }



        public User ConvertToModel()
        {
            User user = new User();

            if (this.ID != 0)
                user.ID = this.ID;
            if (!string.IsNullOrEmpty(this.FirstName))
                user.FirstName = this.FirstName;
            if (!string.IsNullOrEmpty(this.LastName))
                user.LastName = this.LastName;
            if (!string.IsNullOrEmpty(this.Username))
                user.Username = this.Username;
            if (!string.IsNullOrEmpty(this.Email))
                user.Email = user.Username = this.Email;
            if (!string.IsNullOrEmpty(this.Phone))
                user.Phone = this.Phone;

            return user;
        }

    }
}