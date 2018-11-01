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
        public List<Class1> SelectAll(string name)
        {
            var result = new List<Class1>();
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
            Select _y, _m,_g
            From OpenData");
            if (!string.IsNullOrEmpty(name))
                command.CommandText =
                    $"{command.CommandText} Where _y like N'{name}%'";
            //command.CommandText + "Where 服務分類 = N'" + name + "'";
            //command.Parameters.Add(new SqlParameter("p1", name));
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new Class1();
                item._y = reader.GetString(0);
                item._m = reader.GetString(1);
                item._g = reader.GetString(2);
                result.Add(item);

            }
            connection.Close();
            return result;
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
