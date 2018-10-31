using opendata.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1.Repository
{
    class Repository
    {
        public SqlConnection connect_sql()
        {
            string port= @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\user\Desktop\gittest\ConsoleApp1\ConsoleApp1\AppData\Database1.mdf; Integrated Security = True";
            SqlConnection conn = new SqlConnection(port);
            return conn;
        }
        public void Insert_Data_SQL(SqlConnection conn, Class1 item)
        {
            conn.Open();
           string sql_Insert = "INSERT INTO opendata_Table(所在縣市,醫院名稱,醫院評鑑結果) VALUES ( N'" + item.所在縣市 + "',N'" + item.醫院名稱 + "',N'" + item.醫院評鑑結果 + "')";

            SqlCommand mySqlCmd = new SqlCommand(sql_Insert, conn);

            mySqlCmd.ExecuteNonQuery();
            conn.Close();
        }
        public void select_Data_SQL(SqlConnection conn, Class1 item)
        {
            conn.Open();
            string sql_Insert = "INSERT INTO opendata_Table(所在縣市,醫院名稱,醫院評鑑結果) VALUES ( N'" + item.所在縣市 + "',N'" + item.醫院名稱 + "',N'" + item.醫院評鑑結果 + "')";
            SqlCommand mySqlCmd = new SqlCommand(sql_Insert, conn);
            using (SqlDataReader reader = mySqlCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["所在縣市"]));
                }
             }
            conn.Close();

        }
    }
}
