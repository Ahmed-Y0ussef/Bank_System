using Main;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public static class Manager
    {
        const string FilePathEmp = @"D:\ITI\\Bank_System\employee.json";
        const string FilePathManager = @"D:\ITI\\Bank_System\Managars.json";

        public static List<Person> Managers = new List<Person>();
        public static List<Employee> employees ; //data member
        
        public static List<Employee> LoadDataEmp()
        {
            if (File.Exists(FilePathEmp))
            {
                var file = new FileInfo(FilePathEmp);
                if (file.Length > 0)
                { 
                    string json = File.ReadAllText(FilePathEmp);
                    return JsonConvert.DeserializeObject<List<Employee>>(json);
                }
            }
            return new List<Employee>();
        }
        public static List<Person> LoadDataManger()
        {
            if (File.Exists(FilePathManager))
            {
                var file = new FileInfo(FilePathManager);
                if (file.Length > 0)
                {
                    string json = File.ReadAllText(FilePathManager);
                    return JsonConvert.DeserializeObject<List<Person>>(json);
                }
            }
            return new List<Person>();
        }
        private static void SaveData()
        {
            var json = JsonConvert.SerializeObject(Managers, Formatting.Indented);
            File.WriteAllText(FilePathManager, json);

        }
        public static void AddEmployee(Employee employee)
        { 
            Managers=LoadDataManger();
            if (Managers.Any(e => e.Id == employee.Id))
            {
                Console.WriteLine("Employee already exists.");
                return;
            }
            Managers.Add(employee);
            SaveData();
            Console.WriteLine("Employee added successfully.");
        }

        public static void DeleteEmployee(int id)
        {
            employees = LoadDataEmp();
            Person emp = Managers.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                Managers.Remove(emp);
                SaveData();
                Console.WriteLine($"Employee with ID {id} removed successfully.");

            }
            else
                Console.WriteLine($"Employee not found");
        }
    }
}
