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
        const string FilePath = "C:\\Users\\drnad\\Source\\Repos\\Bank_System\\employee.json";
        public static List<Employee> employees;  //data member
       
        private static List<Employee> LoadData()
        {
            if (File.Exists(FilePath))
            {
                var file = new FileInfo(FilePath);
                if (file.Length > 0)
                {
                    string json = File.ReadAllText(FilePath);
                    return JsonConvert.DeserializeObject<List<Employee>>(json);
                }
            }
            return new List<Employee>();
        }
        private static void SaveData()
        {
            var json= JsonConvert.SerializeObject(employees,Formatting.Indented);
            File.WriteAllText(FilePath, json);

        }
        public static void AddEmployee(Employee employee)
        {
            if (employees.Any(e => e.Id == employee.Id))
            {
                Console.WriteLine("Employee already exists.");
                return;
            }

            employees.Add(employee);
            SaveData();
            Console.WriteLine("Employee added successfully.");
        }

        public static void DeleteEmployee(int id) 
        { 

            Employee emp=employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
                SaveData() ;
                Console.WriteLine($"Employee with ID {id} removed successfully.");

            }
            else
                Console.WriteLine($"Employee not found");
        }
    }
}
