/* Assignment 6.3
You are developing a program to manage a call queue of customers using the Queue  in C#. The program creates a queue of callers and demonstrates the functionality of enqueueing elements into the queue and iterating over the elements and dequeuing.

Use linked lists.
Have a method to show the callers in the queue.
Use the Call class.
*/
namespace Assignment_6._3;

public class Program
{
    public static void Main(string[] args)
    {
        Queue<Call> callQueue = new Queue<Call>();

        // Enqueue callers into the queue
        callQueue.Enqueue(new Call("Alice"));
        callQueue.Enqueue(new Call("Bob"));
        callQueue.Enqueue(new Call("Charlie"));
        callQueue.Enqueue(new Call("Diana"));

        Console.WriteLine("Callers in the queue:");
        foreach (var caller in callQueue)
        {
            Console.WriteLine(caller);
        }

        // Dequeue callers from the queue
        Console.WriteLine("\nDequeuing callers:");
        while (callQueue.Count > 0)
        {
            Call caller = callQueue.Dequeue();
            Console.WriteLine($"Calling {caller}...");
        }
    }
    
    // Method to show the callers in the queue
    public static void ShowCallers(Queue<Call> queue)
    {
        Console.WriteLine("Callers in the queue:");
        foreach (var caller in queue)
        {
            Console.WriteLine(caller);
        }
    }
}