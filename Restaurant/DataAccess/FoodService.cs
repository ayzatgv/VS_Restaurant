using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Models;


namespace Restaurant.DataAccess
{
    public class FoodService
    {
        private static string _connectionString = "Data Source=.;Initial Catalog=Resturant;Integrated Security=True";

        public static bool FoodInsert(Food food)
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Food_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;
            if (food != null)
            {
                SqlParameter _foodtypeid = new SqlParameter("@FoodTypeID", SqlDbType.Int);
                if (food.FoodType.ID     != 0)
                    _foodtypeid.Value = food.FoodType.ID;
                else
                    _foodtypeid.Value = DBNull.Value;

                SqlParameter _price = new SqlParameter("@Price", SqlDbType.Int);
                if (food.Price != 0)
                    _price.Value = food.Price;
                else
                    _price.Value = DBNull.Value;
                SqlParameter _name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(food.Name))
                    _name.Value = food.Name;
                else
                    _name.Value = DBNull.Value;
                SqlParameter _description = new SqlParameter("@Description", SqlDbType.NVarChar, 255);
                if (!string.IsNullOrEmpty(food.Description))
                    _description.Value = food.Description;
                else
                    _description.Value = DBNull.Value;

                command.Parameters.Add(_foodtypeid);
                command.Parameters.Add(_price);
                command.Parameters.Add(_name);
                command.Parameters.Add(_description);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                //   return "غذا با موفقیت ثبت شد";
                return true;
            }
            //  return "غذا با موفقیت ثبت نشد";
            return false;
        }
        public static bool FoodDelete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Food_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            if (id != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = id;

                command.Parameters.Add(_id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                // return "غذا با موفقیت حذف شد";
                return true;
            }

            // return "غذا با موفقیت حذف نشد";
            return false;

        }
        public static bool FoodEdit(Food food)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Food_Edit", connection);
            command.CommandType = CommandType.StoredProcedure;
            if (food.ID != 0)
            {
                SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                _id.Value = food.ID;
                SqlParameter _foodtypeid = new SqlParameter("@FoodType", SqlDbType.Int);
                if (food.FoodType.ID != 0)
                    _foodtypeid.Value = food.FoodType.ID;
                else
                    _foodtypeid.Value = DBNull.Value;
                SqlParameter _price = new SqlParameter("@Price", SqlDbType.Int);
                if (food.Price != 0)
                    _price.Value = food.Price;
                else
                    _price.Value = DBNull.Value;
                SqlParameter _name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                if (!string.IsNullOrEmpty(food.Name))
                    _name.Value = food.Name;
                else
                    _name.Value = DBNull.Value;
                SqlParameter _description = new SqlParameter("@Description", SqlDbType.NVarChar, 255);
                if (!string.IsNullOrEmpty(food.Description))
                    _description.Value = food.Description;
                else
                    _description.Value = DBNull.Value;

                command.Parameters.Add(_id);
                command.Parameters.Add(_foodtypeid);
                command.Parameters.Add(_price);
                command.Parameters.Add(_name);
                command.Parameters.Add(_description);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
                // return "غذا با موفقیت ویرایش شد";
            }
            return false;
            // return "غذا با موفقیت ویرایش نشد";
        }
        public static DataTable FoodSelect(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("Food_Select", connection);
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