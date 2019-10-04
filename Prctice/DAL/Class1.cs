using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Class1
    {
       public static string connstr = @"Data Source=DESKTOP-3Q3GQ42\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";

        public static List<Models.student> GetaLLsTUDENTS()
        {
            List<Models.student> list = new List<Models.student>();
            Models.student std;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Student", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    std = new Models.student();
                    std.ID = Convert.ToInt32(reader[0]);
                    std.Name= Convert.ToString(reader[1]);
                    std.Age= Convert.ToInt32(reader[2]);

                    list.Add(std);

                }
            }
            return list;
        }

        public static bool Is_Valid_User(string uname, string password)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Student", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   if(Convert.ToString(reader[1])==uname)
                    {
                        return true;
                    }

                }
                return false;
            }
        }
    }
}
