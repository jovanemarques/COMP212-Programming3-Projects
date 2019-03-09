using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{

    class EnrolledCourseList : ObservableCollection<EnrolledCourse>
    {
        public EnrolledCourseList() : base()
        { }

        public void RegisterCourse(EnrolledCourse ec)
        {
            this.Add(ec);
        }
    }
}
