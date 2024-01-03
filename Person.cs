using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public abstract class Person
    {
        //Atttibutes
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password {  get; set; }

        //Constructor
        public Person( string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        //Abstracted Method
        protected abstract void idIncrement();       
    }
}
