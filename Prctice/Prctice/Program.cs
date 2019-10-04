using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prctice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Models.student> returnedlist = DAL.Class1.GetaLLsTUDENTS(); 
        }
    }
}
