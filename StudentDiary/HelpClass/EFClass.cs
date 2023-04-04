using StudentDiary.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentDiary.HelpClass
{
    public class EFClass
    {
        public static Entities Contex { get;  } = new Entities ();
    }
}
