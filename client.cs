using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Client : Person
    {
        //Atttibutes
        public double Balance {  get; set; }
        public bool IsDebit { get; set; }

        //Static Attribute
        static int clientCount {  get; set; }

        //Constructor        
        public Client(string name, string password, double balance, bool isDebit) :base(name, password)
        {
            this.Balance = balance;
            this.IsDebit = isDebit;
            idIncrement();
        }

        //Abstracted Method
        protected override void idIncrement()
        {
            clientCount++;
            Id = clientCount;
        }
    }
}
