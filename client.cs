using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class client:Person
    {
        static int clientCount {  get; set; }
        public Acount Acount { get; set; }
        protected override void idIncrement()
        {
            clientCount++;
            Id = clientCount;
        }
        public client(double balance,string name,string username,string password):base(name,username,password)
        {
            Acount.Balance = balance;
            idIncrement();
        }

        



    }
}
