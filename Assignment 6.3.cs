/* Assignment 6.3
You are developing a program to manage a call queue of customers using the Queue  in C#. The program creates a queue of callers and demonstrates the functionality of enqueueing elements into the queue and iterating over the elements and dequeuing.

Use linked lists.
*/
namespace Assignment_6._3;
public class Program
{
    public static void Main(string[] args)
    {
        Queue<string> callQueue = new Queue<string>();

        // Enqueue callers into the queue
        callQueue.Enqueue("Alice");
        callQueue.Enqueue("Bob");
        callQueue.Enqueue("Charlie");
        callQueue.Enqueue("Diana");

        Console.WriteLine("Callers in the queue:");
        foreach (var caller in callQueue)
        {
            Console.WriteLine(caller);
        }

        // Dequeue callers from the queue
        Console.WriteLine("\nDequeuing callers:");
        while (callQueue.Count > 0)
        {
            string caller = callQueue.Dequeue();
            Console.WriteLine($"Calling {caller}...");
        }
    }
}