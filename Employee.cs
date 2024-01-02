using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Employee:Person
    {
        public Employee(string name,string username ,string password):base(name,username,password) 
        {
            base.Id=base.idIncrement();
            
        }
        public Employee()
        {
            Id++;
        }
    }
}
