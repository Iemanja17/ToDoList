Title and Key Idea

Title: "Building a To-Do List Application in C#: From Concept to Solution"
Key Idea: 
I created a fully functional, text-based To-Do List application in C#, showcasing meticulous planning, coding techniques, and problem-solving to meet user needs effectively.
___________________________________________________________________________________

Problem Statement
 "What Problem Was I Solving?"

	• Users needed a reliable tool to organize tasks efficiently.
	• Required features: Create, edit, mark as done, remove tasks, save and load to file.
	• Challenges: Command-line interface, persistence, user-friendly design.
________________________________________________________________________________

 Project Plan
 "How I Planned the Project"

	• Step 1: Understand requirements:
		○ Task structure (title, due date, status, project).
		○ CRUD operations (Create, Read, Update, Delete).
		○ File persistence for task data.
	• Step 2: Design classes and methods:
		○ Classes: Task, TodoList, Program.
		○ Properties: Title, DueDate, IsDone, Project.
		○ Methods: Add, Edit, MarkAsDone, Remove.
	• Step 3:UML diagram for logical flow.
________________________________________________________________________________________

Solution Architecture
 "How I Built the Application"

	1. Class: Task
		○ Represented each to-do item with attributes like Title, DueDate, IsDone, Project.
		○ Ensured ToString() method for proper display formatting.
	2. Class: TodoList
		○ Managed task collection and implemented core operations (Add, Edit, Remove, MarkAsDone).
		○ Used sorting for tasks by date or project.
		○ Implemented file handling methods (SaveToFile, LoadFromFile) using JSON serialization.
	3. Class: Program
		○ CLI logic enabled user interaction with options like 1. Add Task, 2. Edit Task, etc.
		○ Validated input (e.g., correct date format via DateTime.TryParseExact).
_________________________________________________________________________________________

 Features and Functionality
"What Does the Application Do?"

	• Core Features:
		○ Add tasks with title, due date, and project.
		○ Edit and update tasks.
		○ Mark tasks as done with visual color cues (pending in red, done in green).
		○ Remove tasks.
		○ Display tasks sorted by date or project.
	• User-Friendly Interface:
		○ Text-based command-line interaction.
		○ Clear menus and prompts for users.
	• Persistence:
		○ Task list saved to file.
		○ Application restores the previous state on restart.
________________________________________________________________________________________

Implementation Details
 "How I Solved Key Challenges"

	1. Designing Classes and Structure
Challenge: Define a structure that models tasks with all required attributes while supporting operations like adding, editing, deleting, and marking tasks.

Solution:

Class Design:

A Task class was created to represent individual tasks with properties such as Title, DueDate, Project, IsDone, and an auto-incrementing Id for unique identification.

The TodoList class was designed as a manager to handle the list of tasks and operations such as adding, editing, sorting, and removing tasks.

Methods:

The AddTask method dynamically creates tasks and assigns IDs.

The EditTask method allows modification of task properties.

The RemoveTask method ensures tasks are deleted based on their unique IDs.

Outcome: A modular class structure that encapsulates all core functionality in an organized manner, enabling extensibility and scalability.

	2. Handling Input Validation and Formatting
Challenge: Ensure that user inputs, such as dates and IDs, are valid and correctly formatted to avoid runtime errors or corrupted data.

Solution:

Date Validation:

Used DateTime.TryParseExact to validate user input for due dates in the format yyyy-MM-dd. This avoids parsing errors and prompts the user until they provide valid input.

Error Handling for IDs:

Ensured that IDs provided by users for tasks (edit, remove, mark as done) were parsed as integers using int.TryParse.

Added fallback cases where invalid IDs or formats were detected, displaying appropriate error messages to users.

Outcome: The application gracefully handles incorrect input, ensuring a robust and user-friendly experience.

3. Sorting and Displaying Tasks

Challenge: Allow tasks to be displayed in multiple views (unsorted, sorted by due date, and sorted by project), while clearly distinguishing between pending and completed tasks.

Solution:

Sorting Logic:

Used LINQ (OrderBy) to sort tasks dynamically based on either due date or project.

Provided an unsorted view for tasks in their original order.

Color-Coded Display:

Applied Console.ForegroundColor to highlight pending tasks in red and completed tasks in green.

This made it visually easy for users to distinguish between task statuses.

Outcome: An intuitive and visually organized task list view, accommodating different sorting preferences.

4. File Persistence

Challenge: Save and restore the task list between application runs to ensure data persistence.

Solution:

JSON Serialization:

Implemented SaveToFile to serialize the list of tasks into a JSON file. This ensures compatibility, readability, and ease of use.

Used LoadFromFile to deserialize the JSON file, restoring the task list to its previous state on startup.

Error Handling:

Checked if the file existed before attempting to load data.

Validated file content to handle empty or malformed files, defaulting to an empty task list when necessary.

Outcome: Persistent storage that reliably saves and restores data, even in cases of user errors or file corruption.

_________________________________________________________________________________


![image](https://github.com/user-attachments/assets/23697c00-c29e-463a-b1d4-ea8ee19e0472)
