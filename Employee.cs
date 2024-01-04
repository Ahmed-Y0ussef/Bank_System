using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Employee:Person
    {
        //Atttibutes
        public double Salary {  get; set; }

        //Static Attribute
        static int EmpCount {  get; set; }

        //Constructor
        public Employee(int id,string name, string password) :base(id,name, password) 
        {

        }

        //Abstracted Method
        
    }
}
