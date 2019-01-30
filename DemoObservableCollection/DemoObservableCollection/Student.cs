using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoObservableCollection
{
    public class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public string Details { get { return ID + "   " + Name; } }
    }
}
