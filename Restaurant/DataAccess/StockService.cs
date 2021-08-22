using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Models;

namespace Restaurant.DataAccess
{
    public class StockService
    {
        public class FoodTypeService
        {
            private static string _connectionString = "Data Source=.;Initial Catalog=Resturant;Integrated Security=True";

            public static bool StockInsert(Stock stock)
            {

                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("Stock_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;

                if (stock != null)
                {
                    SqlParameter _foodid = new SqlParameter("@FoodID", SqlDbType.Int);
                    if (stock.Food.ID != 0)
                        _foodid.Value = stock.Food.ID;
                    else
                        _foodid.Value = DBNull.Value;

                    SqlParameter _quantity = new SqlParameter("@Quantity", SqlDbType.Int);
                    if (stock.Food.ID != 0)
                        _quantity.Value = stock.Quantity;
                    else
                        _quantity.Value = DBNull.Value;

                    command.Parameters.Add(_foodid);
                    command.Parameters.Add(_quantity);


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    //   return " با موفقیت ثبت شد";
                    return true;
                }
                //  return " با موفقیت ثبت نشد";
                return false;
            }

            public static bool StockDelete(int id)
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("Stock_Delete", connection);
                command.CommandType = CommandType.StoredProcedure;

                if (id != 0)
                {
                    SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                    _id.Value = id;

                    command.Parameters.Add(_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    // return "با موفقیت حذف شد";
                    return true;
                }

                // return " با موفقیت حذف نشد";
                return false;

            }

            public static bool StockEdit(Stock stock)
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("Stock_Edit", connection);
                command.CommandType = CommandType.StoredProcedure;
                if (stock.ID != 0)
                {
                    SqlParameter _id = new SqlParameter("@ID", SqlDbType.Int);
                    _id.Value = stock.ID;
                    SqlParameter _foodid = new SqlParameter("@FoodID", SqlDbType.Int);
                    if (stock.Food.ID != 0)
                        _foodid.Value = stock.Food.ID;
                    else
                        _foodid.Value = DBNull.Value;
                    SqlParameter _quantity = new SqlParameter("@Quantity", SqlDbType.Int);
                    if (stock.Quantity != 0)
                        _quantity.Value = stock.Quantity;
                    else
                        _quantity.Value = DBNull.Value;

                    command.Parameters.Add(_id);
                    command.Parameters.Add(_foodid);
                    command.Parameters.Add(_quantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                    // return " با موفقیت ویرایش شد";
                }
                return false;
                // return " با موفقیت ویرایش نشد";
            }

            public static DataTable StockSelect(int id)
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("Stock_Select", connection);
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
}