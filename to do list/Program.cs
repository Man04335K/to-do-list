using System;
using System.IO;

class ToDoListApp
{
    static string filePath = "to-do_list.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nTo-Do List Application");
            Console.WriteLine("1. Add Task to the file");
            Console.WriteLine("2. View Tasks from the file");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    Console.WriteLine("Exiting application.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2 or 3.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter a new task you want to add in To-Do list: ");
        string task = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(task);
            }
            Console.WriteLine("Task added in To-Do list successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }

    static void ViewTasks()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] tasks = File.ReadAllLines(filePath);

                if (tasks.Length == 0)
                {
                    Console.WriteLine("No tasks available.");
                }
                else
                {
                    Console.WriteLine("\nYour Tasks:");
                    foreach (string task in tasks)
                    {
                        Console.WriteLine("- " + task);
                    }
                }
            }
            else
            {
                Console.WriteLine("No file found, Please first write the take for viewing it.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }
    }
}
