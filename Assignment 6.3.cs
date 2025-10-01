/* Assignment 6.3
You are developing a program to manage a call queue of customers using the Queue  in C#. The program creates a queue of callers and demonstrates the functionality of enqueueing elements into the queue and iterating over the elements and dequeuing.

Use linked lists.
Have a method to show the callers in the queue.
Use the Call class.
*/
namespace Assignment_6._3;

public class Program
{
    private static Queue<Call> callQueue = new Queue<Call>();

    public static void Main(string[] args)
    {
        // Enqueue example callers into the queue
        callQueue.Enqueue(new Call("Alice"));
        callQueue.Enqueue(new Call("Bob"));
        callQueue.Enqueue(new Call("Charlie"));
        callQueue.Enqueue(new Call("Diana"));

        ShowCallers(callQueue);
        while (ShowInputMenu()) { } // Loop until user chooses to exit
    }
    
    #region Call queue management methods
    public static void ShowCallers(Queue<Call> queue) // Method to show the callers in the queue
    {
        Console.WriteLine("Callers in the queue:");
        foreach (var caller in queue)
        {
            Console.WriteLine(caller);
        }
    }
    public static void DequeueCaller(Queue<Call> queue) // Method to dequeue a caller from the queue
    {
        if (queue.Count > 0)
        {
            Call caller = queue.Dequeue();
            Console.WriteLine($"Dequeued caller: {caller}");
        }
        else
        {
            Console.WriteLine("The call queue is empty.");
        }
    }
    public static void NewCaller() // Method to add a new caller to the queue
    {
        string callerName = GetUserInput("Enter caller name: ");
        Call newCaller = new Call(callerName);
        callQueue.Enqueue(newCaller);
        Console.WriteLine($"Added new caller: {newCaller}");
    }
    #endregion

    #region  Menu and utility methods
    // Input validation methods
    /// <summary> Prompts the user for input and ensures a non-empty string is returned. This is the non-generic overload.</summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <returns>A non-null, non-whitespace string from the user.</returns>
    private static string GetUserInput(string prompt)
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
    /// <summary> Prompts the user for input, validates it, and converts it to the specified type `T`.
    /// See https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics for more details.
    /// </summary>
    /// <typeparam name="T">The desired type (e.g., int, decimal, double), which must be parsable.</typeparam>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="parseErrorMessage">An optional custom error message to display on parsing failure.</param>
    /// <returns>A valid value of type `T` from the user.</returns>
    private static T GetUserInput<T>(string prompt, string? parseErrorMessage = null) where T : IParsable<T>
    {
        T? value;
        while (!T.TryParse(GetUserInput(prompt), null, out value)) // Calls GetUserInput() to get the raw user input first.
        {
            Console.WriteLine(parseErrorMessage ?? $"Invalid input. Please enter a valid {typeof(T).Name}.");
        }
        return value;
    }
    /// <summary> Displays the main menu and processes user choices.</summary>
    /// <returns>True if the program should continue, false otherwise.</returns>
    static bool ShowInputMenu()
    {
        Console.WriteLine($"\n--- Main Menu ---");
        Console.WriteLine("1. New Caller");
        Console.WriteLine("2. Dequeue Caller");
        Console.WriteLine("3. Show Callers");
        Console.WriteLine("4. Exit");

        int choice = GetUserInput<int>("Enter your choice: ", "Invalid input. Please enter a whole number.");

        switch (choice)
        {
            case 1: // New Caller
                NewCaller();
                break;
            case 2: // Dequeue Caller
                DequeueCaller(callQueue);
                break;
            case 3: // Show Callers
                ShowCallers(callQueue);
                break;
            case 4: // Exit
                Console.WriteLine("Exiting the program. Goodbye!");
                return false;
            default:
                Console.WriteLine("Invalid choice. Please select a valid option.");
                break;
        }
        return true;
    }
    #endregion
}