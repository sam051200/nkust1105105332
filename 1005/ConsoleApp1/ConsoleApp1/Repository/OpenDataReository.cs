using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1.Repository
{
    class OpenDataReository
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sam\Desktop\nkust軟體工程\1005\ConsoleApp1\ConsoleApp1\data\Database1.mdf;Integrated Security=True";
            }
        }
        public void Insert(Class1 item)
        {
            var newItem = item;
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
            INSERT INTO OpenData(_y, _g,_m)
            VALUES              (N'{0}', N'{1}', N'{2}')
            ", newItem._y.Replace("'", ""), newItem._g.Replace("'", ""), newItem._m.Replace("'", ""));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
