using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models.ViewModels
{
    public class BasketViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "لطفا ای دی خود را وارد نمایید")]
        [DisplayName("ای دی کاربر")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "لطفا ای دی غذا خود را وارد نمایید")]
        [DisplayName("ای دی غذا")]
        public int FoodID { get; set; }

        public Basket ConvertToModel()
        {
            Basket basket = new Basket();

            if (this.ID != 0)
                basket.ID = this.ID;
            if (this.UserID != 0)
                basket.User.ID = this.ID;
            if (this.FoodID != 0)
                basket.Food.ID = this.ID;


            return basket;
        }
        public Basket ConvertToModel(Basket basket)
        {
            if (basket != null)
            {
                if (this.ID != 0)
                    basket.ID = this.ID;
                if (this.UserID != 0)
                    basket.User.ID = this.ID;
                if (this.FoodID != 0)
                    basket.Food.ID = this.ID;

                return basket;
            }
            return null;
        }
    }
}