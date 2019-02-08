using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoINotifyPropertyChange
{
    public class Person : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string fullName;
        public string FirstName
        { get { return firstName; }
          set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                    OnPropertyChanged("FullName");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                    OnPropertyChanged("FullName");
                }
            }
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property)); //raise an evnet
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
