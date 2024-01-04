using Main;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public class Manager
    {
        const string FilePath = "C:\\Users\\drnad\\Source\\Repos\\Bank_System\\employee.json";
        public List<Employee> employees ; //data member
        public Manager() 
        { 
            employees=LoadData(); //this constructor is ensuring that when a Manager object is created,
                                  //its employees list is populated with some initial data
        } 
        private List<Employee> LoadData()
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
        private void SaveData()
        {
            var json= JsonConvert.SerializeObject(employees,Formatting.Indented);
            File.WriteAllText(FilePath, json);

        }
        public void AddEmployee(Employee employee)
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
        public void DeleteEmployee(int id) 
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
