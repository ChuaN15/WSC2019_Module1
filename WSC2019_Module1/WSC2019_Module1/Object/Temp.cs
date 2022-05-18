using System;
using System.Collections.Generic;
using System.Text;

namespace WSC2019_Module1.Object
{
    public class Temp
    {
        public Temp(string Name, int ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
