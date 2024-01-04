using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Employee : Person
    {
        //Atttibutes

        public double Salary { get; set; }

        const string filePath = "C:\\Users\\drnad\\Source\\Repos\\Bank_System\\clients.json";
        public List<Client> Clients;
        //Static Attribute
        static int EmpCount { get; set; }

        //Constructor
        public Employee(int id, string name, string password, double salary) : base(id, name, password)
        {

            Salary = salary;
            Clients = LoadData();

        }

        //Abstracted Method
        protected override void idIncrement()
        {
            EmpCount++;
            Id = EmpCount;

        }
        //Methods

        private List<Client> LoadData()
        {
            if (File.Exists(filePath))
            {
                var file = new FileInfo(filePath);
                if (file.Length > 0)
                {
                    string json = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<List<Client>>(json);
                }
            }

            return new List<Client>();
        }

        private void SaveData()
        {
            var Json = JsonConvert.SerializeObject(Clients, Formatting.Indented);
            File.WriteAllText(filePath, Json);

        }

        public void AddClient(string name, string pass, double balance, bool isDebit)
        {
            if (Clients.Any(c => c.Name == name))
            {
                Console.WriteLine("Client already exists.");
                return;
            }
            Client newClient = new Client(name, pass, balance, isDebit)
            {
                Name = name,
                Password = pass,
                Balance = balance,
                IsDebit = isDebit
            };

            Clients.Add(newClient);
            idIncrement();
            SaveData();
            Console.WriteLine("Client added successfully.");
        }

        public void DeleteClient(string name)
        {
            Client client = Clients.FirstOrDefault(c => c.Name == name);
            if (client != null)
            {
                Clients.Remove(client);
                SaveData();
                Console.WriteLine($"Client {name} is removed successfully.");

            }
            else
                Console.WriteLine($"Employee not found");
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
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Salary: {Salary}");

            Console.WriteLine("Clients:");
            foreach (var c in Clients)
            {
                Console.WriteLine($" Client Name: {c.Name}, Balance: {c.Balance}, Account Type: {c.AccountType()}");
            }


        }
    }
}
