using System.Diagnostics;

namespace Main
{
    internal class Program
    {
        static void Main()
        {
            //            Console.WriteLine(
            //@"
            //*       *       *  *******  *       ******    ******        *       *          *******    ******          ******    *     *  ******       ******       *      *     *  *   *
            // *     * *     *   *        *      *         *      *      * *     * *            *      *      *        *      *   *     *  *     *      *     *     * *     * *   *  *  *
            //  *   *   *   *    *******  *     *         *        *    *   *   *   *           *     *        *      *        *  *     *  ******       ******     *   *    *  *  *  ***   
            //   * *     * *     *        *      *         *      *    *     * *     *          *      *      *        *      *   *     *  *   *        *     *   *******   *   * *  *  *
            //    *       *      *******  ****    ******    ******    *       *       *         *       ******          ******     *****   *    *       ******   *       *  *     *  *   *
            //"
            //);


            Employee emp1=new Employee();
            client cli1=new client();
            Employee emp2=new Employee();
            client cli2 = new client();
            Console.WriteLine(emp1.Id);
            Console.WriteLine(emp2.Id);
            Console.WriteLine(cli1.Id);
            Console.WriteLine(cli2.Id);


            //Console.WriteLine("1-Bank Sysem\n2-ATM\nselect option from(1-2)");
            //int userInput = int.Parse(Console.ReadLine());
            //switch (userInput)
            //{
            //    case 1:
            //        BankSystem();
            //        break;
            //    case 2:
            //        Atm();
            //        break;
            //    default: 
            //        Console.WriteLine("invalid input try again");
            //        Main();
            //        break;
            //}



        }
        static void Atm()
        {
            Console.WriteLine("1-Credit\n2-Depit\nselect option from (1-2)");
            int userInput=int.Parse(Console.ReadLine());
            switch(userInput)
            {
                case 1:

                    break;
            }
        }
        static void BankSystem()
        {
            Console.WriteLine("1-manager\n2-employee\n3-client\nselect option from()1-3");
            int userInput=int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    Manager();
                    break;
                case 2:
                    Emp();
                    break;
                case 3:
                    Client();
                    break;
                default:
                    Console.WriteLine("invalid input try again");
                    BankSystem();
                    break;
            }
        }

        static void Login()
        {
            Console.WriteLine("enter your id ");
            int id=int.Parse(Console.ReadLine());
            Console.WriteLine("enter your password");
            string password =Console.ReadLine();

        }
        static void Manager()
        {
            Login();
            Console.WriteLine("choose add or remove employee");
            string managerInput=Console.ReadLine();
            switch(managerInput)
            {
                case "add":
                    Console.WriteLine("enter name of the employee");
                    string empName=Console.ReadLine();
                    Console.WriteLine("enter employee id");
                    int empId=int.Parse(Console.ReadLine());
                    Console.WriteLine("enter user name for this employee");
                    string empUserName =Console.ReadLine();
                    Console.WriteLine("enter password for the employee");
                    string empPassword=Console.ReadLine();
                    Employee emp= new Employee(empName,empUserName,empPassword);
                    break;
                case "remove":
                    Console.WriteLine("enter employee id");
                    int empIdDeleted = int.Parse(Console.ReadLine());
                    break;
                default: 
                    Console.WriteLine("invalid input try again ");
                    Manager();
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
        static void Client( )
        {
            Login();
            Console.WriteLine("1-with draw\n2-deposite\n3-transfer\n4-nearest atm location");
        }
    }
}