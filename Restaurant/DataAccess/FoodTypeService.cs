using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Models;

namespace Restaurant.DataAccess
{
    public class FoodTypeService
    {
        private static string _connectionString = "Data Source=.;Initial Catalog=Resturant;Integrated Security=True";

        public static bool FoodTypeInsert(FoodType foodtype)
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("FoodType_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            if (foodtype != null)
            {
                SqlParameter _name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(foodtype.Name))
                    _name.Value = foodtype.Name;
                else
                    _name.Value = DBNull.Value;

                command.Parameters.Add(_name);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                //   return "نوع غذا با موفقیت ثبت شد";
                return true;
            }
            //  return "نوع غذا با موفقیت ثبت نشد";
            return false;
        }

        public static bool FoodTypeDelete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Foodtype_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            if (id != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = id;

                command.Parameters.Add(_id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                // return "نوع غدا با موفقیت حذف شد";
                return true;
            }

            // return "نوع غذا با موفقیت حذف نشد";
            return false;

        }

        public static bool FootTypeEdit(FoodType foodtype)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("FoodType_Edit", connection);
            command.CommandType = CommandType.StoredProcedure;
            if (foodtype.ID != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = foodtype.ID;
                SqlParameter _name = new SqlParameter("@Name", SqlDbType.Int);
                if (!string.IsNullOrEmpty(foodtype.Name))
                    _name.Value = foodtype.Name;
                else
                    _name.Value = DBNull.Value;

                command.Parameters.Add(_id);
                command.Parameters.Add(_name);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
                // return "نوع غذا با موفقیت ویرایش شد";
            }
            return false;
            // return "نوع غذا با موفقیت ویرایش نشد";
        }

        public static DataTable FoodTypeSelect(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("FoodType_Select", connection);
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