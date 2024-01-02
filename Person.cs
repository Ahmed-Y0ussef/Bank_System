using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    abstract public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
       public string Password {  get; set; }
        public Person( string name,string username,string password)
        {
            this.Name = name;
            this.Password = password;
            this.UserName = username;

        }
        protected abstract void idIncrement();
        
            
        
        
    }
}
