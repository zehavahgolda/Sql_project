using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
    internal class DataAccess
    {
        public object Catogery_Name { get; private set; }

        public int InsertdatatoCatogories( string connectionstring)
        {
            string Catogery_name;
            Console.WriteLine("insert CategoryName");
            Catogery_name = Console.ReadLine();
            string query = "INSERT INTO Categories(Catogery_Name) " +
            "VALUES (@Catogery_Name) ";
            using (SqlConnection cn = new SqlConnection(connectionstring))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {

                cn.Open();
                cmd.Parameters.Add("@Catogery_Name", SqlDbType.VarChar, 30).Value =Catogery_name;
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                Console.WriteLine("rowsAffected" + rowsAffected);
                return rowsAffected;
            }
        }
        public int InsertDataToProducts(string connectionstring)
        { 
            string Product_Name, Descreption_Product, Path;
            int Catogery_Id;
           double Price;
            Console.WriteLine("Insert Product_Name");
            Product_Name = Console.ReadLine();
            Console.WriteLine("Insert Price");
            Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Insert Catogery_Id");
            Catogery_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert Descreption_Product");
            Descreption_Product= Console.ReadLine();
            Console.WriteLine("Insert Path");
            Path = Console.ReadLine();

            string query = "INSERT INTO Products(Product_Name,Descreption_Product,Path,Catogery_Id,Price) " +
           "VALUES (@Product_Name,@Descreption_Product,@Path,@Catogery_Id,@Price) ";
            using (SqlConnection cn = new SqlConnection(connectionstring))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                cmd.Parameters.Add("@Product_Name", SqlDbType.VarChar, 30).Value = Product_Name;
                cmd.Parameters.Add("@Descreption_Product", SqlDbType.VarChar, 30).Value = Descreption_Product;
                cmd.Parameters.Add("@Path", SqlDbType.VarChar, 30).Value = Path;
                cmd.Parameters.Add("@Catogery_Id", SqlDbType.Int).Value = Catogery_Id;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = Price;
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                Console.WriteLine("rowsAffected" + rowsAffected);
                return rowsAffected;

            }

        }
        public void InsertData(string connectionstring)
        {
            Console.WriteLine("Do yoou want to insert more data into Catogeries table? y/n");
            string selected= Console.ReadLine();
            while (selected == "y" || selected == "Y")
            {
                InsertdatatoCatogories(connectionstring);
                InsertData(connectionstring);
            }

            Console.WriteLine("Do yoou want to insert more data into Products table? y/n");
            string selected_1 = Console.ReadLine();
            while (selected_1 == "y" || selected_1 == "Y")
            {
                InsertDataToProducts(connectionstring);
                InsertData(connectionstring);

            }


        }
    
        public void readDataCatogeries(string connectionstring) {
            string query = "select * from Catogeries";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }

        }
        public void readDataProducts(string connectionstring)
        {
            string query = "select * from Products";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }

        }
    

        public void printData(string connectionstring)
        {
            Console.WriteLine("Do you want to print Categories table? y/n");
            string select=Console.ReadLine();
            if (select == "y"|| select == "Y")
            {
                readDataCatogeries(connectionstring); 
            }

            

            Console.WriteLine("Do you want to print Products table? y/n");
            string select2 = Console.ReadLine();
            if (select == "y" || select == "Y")
            {
                readDataProducts(connectionstring);

            }

        }
    }
}
