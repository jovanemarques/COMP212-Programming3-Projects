using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ItemDetails
    {
        public string Name { get; set; }
        public int InitialValue { get; set; }

        public ItemDetails(string name, int sValke)
        {
            Name = name;
            InitialValue = sValke;
        }
    }
}
