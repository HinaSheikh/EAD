using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StudentDB
    {
        //String _connString = @"Server=.\SQLEXPRESS2008;Database=Test;User Id=sa;Password=P@ssword12345;";
        String connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";
        public int SaveStudent(StudentDTO dto)
        {
           

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    String sqlQuery = "";

                    //String sqlQuery = "INSERT INTO dbo.student(name,city,age) VALUES('"+name+"','"+city+"',"+age+")";

                    if (dto.StudentID > 0)
                    {
                        sqlQuery = String.Format("Update dbo.student Set name='{0}',city='{1}',age='{2}' Where id={3} ", dto.Name, dto.City, dto.Age,dto.StudentID);
                    }
                    else
                    {
                        sqlQuery = String.Format("INSERT INTO dbo.student(name,city,age) VALUES('{0}','{1}',{2})", dto.Name, dto.City, dto.Age);
                    }

                    SqlCommand command = new SqlCommand(sqlQuery, conn);

                    int recEff = command.ExecuteNonQuery();

                    return recEff;

                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public DataTable GetStudents()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    String sqlQuery = "Select * from dbo.Student";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        public List<StudentDTO> GetStudentsList()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    String sqlQuery = "Select * from dbo.Student";

                    SqlCommand command = new SqlCommand(sqlQuery, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    List<StudentDTO> list = new List<StudentDTO>();

                    while (reader.Read() == true)
                    {
                        StudentDTO dto = new StudentDTO();
                        //(int) reader.GetValue(0)
                        dto.StudentID = reader.GetInt32(0);
                        dto.Name = reader.GetString(1);
                        dto.City= reader.GetString(2);
                        dto.Age = reader[3].ToString();

                        list.Add(dto);
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public StudentDTO GetStudentByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    String sqlQuery = String.Format("Select * from dbo.Student Where id={0}", id);

                    SqlCommand command = new SqlCommand(sqlQuery, conn);

                    SqlDataReader reader = command.ExecuteReader();

                    StudentDTO dto = null;
                    if(reader.Read() == true)
                    {
                        dto = new StudentDTO();
                        //(int) reader.GetValue(0)
                        dto.StudentID = reader.GetInt32(0);
                        dto.Name = reader.GetString(1);
                        dto.City = reader.GetString(2);
                        dto.Age = reader[3].ToString();
                    }

                    return dto;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
