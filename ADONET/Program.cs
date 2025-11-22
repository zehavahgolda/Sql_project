using System;

namespace ADONET
{
      class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            string connection_string = "Data Source=srv2\\pupils2;Initial Catalog=Store_329391924;Integrated Security=True;Trust Server Certificate=True";
            DataAccess da = new DataAccess();
            da.InsertdatatoCatogories(connection_string);
            da.printData(connection_string);    
        }

    }

}
