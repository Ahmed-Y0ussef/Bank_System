using System.Diagnostics;

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
            Console.WriteLine("1-Bank System\n2-ATM\nselect option from ( 1 - 2 )");
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
            int userInput=int.Parse(Console.ReadLine());
            switch(userInput)
            {
                case 1:

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
                    Manager();
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

        }

        //Manger
        static void Manager()
        {
            Login();
            Console.WriteLine("choose add or remove employee");
            string managerInput = Console.ReadLine();
            switch(managerInput)
            {
                case "add":
                    Console.WriteLine("enter name of the employee");
                    string empName = Console.ReadLine();
                    Console.WriteLine("enter employee id");
                    int empId = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter user name for this employee");
                    string empUserName = Console.ReadLine();
                    Console.WriteLine("enter password for the employee");
                    string empPassword = Console.ReadLine();
                    Employee emp= new Employee(empName, empPassword);
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

        //Client
        static void Client( )
        {
            Login();
            Console.WriteLine("1-withdraw\n2-deposite\n3-transfer\n4-nearest atm location");
        }
    }
}