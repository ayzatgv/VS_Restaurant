using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Stock
    {
        #region Variables

        private int _id;
        private Food _food;
        private int _quantity;

        #endregion

        #region Propeties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public Food Food
        {
            get { return _food; }
            set { _food = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


        

        #endregion

        #region Methodes

        #endregion

    }
}