using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ToDoList5._2
{
	class ToDoListHandler
	{
		public static object inputNote
		{
			get;
			private set;
		}

		// sets up Item for List<t>
		public class Item : IEquatable<Item>
		{
			public string ItemName
			{
				get;
				set;
			}

			public int ItemId
			{
				get;
				set;
			}

			// Sets string to contain note and number
			public override string ToString()
			{
				return "ID: " + ItemId + "   Note: " + ItemName;
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
					return false;
				Item objAsItem = obj as Item;
				if (objAsItem == null)
					return false;
				else
					return Equals(objAsItem);
			}

			public override int GetHashCode()
			{
				return ItemId;
			}

			public bool Equals(Item other)
			{
				if (other == null)
					return false;
				return (this.ItemId.Equals(other.ItemId));
			}
		}

		public static List<string> DataSetRead()
		{
			string path = "C:\\Users\\User\\Desktop\\ToDoList.txt";
			// Verifies file exists
			if (File.Exists(path))
			{
				try
				{
					// Places list in array to initialize
					List<string> lines = File.ReadAllLines(path).ToList();
					return lines;
				}
				catch (Exception error)
				{
					Console.WriteLine(error.Message);
				}
			}

			// File not found
			return new List<string>();
		}

		// View List
		public static void ViewList(List<string> ToDoList)
		{
			Console.WriteLine();
			int num = 0;
			// items.Add(new Item() { ItemName = inputNote, ItemId = num++ });
			foreach (var item in ToDoList)
			{
				Console.WriteLine("ID: " + num++ + "   Note: " + item);
			}
		}

		// Add to
		public static void AddToList(List<string> ToDoList)
		{
			// Create a list of items.
			List<Item> items = new List<Item>();
			int num = 0;
			// Creates a loop enabling multiple add entries
			while (true)
			{
				//
				Console.WriteLine("Enter note. Press 'enter' to add additional. Type 'exit' to end"); // Prompt
				var input = Console.ReadLine(); // Get string from user
				// Creates an option to exit out of loop
				if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Input received");
					break;
				}

				// Inputs new notes into list
				var inputNote = input;
				ToDoList.Add(input);
				items.Add(new Item()
				{ItemName = inputNote, ItemId = num++});
				// This writes out the added items
				foreach (Item aItem in items)
				{
					Console.WriteLine(aItem);
				}
			}
		}

		// Saves list to txt file
		public static void SaveList(List<string> ToDoList)
		{
			string path = "C:\\Users\\User\\Desktop\\ToDoList.txt";
			if (File.Exists(path))
			{
				Console.WriteLine("We found file: " + path);
				try
				{
					using (StreamWriter writer = new StreamWriter(path))
					{
						foreach (var item in ToDoList)
						{
							writer.WriteLine(item);
						}
					}

					//Confirms file was saved
					Console.WriteLine("File Written: " + path);
				}
				catch (Exception error)
				{
					Console.WriteLine(error.Message);
				}
			}
			else
			{
				Console.WriteLine("File not found. Please check path.");
			}

			Console.ReadKey();
		}

		public static void RemoveItem(List<string> ToDoList)
		{
			// Shows updated list with new ID numbers            
			Console.WriteLine();
			int num = 0;
			foreach (var item in ToDoList)
			{
				Console.WriteLine("ID: " + num++ + "   Note: " + item);
			}

			// Requests input
			Console.WriteLine("Please input ID number of Note you want to remove: ");
			// Verifies validity of input
			string remove = Console.ReadLine();
			int removeID;
			bool success = int.TryParse(remove, out removeID);
			if (success)
			{
				if (removeID <= ToDoList.Count && removeID >= 0)
				{
					ToDoList.RemoveAt(removeID);
				}
				else
				{
					// RemoveID is out of range
					Console.WriteLine("\n" + "'" + remove + "'" + " is an invalid selection. Please try again.\n");
				}
			}
			else
			{
				// String was input instead of integer
				Console.WriteLine("\n" + "'" + remove + "'" + " is an invalid selection. Please try again.\n");
			}
		}
	}
}
