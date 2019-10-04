using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using Model;

namespace BAL
{
    public class StudentBAL
    {
        public int SaveStudent(StudentDTO dto )
        {
            StudentDB dbObj = new StudentDB();
            return dbObj.SaveStudent(dto);
        }

        public DataTable GetStudents()
        {
            StudentDB dbObj = new StudentDB();
            return dbObj.GetStudents();
        }

        public List<StudentDTO> GetStudentsList()
        {
            StudentDB dbObj = new StudentDB();
            return dbObj.GetStudentsList();
        }

        public StudentDTO GetStudentByID(int id)
        {
            StudentDB dbObj = new StudentDB();
            return dbObj.GetStudentByID(id) ;
        }
    }
}
