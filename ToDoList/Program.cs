using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ToDoList
{
    class Program
    {
        public static List<string> ToDoList { get; private set; }

        static void Main(string[] args)
        {

            List<string> ToDoList;
            ToDoList = ToDoListHandler.DataSetRead();
            Console.Title = "To Do List";

            // Creates array of options
            string[] options = new string[4]
                {"View", "Add", "Save", "Remove"};
            Menu(options, ToDoList);

        }
        private static void Menu(string[] options, List<string> ToDoList)
        {
            // Lists options in array
            Console.WriteLine(" Options");
            int rank = 1;
            foreach (string option in options)
            {
                Console.WriteLine(" " + rank + ") " + option);
                rank++;
            }
            // Requests input
            Console.Write(" Please make selection: ");

            // Verifies validity of input
            string input = Console.ReadLine();
            int number;
            bool success = int.TryParse(input, out number);
            if ((success) && number < 5)
            {
                // Valid input
                int caseSwitch = number;
                switch (caseSwitch)
                {
                    case 1:
                        ToDoListHandler.ViewList(ToDoList);
                        Menu(options, ToDoList);
                        break;
                    case 2:
                        ToDoListHandler.AddToList(ToDoList);
                        Menu(options, ToDoList);
                        break;
                    case 3:
                        ToDoListHandler.SaveList(ToDoList);
                        Menu(options, ToDoList);
                        break;
                    case 4:
                        ToDoListHandler.RemoveItem(ToDoList);
                        Menu(options, ToDoList);
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            }
            else
            {
                // String was input instead of integer
                Console.WriteLine("\n" + "'" + input + "'" + " is an invalid selection. Please try again.\n");
                Menu(options, ToDoList);
            }
        }
    }
}
