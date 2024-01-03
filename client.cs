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

        //Methods
        public void Withdraw (double amount)
        {
            if (IsDebit)
            {
                if (amount > 0)
                {
                    Balance -= amount;
                    Console.WriteLine("opearation is done successfully");
                }
                else
                    Console.WriteLine("please enter valid amount");
            }
            else
            {
                if (amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine("opearation is done successfully");
                }
                else
                    Console.WriteLine("please enter valid amount (your balance may be not enough)");
            }
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine("opearation is done successfully");
            }
            else
                Console.WriteLine("please enter valid amount");
        }
        public void TransferTo(double amount, ref Client c)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                c.Deposit(amount);
                Console.WriteLine("opearation is done successfully");
            }
            else
                Console.WriteLine("please enter valid amount");
        }
        public double GetBalance()
        {
            return Balance; 
        }
        public string AccountType()
        {
            if (!IsDebit)
                return "Credit";
            else
                return "Debit";
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Name : {Name}\nId : {Id}\nBalance : {Balance}\nCard Type : {AccountType()}\n===================================");
        }
    }
}
