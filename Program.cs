using System.Diagnostics;
using Bank_System;
using Newtonsoft.Json;
using Spectre.Console;
namespace Main
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();
            //Console.Title = "Alpha Mind";
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Console.ForegroundColor = ConsoleColor.Black;

            // Welcome
            AnsiConsole.Write(new FigletText("Welcom To Our Bank").Color(Color.Yellow).Centered());
            //Bank System or ATM
            Console.WriteLine("1- Bank System\n2- ATM\nselect option from ( 1 - 2 )");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    Bank.BankSystem();
                    break;
                case 2:
                    Bank.Atm();
                    break;
                default:
                    Console.WriteLine("invalid input try again");
                    Main();
                    break;
            }
        }  
    }
}