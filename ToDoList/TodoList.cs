using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class TodoList
{
    private List<Task> tasks;

    public TodoList()
    {
        tasks = new List<Task>();
    }

    // Add a new task
    public void AddTask(string title, DateTime dueDate, string project)
    {
        tasks.Add(new Task(title, dueDate, project));
    }

    // Remove a task by ID
    public void RemoveTask(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Task with ID {id} removed successfully.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Task with ID {id} not found.");
        }
    }

    // Edit a task by ID
    public void EditTask(int id, string newTitle, DateTime newDueDate, string newProject)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.Title = newTitle;
            task.DueDate = newDueDate;
            task.Project = newProject;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Task with ID {id} updated successfully.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Task with ID {id} not found.");
        }
    }

    // Mark a task as done
    public void MarkAsDone(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.IsDone = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Task with ID {id} marked as done.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Task with ID {id} not found.");
        }
    }

    // Display tasks
    public void DisplayTasks(string sortBy = "none")
    {
        IEnumerable<Task> sortedTasks;

        switch (sortBy.ToLower())
        {
            case "date":
                sortedTasks = tasks.OrderBy(t => t.DueDate);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new string('=', 33));
                Console.WriteLine("\n+++ Tasks Sorted by Due Date +++");
                Console.WriteLine(new string('=', 33));
                Console.ResetColor();
                break;

            case "project":
                sortedTasks = tasks.OrderBy(t => t.Project);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new string('=', 30));
                Console.WriteLine("\n+++Tasks Sorted by Project +++");
                Console.WriteLine(new string('=', 30));
                Console.ResetColor();
                break;

            default: // Unsorted
                sortedTasks = tasks;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("\n+++ All tasks +++");
                Console.WriteLine(new string('=', 20));
                Console.ResetColor();
                break;
        }

        Console.WriteLine(new string('-', 100));
        Console.WriteLine(
            "ID".PadRight(10)  + 
            "Title".PadRight(30)  +
            "Due Date".PadRight(15)  + "Status".PadRight(20) + "Project".PadRight(10));
        Console.WriteLine(new string('-', 100));
     
       foreach (var task in sortedTasks)
        {
           if (!task.IsDone) Console.ForegroundColor = ConsoleColor.DarkYellow; // Highlight pending tasks
            else Console.ForegroundColor = ConsoleColor.Gray; // Highlight completed tasks

           Console.WriteLine(task.ToString());
           Console.ResetColor();
       }

        Console.WriteLine(new string('-', 100));
    }


    //JSON
    public void LoadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    // If the file is empty, initialize an empty list and inform the user
                    Console.WriteLine("The file is empty. Starting with an empty task list.");
                    tasks = new List<Task>();
                }
                else
                {
                    tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
                    
                }
            }
            else
            {
                // If the file doesn't exist, initialize an empty task list
                Console.WriteLine("File not found. Starting with an empty task list.");
                tasks = new List<Task>();
            }
        }
        catch (Exception ex)
        {
            // Handle any errors during file reading or deserialization
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error loading from file: {ex.Message}");
            Console.ResetColor();

            // Initialize an empty task list as fallback
            tasks = new List<Task>();
        }
    }
    
        public void SaveToFile(string filePath)
         {
        try
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Tasks saved to file: {filePath}");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error saving to file: {ex.Message}");
            Console.ResetColor();
        }
    }

}
