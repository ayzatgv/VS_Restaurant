using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Restaurant.Models
{
    public class User
    {
        #region Variables   

        private int _id;
        private int _role;
        private string _firstname;
        private string _lastname;
        private string _username;
        private string _password;
        private string _passwordSalt;
        private string _email;
        private string _phone;

        #endregion

        #region Propeties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string PasswordSalt
        {
            get { return _passwordSalt; }
            set { _passwordSalt = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        #endregion

        #region Methodes
        public User()
        {
            this.Role = 1;
        }

        public static List<User> Convert(DataTable dataTable)
        {
            List<User> result = null;
            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                result = new List<User>();
                foreach (DataRow item in dataTable.Rows)
                {
                    result.Add(Convert(item));
                }
            }
            return result;
        }

        public static User Convert(DataRow dataRow)
        {
            User result = null;
            if (dataRow != null)
            {
                result = new User();
                if (dataRow.Table.Columns.Contains("ID") && dataRow["ID"] != DBNull.Value)
                    result.ID = System.Convert.ToInt32(dataRow["ID"]);
                if (dataRow.Table.Columns.Contains("Role") && dataRow["Role"] != DBNull.Value)
                    result.Role = System.Convert.ToInt32(dataRow["Role"]);
                if (dataRow.Table.Columns.Contains("FirstName") && dataRow["FirstName"] != DBNull.Value)
                    result.FirstName = System.Convert.ToString(dataRow["FirstName"]);
                if (dataRow.Table.Columns.Contains("LastName") && dataRow["LastName"] != DBNull.Value)
                    result.LastName = System.Convert.ToString(dataRow["LastName"]);
                if (dataRow.Table.Columns.Contains("Username") && dataRow["Username"] != DBNull.Value)
                    result.Username = System.Convert.ToString(dataRow["Username"]);
                if (dataRow.Table.Columns.Contains("Password") && dataRow["Password"] != DBNull.Value)
                    result.Password = System.Convert.ToString(dataRow["Password"]);
                if (dataRow.Table.Columns.Contains("PasswordSalt") && dataRow["PasswordSalt"] != DBNull.Value)
                    result.PasswordSalt = System.Convert.ToString(dataRow["PasswordSalt"]);
                if (dataRow.Table.Columns.Contains("Email") && dataRow["Email"] != DBNull.Value)
                    result.Email = System.Convert.ToString(dataRow["Email"]);
                if (dataRow.Table.Columns.Contains("Phone") && dataRow["Phone"] != DBNull.Value)
                    result.Phone = System.Convert.ToString(dataRow["Phone"]);
            }
            return result;
        }

        //public string Hashing(string Password)
        //{
        //    var PasswordSalt = Guid.NewGuid().ToString("N");
        //    var SaltedPassword = this.Phone + PasswordSalt;
        //    var SaltedPasswordByBytes = System.Text.Encoding.UTF8.GetBytes(SaltedPassword);
        //    var HashedPasswor = System.Convert.ToBase64String(SHA512.Create().ComputeHash(SaltedPasswordByBytes));
        //}


        #endregion
    }
}