using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Basket
    {
        #region Variables

        private int _id;
        private int _status;
        private User _user;
        private Food _food;
        private DateTime _date;

        #endregion

        #region Propeties
        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public Food Food
        {
            get { return _food; }
            set { _food = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        #endregion

        #region Methodes
        public Basket()
        {
            this.Status = 1;
            this.Date = DateTime.Now;
        }
        public static List<Basket> Convert(DataTable dataTable)
        {
            List<Basket> result = null;
            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<Basket>();
                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }
        public static Basket Convert(DataRow dataRow)
        {
            Basket result = null;
            if (dataRow != null)
            {
                result = new Basket();
                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Status") && dataRow["Status"] != DBNull.Value)
                    result.Status = System.Convert.ToInt32(dataRow["Status"]);
                if (dataRow.Table.Columns.Contains("User") && dataRow["User"] != DBNull.Value)
                    result.User.ID = System.Convert.ToInt32(dataRow["User"]);
                if (dataRow.Table.Columns.Contains("Food") && dataRow["Food"] != DBNull.Value)
                    result.Food.ID = System.Convert.ToInt32(dataRow["Food"]);
                if (dataRow.Table.Columns.Contains("Date") && dataRow["Date"] != DBNull.Value)
                    result.Date = System.Convert.ToDateTime(dataRow["Date"]);
            }
            return result;
        }
        #endregion
    }
}
