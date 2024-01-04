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
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
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
            int userInput = int.Parse(Console.ReadLine());
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
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter your password:");
            string password = Console.ReadLine();

        }

        //Manger
        static void Manage()
        {
            Login();
            Console.WriteLine("1- Add employee\n2- Remove employee\n Select option(1-2)");
            int managerInput = int.Parse(Console.ReadLine());

            switch (managerInput)
            {
                case 1:
                    Console.WriteLine("enter name of the employee");
                    string empName = Console.ReadLine();
                    Console.WriteLine("enter password for the employee");
                    string empPassword = Console.ReadLine();
                    Console.WriteLine("enter salary for the employee");
                    double empSalary = double.Parse(Console.ReadLine());

                    Console.WriteLine("enter id for the Employee");
                    int empId = int.Parse(Console.ReadLine());
                    Employee emp = new Employee(empId, empName, empPassword, empSalary);
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
            Employee employee = new Employee("Ahmed", "123", 50000);
            Login();
            Console.WriteLine("1- Add Account\n2- Delete Account\n3- Withdraw\n4- Deposit\n5- Transfer \n6- Show employee info");
            int empInput = int.Parse(Console.ReadLine());
            switch (empInput)
            {
                case 1:
                    Console.Write("Enter client Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter client Password: ");
                    string pass = Console.ReadLine();
                    Console.Write("Enter client Balance: ");
                    if (double.TryParse(Console.ReadLine(), out double balance))
                    {
                        Console.Write("Enter account type (1 for Debit, 2 for Credit): ");
                        if (int.TryParse(Console.ReadLine(), out int accountType))
                        {
                            bool isDebit = (accountType == 1);
                            employee.AddClient(name, pass, balance, isDebit);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for account type. Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for 'Balance'. Try again.");
                    }
                    break;

                case 2:

                    Console.Write("Enter client name to delete: ");
                    string clientNameToDelete = Console.ReadLine();
                    employee.DeleteClient(clientNameToDelete);
                    break;

                case 3:

                    Console.Write("Enter client name for withdrawal: ");
                    string withdrawClientName = Console.ReadLine();
                    Client withdrawClient = employee.Clients.FirstOrDefault(c => c.Name == withdrawClientName);
                    if (withdrawClient != null)
                    {
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawalAmount;
                        if (double.TryParse(Console.ReadLine(), out withdrawalAmount))
                        {
                            employee.Withdraw(withdrawalAmount, ref withdrawClient);
                            Console.WriteLine($"Withdrawal of {withdrawalAmount:C} for {withdrawClientName} successful.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for withdrawal amount. Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Client {withdrawClientName} not found.");
                    }
                    break;

                case 4:
                    Console.Write("Enter client name for deposit: ");
                    string depositClientName = Console.ReadLine();
                    Client depositClient = employee.Clients.FirstOrDefault(c => c.Name == depositClientName);
                    if (depositClient != null)
                    {
                        Console.Write("Enter deposit amount: ");
                        double depositAmount;
                        if (double.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            employee.Deposit(depositAmount, ref depositClient);
                            Console.WriteLine($"Deposit of {depositAmount:C} for {depositClientName} successful.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for deposit amount. Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Client {depositClientName} not found.");
                    }
                    break;

                case 5:

                    Console.Write("Enter source client name for transfer: ");
                    string sourceClientName = Console.ReadLine();
                    Client sourceClient = employee.Clients.FirstOrDefault(c => c.Name == sourceClientName);
                    if (sourceClient != null)
                    {
                        Console.Write("Enter target client name for transfer: ");
                        string targetClientName = Console.ReadLine();
                        Client targetClient = employee.Clients.FirstOrDefault(c => c.Name == targetClientName);
                        if (targetClient != null)
                        {
                            Console.Write("Enter transfer amount: ");
                            double transferAmount;
                            if (double.TryParse(Console.ReadLine(), out transferAmount))
                            {
                                employee.TransferTo(ref sourceClient, transferAmount, ref targetClient);
                                Console.WriteLine($"Transfer of {transferAmount:C} from {sourceClientName} to {targetClientName} successful.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for transfer amount. Try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Target client {targetClientName} not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Source client {sourceClientName} not found.");
                    }

                    break;

                case 6:

                    employee.PrintEmpInfo();
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    Emp();
                    break;
            }
        }

        //Client
        static void Client()
        {
            Client client = new Client(1,"Ahmed", "123", 5000, true);
            Login();
            Console.WriteLine("1- Withdraw\n2- Deposite\n3- Transfer\n4- Nearest atm location \n5- Show Info");

            int clientInput = int.Parse(Console.ReadLine());

            switch (clientInput)
            {
                case 1:

                    Console.Write("Enter withdrawal amount: ");
                    double withdrawalAmount;
                    if (double.TryParse(Console.ReadLine(), out withdrawalAmount))
                    {
                        client.Withdraw(withdrawalAmount);

                    }
                    else
                    {
                        Console.WriteLine("Invalid input for withdrawal amount.");
                    }
                    break;

                case 2:

                    Console.Write("Enter deposit amount: ");
                    double depositAmount;
                    if (double.TryParse(Console.ReadLine(), out depositAmount))
                    {
                        client.Deposit(depositAmount);

                    }
                    else
                    {
                        Console.WriteLine("Invalid input for deposit amount.");
                    }
                    break;

                case 3:

                    Console.Write("Enter target client name for transfer: ");
                    string targetClientName = Console.ReadLine();
                    Client targetClient = client.Clients.FirstOrDefault(c => c.Name == targetClientName);
                    if (targetClient != null)
                    {
                        Console.Write("Enter transfer amount: ");
                        double transferAmount;
                        if (double.TryParse(Console.ReadLine(), out transferAmount))
                        {
                            client.TransferTo(transferAmount, ref targetClient);

                        }
                        else
                        {
                            Console.WriteLine("Invalid input for transfer amount.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Target client {targetClientName} not found.");
                    }
                    break;

                case 4:
                    // Nearest ATM location
                    Console.WriteLine(" EKHFYYYYY MN WESHHHYYYY ");
                    break;

                //case 5:

                //    List<Client> clients = client.PrintInfo();
                //    foreach (var c in clients)
                //    {
                //        Console.WriteLine($"Name: {c.Name}, ID: {c.Id}, Balance: {c.Balance}, Account Type: {c.AccountType()}");
                //    }
                //    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}