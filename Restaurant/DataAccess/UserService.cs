using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Models;

namespace Restaurant.DataAccess
{
    public class UserService
    {
        private static string _connectionString = "Data Source=.;Initial Catalog=Resturant;Integrated Security=True";

        //
        // jense khoroji ro bayad jori begirim ke btonim befahmim ke moafagh anjam shod ya na (masalan felan bool)
        public static bool UserInsert(User user)
        {
            
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("User_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            if (user != null)
            {
                SqlParameter _role = new SqlParameter("@Role", SqlDbType.Int);
                if (user.Role != 0)
                    _role.Value = user.Role;
                else
                    _role.Value = DBNull.Value;
                SqlParameter _firstname = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.FirstName))
                    _firstname.Value = user.FirstName;
                else
                    _firstname.Value = DBNull.Value;
                SqlParameter _lastname = new SqlParameter("@LastName", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.LastName))
                    _lastname.Value = user.LastName;
                else
                    _lastname.Value = DBNull.Value;
                SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;
                SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 512);
                if (!string.IsNullOrEmpty(user.Password))
                    _password.Value = user.Password;
                else
                    _password.Value = DBNull.Value;
                SqlParameter _passwordSalt = new SqlParameter("@PasswordSalt", SqlDbType.NVarChar, 512);
                if (!string.IsNullOrEmpty(user.PasswordSalt))
                    _passwordSalt.Value = user.PasswordSalt;
                else
                    _passwordSalt.Value = DBNull.Value;
                SqlParameter _email = new SqlParameter("@Email", SqlDbType.NVarChar, 255);
                if (!string.IsNullOrEmpty(user.Email))
                    _email.Value = user.Email;
                else
                    _email.Value = DBNull.Value;
                SqlParameter _phone = new SqlParameter("@Phone", SqlDbType.NVarChar,50);
                if (!string.IsNullOrEmpty(user.Phone))
                    _phone.Value = user.Phone;
                else
                    _phone.Value = DBNull.Value;


                command.Parameters.Add(_role);
                command.Parameters.Add(_firstname);
                command.Parameters.Add(_lastname);
                command.Parameters.Add(_username);
                command.Parameters.Add(_password);
                command.Parameters.Add(_passwordSalt);
                command.Parameters.Add(_email);
                command.Parameters.Add(_phone);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                //   return "کاربر با موفقیت ثبت شد";
                return true;
            }
            //  return "کاربر با موفقیت ثبت نشد";
            return false;
        }

        public static bool UserDelete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("User_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            if (id != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = id;

                command.Parameters.Add(_id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                // return "کاربر با موفقیت حذف شد";
                return true;
            }

            // return "کاربر با موفقیت حذف نشد";
            return false;

        }

        public static bool UserEdit(User user)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("User_Edit",connection);
            command.CommandType = CommandType.StoredProcedure;
            if (user.ID != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = user.ID;
                SqlParameter _role = new SqlParameter("@Role", SqlDbType.Int);
                if (user.Role != 0)
                    _role.Value = user.Role;
                else
                    _role.Value = DBNull.Value;
                SqlParameter _firstname = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.FirstName))
                    _firstname.Value = user.FirstName;
                else
                    _firstname.Value = DBNull.Value;
                SqlParameter _lastname = new SqlParameter("@LastName", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.LastName))
                    _lastname.Value = user.LastName;
                else
                    _lastname.Value = DBNull.Value;
                SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;
                SqlParameter _email = new SqlParameter("@Email", SqlDbType.NVarChar, 255);
                if (!string.IsNullOrEmpty(user.Email))
                    _email.Value = user.Email;
                else
                    _email.Value = DBNull.Value;
                SqlParameter _phone = new SqlParameter("@Phone", SqlDbType.NVarChar,50);
                if (!string.IsNullOrEmpty(user.Phone))
                    _phone.Value = user.Phone;
                else
                    _phone.Value = DBNull.Value;

                command.Parameters.Add(_id);
                command.Parameters.Add(_role);
                command.Parameters.Add(_firstname);
                command.Parameters.Add(_lastname);
                command.Parameters.Add(_username);
                command.Parameters.Add(_email);
                command.Parameters.Add(_phone);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
                // return "کاربر با موفقیت ویرایش شد";
            }
            return false;
           // return "کاربر با موفقیت ویرایش نشد";
        }

        public static bool UserSelfEdit(User user)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("User_SelfEdit", connection);
            command.CommandType = CommandType.StoredProcedure;
            if (user.ID != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = user.ID;
                SqlParameter _firstname = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.FirstName))
                    _firstname.Value = user.FirstName;
                else
                    _firstname.Value = DBNull.Value;
                SqlParameter _lastname = new SqlParameter("@LastName", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.LastName))
                    _lastname.Value = user.LastName;
                else
                    _lastname.Value = DBNull.Value;
                SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.Username))
                    _username.Value = user.Username;
                else
                    _username.Value = DBNull.Value;
                SqlParameter _email = new SqlParameter("@Email", SqlDbType.NVarChar, 255);
                if (!string.IsNullOrEmpty(user.Email))
                    _email.Value = user.Email;
                else
                    _email.Value = DBNull.Value;
                SqlParameter _phone = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(user.Phone))
                    _phone.Value = user.Phone;
                else
                    _phone.Value = DBNull.Value;

                command.Parameters.Add(_id);
                command.Parameters.Add(_firstname);
                command.Parameters.Add(_lastname);
                command.Parameters.Add(_username);
                command.Parameters.Add(_email);
                command.Parameters.Add(_phone);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
                // return "کاربر با موفقیت ویرایش شد";
            }
            return false;
            // return "کاربر با موفقیت ویرایش نشد";
        }

        public static DataTable UserSelect(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("User_Select", connection);
            command.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;


            SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
            if (id != 0)
                _id.Value = id;
            else
                _id.Value = DBNull.Value;

            command.Parameters.Add(_id);

            connection.Open();
            dataAdapter.Fill(dataTable);
            connection.Close();

            return dataTable;

        }
        public static DataTable UserSelectAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("User_SelectAll",connection);
            command.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;

            connection.Open();
            dataAdapter.Fill(dataTable);
            connection.Close();

            return dataTable;
        }
        public static int UserLogin(string username,string password)
        {
             SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("User_Login", connection);
            command.CommandType = CommandType.StoredProcedure;
            int Result=0;

            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar,50);
            if (!string.IsNullOrEmpty(username))
                _username.Value = username;
            else
                _username.Value = DBNull.Value;

            SqlParameter _Password = new SqlParameter("@Password",SqlDbType.NVarChar,512);
            if (!string.IsNullOrEmpty(password))
                _Password.Value = password;
            else
                _Password.Value = DBNull.Value;

            command.Parameters.Add(_username);
            command.Parameters.Add(_Password);

            command.Parameters.Add(RetunParam);



            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            Result= ((int)command.Parameters[ReturnValue].Value);

            return Result;
        }
        public static SqlParameter RetunParam
        {
            get
            {
                SqlParameter _returnvalue = new SqlParameter();
                _returnvalue.ParameterName = ReturnValue;
                _returnvalue.Direction = ParameterDirection.ReturnValue;
                return _returnvalue;
            }
        }
        static public string ReturnValue
        { get { return "ReturnValue"; } }


        public static DataTable UserSelectByUsername(string username)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("User_SelectByUsername", connection);
            command.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;


            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar);
            if (!string.IsNullOrEmpty(username))
                _username.Value = username;
            else
                _username.Value = DBNull.Value;

            command.Parameters.Add(_username);

            connection.Open();
            dataAdapter.Fill(dataTable);
            connection.Close();

            return dataTable;

        }
    }
}