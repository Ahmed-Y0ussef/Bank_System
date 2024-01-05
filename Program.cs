using System.Diagnostics;
using Bank_System;
using Newtonsoft.Json;

namespace Main
{
    internal class Program
    {
        static void Main()
        {
            
            // Welcome
            Console.WriteLine(
@"
  *       *       *  * * * *   *          * * * *     * * * *         *       *      * * * *     
   *     * *     *   *         *         *           *       *       * *     * *     *               
    *   *   *   *    * * * *   *        *           *         *     *   *   *   *    * * * *         
     * *     * *     *         *         *           *       *     *     * *     *   *               
      *       *      * * * *   * * * *    * * * *     * * * *     *       *       *  * * * *         

 * * * *    * * * *          * * * *    *     *  * * * *       * * * *       *      *     *  *   *
    *      *       *        *       *   *     *  *      *      *      *     * *     * *   *  *  *
    *     *         *      *         *  *     *  * * * *       * * * *     *   *    *  *  *  * *   
    *      *       *        *       *   *     *  *    *        *      *   * * * *   *   * *  *  *
    *       * * * *          * * * *     * * *   *     *       * * * *   *       *  *     *  *   *
            ");


            
            //Bank System or ATM
            Console.WriteLine("1- Bank System\n2- ATM\nselect option from ( 1 - 2 )");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    BankSystem();
                    break;
                case 2:
                    Atm();
                    break;
                default:
                    Console.WriteLine("invalid input try again");
                    Main();
                    break;
            }
        }

        //ATM
        static void Atm()
        {
            Login();
            Console.WriteLine("1- Wihdraw\n2- Deposit\n3- Transfer\n4- Check Balance\n5- Shaw my informaion\nselect option from ( 1 - 2 - 3 - 4 - 5 )");
            int userInput=int.Parse(Console.ReadLine());
            switch(userInput)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("invalid input try again");
                    Atm();
                    break;
            }
        }

        //Bank System
        static void BankSystem()
        {
            Console.WriteLine("1- Client\n2- Employee\n3- Manager\nselect option from ( 1 - 2 - 3 )");
            int userInput=int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    Client();
                    break;
                case 2:
                    Emp();
                    break;
                case 3:
                    Manage();
                    break;
                default:
                    Console.WriteLine("invalid input try again");
                    BankSystem();
                    break;
            }
        }

        //Login
        static void Login()
        {
            Console.WriteLine("enter your id:");
            int id=int.Parse(Console.ReadLine());
            Console.WriteLine("enter your password:");
            string password =Console.ReadLine();
            if (Manager.LoadData().Any(x => x.Id == id) && Manager.LoadData().Any(e=> e.Password==password))
            {
                Console.WriteLine("login successfully");
            }
            else
            {
                Console.WriteLine("invalid ID or password try again");
                Login();
            }

        }
        
        //Manger
        static void Manage()
        {
            Login();
            Console.WriteLine("1-add employee\n2-remove employee\nselect option(1-2)");
            int managerInput = int.Parse(Console.ReadLine());
            switch(managerInput)
            {
                case 1:

                    Console.WriteLine("enter name of the employee");
                    string empName = Console.ReadLine();
                    Console.WriteLine("enter password for the employee");
                    string empPassword = Console.ReadLine();
                    Console.WriteLine("enter id for the Employee");
                    int empId= int.Parse(Console.ReadLine());
                    Employee emp= new Employee(empId,empName, empPassword);
                   Manager.AddEmployee(emp);
                    
                    break;
                case 2:
                    Console.WriteLine("enter employee id");
                    int empIdDeleted = int.Parse(Console.ReadLine());
                    Manager.DeleteEmployee(empIdDeleted);
                    break;
                default: 
                    Console.WriteLine("invalid input try again ");
                    Manage();
                    break;
            }
        }
        static void Emp()
        {
            Login();
            Console.WriteLine("1-add acount\n2-delete acount\n3-withdraw\n4-deposit\n5-transfer");
            string empInput=Console.ReadLine();
            switch(empInput) 
            {
                case "add acount":

                    break;
                case "delete acount":

                    break;
                case "withdraw":

                    break;
                case "deposit":

                    break;
                case "transfer":

                    break;
                    default : Console.WriteLine("invalid input tray again");
                    Emp(); 
                    break;
            }
        }

        //Client
        static void Client( )
        {
            Login();
            Console.WriteLine("1-withdraw\n2-deposite\n3-transfer\n4-nearest atm location \n5-show Info");
        }
    }
}