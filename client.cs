using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class client:Person
    {
        public Acount Acount { get; set; }
       
        public client(double balance,string name,string username,string password):base(name,username,password)
        {
            Acount.Balance = balance;
           base.Id= base.idIncrement();
        }

        public client()
        {
            Id++;
        }



    }
}
