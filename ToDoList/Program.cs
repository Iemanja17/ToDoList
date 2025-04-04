using System;

class Program
{
    static void Main()
    {
        TodoList todoList = new TodoList();
        string filePath = "tasks.json";

        // Load tasks from file at startup
        todoList.LoadFromFile(filePath);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- To-Do List Application ---");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nMAIN MENU");
            Console.ResetColor();
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Edit Task");
            Console.WriteLine("3. Remove Task by ID");
            Console.WriteLine("4. Mark Task as Done");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nDISPLAY MENU");
            Console.ResetColor();
            Console.WriteLine("5. Display All Task");
            Console.WriteLine("6. Display Tasks (Sorted by Date)");
            Console.WriteLine("7. Display Tasks (Sorted by Project)");
            Console.WriteLine("8. Save & Exit");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Choose an option: ");
            Console.ResetColor();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": // Add Task
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter Due Date (yyyy-MM-dd): ");
                    DateTime dueDate;
                    while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dueDate))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
                        Console.ResetColor();
                        Console.Write("Enter Due Date (yyyy-MM-dd): ");
                    }

                    Console.Write("Enter Project: ");
                    string project = Console.ReadLine();

                    todoList.AddTask(title, dueDate, project);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task added successfully.");
                    break;

                case "2": // Edit Task
                    todoList.DisplayTasks();
                    Console.Write("Enter Task ID to Edit: ");
                    int editId = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Title: ");
                    string newTitle = Console.ReadLine();
                    Console.Write("Enter New Due Date (yyyy-MM-dd): ");
                    DateTime newDueDate; //= DateTime.Parse(Console.ReadLine());
                    while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", provider: null, System.Globalization.DateTimeStyles.None, out newDueDate))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
                        Console.ResetColor();
                        Console.Write("Enter Due Date (yyyy-MM-dd): ");
                    }
                    Console.Write("Enter New Project: ");
                    string newProject = Console.ReadLine();
                    todoList.EditTask(editId, newTitle, newDueDate, newProject);
                    break;

                case "3": // Remove Task
                    todoList.DisplayTasks();
                    Console.Write("Enter Task ID to Remove: ");
                    int idToRemove = int.Parse(Console.ReadLine());
                    todoList.RemoveTask(idToRemove);
                    break;

                case "4": // Mark Task as Done
                    todoList.DisplayTasks();
                    Console.Write("Enter Task ID to Mark as Done: ");
                    int doneId = int.Parse(Console.ReadLine());
                    todoList.MarkAsDone(doneId);
                    break;

                case "5": // Display Unsorted Tasks
                    todoList.DisplayTasks();
                    break;

                case "6": // Display Tasks Sorted by Date
                    todoList.DisplayTasks("date");
                    break;

                case "7": // Display Tasks Sorted by Project
                    todoList.DisplayTasks("project");
                    break;

                case "8": // Save and Exit
                    todoList.SaveToFile(filePath);
                    Console.WriteLine("Tasks saved. Exiting...");
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
