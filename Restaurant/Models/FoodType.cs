using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class FoodType
    {
        #region Variables

        private int _id;
        private string _name;

        #endregion

        #region Propeties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region Methodes

        #endregion

    }
}