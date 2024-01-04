using Newtonsoft.Json;
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
        public double Balance { get; set; }
        public bool IsDebit { get; set; }

        //Static Attribute
        static int clientCount { get; set; }


        const string FilePath = "C:\\Users\\drnad\\Source\\Repos\\Bank_System\\clients.json";
        public List<Client> Clients;

        //Constructor        
        public Client(int id, string name, string password, double balance, bool isDebit) : base(id, name, password)
        {

            this.Balance = balance;
            this.IsDebit = isDebit;
        }

        //Methods

        protected override void idIncrement()
        {
            clientCount++;
            Id = clientCount;
        }

        private void SaveData()
        {
            var Json = JsonConvert.SerializeObject(Clients, Formatting.Indented);
            File.WriteAllText(FilePath, Json);
        }

        public void Withdraw(double amount)
        {
            if (IsDebit)
            {
                if (amount > 0)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdrawal of {amount} done successfully");
                }
                else
                    Console.WriteLine("please enter valid amount");
            }
            else
            {
                if (amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdrawal of {amount} done successful");
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
                Console.WriteLine($"Deposit of {amount} done successful");
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
                Console.WriteLine($"Transfer of {amount} to {c} successful.");
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

        //public  List<Client> PrintInfo() //لسه
        //{

        //}

    }
}
