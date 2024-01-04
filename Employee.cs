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
<<<<<<< HEAD
        
=======
        protected override void idIncrement()
        {
            EmpCount++;
            Id = EmpCount;
        }

        //Methods
        public void AddClient(string name, string pass, double balance, bool isDebit)
        {
            Client c = new Client(name,pass,balance,isDebit);
        }
        public void Withdraw(double amount, ref Client c)
        {
            c.Withdraw(amount);
        }
        public void Deposit(double amount, ref Client c)
        {
            c.Deposit(amount);
        }
        public void TransferTo(ref Client c1, double amount, ref Client c2)
        {
            c1.TransferTo(amount, ref c2);
        }
        public void PrintEmpInfo()
        {
            Console.WriteLine($"Name : {Name}\nId : {Id}\nSalary : {Salary}\n=================================== ");
        }
>>>>>>> fadcb9481ed5d9c16b2e2ef05bf5dbda40e88be3
    }
}
