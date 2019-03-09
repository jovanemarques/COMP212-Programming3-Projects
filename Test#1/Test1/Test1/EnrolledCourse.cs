using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{

    public class EnrolledCourse
    {
        public string CourseCode { get; private set; }
        public string CourseTitle { get; private set; }

        public EnrolledCourse(string code, string title)
        {
            CourseCode = code;
            CourseTitle = title;
        }
    }
}
