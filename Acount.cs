using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Acount
    {
        public double Balance {  get; set; }
        public string Type { get; set; }
        public Acount(double balance, string type) 
        { 
            this.Balance = balance;
            this.Type = type;
        }

    }
}
