using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Models;

namespace Restaurant.DataAccess
{
    public class BasketService
    {

        private static string _connectionString = "Data Source=.;Initial Catalog=Resturant;Integrated Security=True";

        public static bool BasketInsert(Basket basket)
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Basket_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            if (basket != null)
            {
                SqlParameter _status = new SqlParameter("@Status", SqlDbType.Int);
                if (basket.Status != 0)
                    _status.Value = basket.Status;
                else
                    _status.Value = DBNull.Value;
                SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
                if (basket.User.ID != 0)
                    _userid.Value = basket.User.ID;
                else
                    _userid.Value = DBNull.Value;
                SqlParameter _foodid = new SqlParameter("@FoodID", SqlDbType.Int);
                if (basket.Food.ID != 0)
                    _foodid.Value = basket.Food.ID;
                else
                    _foodid.Value = DBNull.Value;
                SqlParameter _date = new SqlParameter("@Date", SqlDbType.DateTime);
                if (basket.Date != null)
                    _date.Value = basket.Date;
                else
                    _date.Value = DBNull.Value;

                command.Parameters.Add(_status);
                command.Parameters.Add(_userid);
                command.Parameters.Add(_foodid);
                command.Parameters.Add(_date);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                //   return "سبد با موفقیت ثبت شد";
                return true;
            }
            //  return "سبد با موفقیت ثبت نشد";
            return false;
        }
        public static bool BasketDelete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Basket_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            if (id != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = id;

                command.Parameters.Add(_id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                // return "سبد با موفقیت حذف شد";
                return true;
            }

            // return "سبد با موفقیت حذف نشد";
            return false;

        }
        public static bool BasketEdit(Basket basket)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Basket_Edit", connection);
            command.CommandType = CommandType.StoredProcedure;
            if (basket.ID != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = basket.ID;
                SqlParameter _status = new SqlParameter("@Status", SqlDbType.Int);
                if (basket.Status != 0)
                    _status.Value = basket.Status;
                else
                    _status.Value = DBNull.Value;
                SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
                if (basket.User.ID != 0)
                    _userid.Value = basket.User.ID;
                else
                    _userid.Value = DBNull.Value;
                SqlParameter _foodid = new SqlParameter("@FoodID", SqlDbType.Int);
                if (basket.Food.ID != 0)
                    _foodid.Value = basket.Food.ID;
                else
                    _foodid.Value = DBNull.Value;
                SqlParameter _date = new SqlParameter("@Date", SqlDbType.DateTime);
                if (basket.Date != null)
                    _date.Value = basket.Date;
                else
                    _date.Value = DBNull.Value;

                command.Parameters.Add(_id);
                command.Parameters.Add(_status);
                command.Parameters.Add(_userid);
                command.Parameters.Add(_foodid);
                command.Parameters.Add(_date);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
                // return "سبد با موفقیت ویرایش شد";
            }
            return false;
            // return "سبد با موفقیت ویرایش نشد";
        }
        public static DataTable BasketSelect(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Basket_Select", connection);
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
    }
}