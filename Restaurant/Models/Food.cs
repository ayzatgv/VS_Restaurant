using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Food
    {
        #region Variables

        private int _id;
        private FoodType _foodtype;
        private int _price;
        private string _name;
        private string _description;

        #endregion

        #region Propeties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public FoodType FoodType
        {
            get { return _foodtype; }
            set { _foodtype = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        #endregion

        #region Methodes

        #endregion
    }
}