using Bank_System;
using Newtonsoft.Json;
using Spectre.Console;
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
        private static int CurrentClientId { get; set; }
        public int EmpId { get; set; }

        //Static Attribute



        //Constructor        
        public Client(int id, string name, string password, double balance, bool isDebit, int empId) : base(id, name, password)
        {

            this.Balance = balance;
            this.IsDebit = isDebit;
            this.EmpId = empId;
        }

        //Methods

        public static void Login()
        {
            Employee.Clients = Employee.LoadData();
            Console.WriteLine("Enter your Id");
            CurrentClientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your password");
            string pass = Console.ReadLine();
            if (Employee.Clients.Any(c => c.Id == CurrentClientId) && Employee.Clients.Any(c => c.Password == pass))
            {
                AnsiConsole.Write(new FigletText("Login successfully").Color(Color.Yellow).Centered());
                Thread.Sleep(1000);
                Console.Clear();
                AnsiConsole.Write(new FigletText($"ohayo {Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Name}").Color(Color.Yellow).Centered());


            }
            else
            {
                Console.WriteLine("Invalid pass or Id\npress 1 o try again or 2 to get back to the previous menu");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();

                        Login();
                        break;
                    case 2:
                        Console.Clear();

                        Bank.BankSystem();
                        break;
                }
            }
        }



        public static void Withdraw()
        {
            Employee.Clients = Employee.LoadData();


            Console.Write("Enter the amount for withdrawa : ");
            if (double.TryParse(Console.ReadLine(), out double withdrawalAmount) && Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Balance > withdrawalAmount)
            {
                Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Balance -= withdrawalAmount;
                Employee.SaveData();
                Console.WriteLine($"Withdrawa of {withdrawalAmount:C} successful.");
            }
            else
            {
                Console.WriteLine("Invalid input for withdrawal amount. Try again.");
            }

            RollBack();
        }

        public static void Deposit()
        {
            Employee.Clients = Employee.LoadData();
            Console.Write("Enter deposit amount: ");
            double depositAmount;
            if (double.TryParse(Console.ReadLine(), out depositAmount))
            {
                Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Balance += depositAmount;
                Employee.SaveData();
                Console.WriteLine($"Deposit of {depositAmount:C} successful.");
            }
            else
            {
                Console.WriteLine("Invalid input for deposit amount. Try again.");
            }
            RollBack();
        }
        public static void TransferTo()
        {
            Employee.Clients = Employee.LoadData();
            Console.Write("Enter the Account ID: ");
            int targetClientId = int.Parse(Console.ReadLine());
            Client targetClient = Employee.Clients.FirstOrDefault(c => c.Id == targetClientId);
            if (targetClient != null)
            {
                Console.Write("Enter transfer amount: ");
                if (double.TryParse(Console.ReadLine(), out double transferAmount) && Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Balance > transferAmount)
                {
                    Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Balance -= transferAmount;
                    targetClient.Balance += transferAmount;
                    Employee.SaveData();
                    Console.WriteLine($"Transfer of {transferAmount:C} to {targetClientId} successful.");
                }
                else
                {
                    Console.WriteLine("Invalid input for transfer amount. Try again.");
                }
            }
            else
            {
                Console.WriteLine($"Target client {targetClientId} not found.");
            }
            RollBack();
        }
        public static void GetBalance()
        {
            Console.WriteLine($"your current Balance : {Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Balance}");
            RollBack();
        }
        public static void UpdatePassOrID() 
        {
            Employee.Clients = Employee.LoadData();
            Console.WriteLine("press 1 to update password or 2 to update ID");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the new Password");
                    Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Password = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter the new ID");
                    Employee.Clients.FirstOrDefault(c => c.Id == CurrentClientId).Id=int.Parse(Console.ReadLine());
                    break;
            }
            Employee.SaveData();
        }
        public static void RollBack()
        {
            Console.WriteLine("press 1 to exit or 2 to get back tto the previous menu");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    AnsiConsole.Write(new FigletText("THX For using our System").Color(Color.Yellow).Centered());
                    Environment.Exit(0);

                    break;
                case 2:
                    Console.Clear();
                    Bank.ClientFunc();
                    break;
            }

        }
    }
}
