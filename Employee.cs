using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Employee:Person
    {
        static int EmpCount {  get; set; }
        protected override void idIncrement()
        {
            EmpCount++;
            Id = EmpCount;
        }
        public Employee(string name,string username ,string password):base(name,username,password) 
        {
            idIncrement();
            
        }
        
    }
}
