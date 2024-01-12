using Main;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    static class Bank
    {

        private static List<AtmLocattion> AtmLocations {  get; set; }
        public const string Atmfile = @"D:\ITI\\Bank_System\ATM.json";

        private  class AtmLocattion
        {
            public string AtmLocation { get; set; }
            public int AtmID { get; set; }
            public AtmLocattion(string location,int id)
            {
                this.AtmID = id;
                this.AtmLocation = location;
            }
        }


        private static void AtmSaveData()
        {
            var json=JsonConvert.SerializeObject(AtmLocations, Formatting.Indented);
            File.WriteAllText(Atmfile, json);
        }
        private static List<AtmLocattion> AtmLoadData()
        {
            if (File.Exists(Atmfile))
            {
                var file=new FileInfo(Atmfile);
                if(file.Length > 0)
                {
                    var json = File.ReadAllText(Atmfile);
                    return JsonConvert.DeserializeObject<List<AtmLocattion>>(json);
                }
            }
            return new List<AtmLocattion>();
        }
        private static void AddAtm()
        {
            AtmLocations=AtmLoadData();
            Console.WriteLine("enter the ATM location");
            string atmLocation=Console.ReadLine();
            Console.WriteLine("enter the ATM id");
            int atmID=int.Parse(Console.ReadLine());
            if(AtmLocations.Any(a=> a.AtmID == atmID))
            {
                Console.WriteLine("the ATM with this ID exist");
                return;
            }
            AtmLocations.Add(new AtmLocattion(atmLocation, atmID));
            AtmSaveData();
            Console.WriteLine($"the ATM with {atmID} added successfully\n");
            Manager.RollBack();
        }
        private static void DeleteAtm()
        {
            AtmLocations = AtmLoadData();
            Console.WriteLine("enter the Atm ID to remove");
            int id=int.Parse(Console.ReadLine());
            AtmLocattion atm = AtmLocations.FirstOrDefault(a => a.AtmID == id);

            if (atm != null)
            {
                AtmLocations.Remove(atm);
                AtmSaveData();
                Console.WriteLine($"the ATM with {atm.AtmID} deleted successfully");
            }
            else
            {
                Console.WriteLine("invalid ATM ID try again");
                DeleteAtm();
            }
            Manager.RollBack();
        }
        public static void ShowAtmLocation()
        {
            AtmLocations = AtmLoadData();
            foreach (var atm in AtmLocations)
                Console.WriteLine(atm.AtmLocation);
        }
        public static void Atm()
        {
            Client.Login();
            Console.WriteLine("1- Wihdraw\n2- Deposit\n3- Transfer\n4- Check Balance\nselect option from ( 1 - 2 - 3 - 4  )");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    Client.Withdraw();
                    break;
                case 2:
                    Client.Deposit();
                    break;
                case 3:
                    Client.TransferTo();
                    break;
                case 4:
                    Client.GetBalance();
                    break;
                default:
                    Console.WriteLine("invalid input try again");
                    Atm();
                    break;
            }
        }
        public static void BankSystem()
        {
            Console.WriteLine("1- Client\n2- Employee\n3- Manager\nselect option from ( 1 - 2 - 3 )");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    Client.Login();
                    ClientFunc();
                    break;
                case 2:
                    Employee.Login();
                    EmployeeFunc();
                    break;
                case 3:
                    Manager.Login();
                    ManagerFunc();
                    break;
                default:
                    Console.WriteLine("invalid input try again");
                    BankSystem();
                    break;
            }
        }
        public static void ManagerFunc()
        {
            Console.WriteLine("1- Add employee\n2- Remove employee\n3- Add Atm\n4- Remove Atm\n5- update salary for employee\n Select option(1-2-3-4-5)");
            int managerInput = int.Parse(Console.ReadLine());

            switch (managerInput)
            {
                case 1:

                    Manager.AddEmployee();
                    break;
                case 2:
                    Manager.DeleteEmployee();
                    break;
                    case 3:
                    Bank.AddAtm();
                    break; 
                case 4:
                    Bank.DeleteAtm();
                    break;
                case 5:
                    Manager.UpdateSalary();
                    break;
                default:
                    Console.WriteLine("invalid input try again ");
                    ManagerFunc();
                    break;
            }
        }
        public static void EmployeeFunc()
        {
            Console.WriteLine("1- Add Account\n2- Delete Account\n3- Withdraw\n4- Deposit\n5- Transfer \n6- Show Client info");
            int empInput = int.Parse(Console.ReadLine());
            switch (empInput)
            {
                case 1:
                    Employee.AddClient();
                    break;

                case 2:
                    Employee.DeleteClient();
                    break;

                case 3:
                    Employee.Withdraw();

                    break;

                case 4:
                    Employee.Deposit();
                    break;

                case 5:

                    Employee.TransferTo();

                    break;

                case 6:

                    Employee.PrintClientInfo();
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    EmployeeFunc();
                    break;
            }
        }
        public static void ClientFunc()
        {
            Console.WriteLine("1-Transfer\n2-Show Balance\n3-ATM Locations\n4-change or password\nselect option(1-2-3-4-5)");

            int clientInput = int.Parse(Console.ReadLine());

            switch (clientInput)
            {
                case 1:
                    Client.TransferTo();
                    break;
                case 2:
                    Client.GetBalance();
                    break;
                case 3:
                    ShowAtmLocation();
                    break;
                case 4:
                    Client.UpdatePassOrID();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    ClientFunc();
                    break;
            }
        }
    }
}
