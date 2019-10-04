using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Model
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
        public String Age { get; set; }
    }
    
}
