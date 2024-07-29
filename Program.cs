using System;
using System.Threading;

class Program
{
    private static readonly object r1 = new object();
    private static readonly object r2 = new object();

    static void Main(string[] args)
    {
        Thread t1 = new Thread(Thread1);
        Thread t2 = new Thread(Thread2);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Finished processing.");
    }

    static void Thread1()
    {
        Console.WriteLine("Thread 1 attempting to lock r1");
        lock (r1)
        {
            Console.WriteLine("Thread 1 locked r1");
            // Simulating some work
            Thread.Sleep(100);
            Console.WriteLine("Thread 1 attempting to lock r2");
            lock (r2)
            {
                Console.WriteLine("Thread 1 locked r2");
                // Perform some action
            }
        }
        Console.WriteLine("Thread 1 released r1 and r2");
    }

    static void Thread2()
    {
        Console.WriteLine("Thread 2 attempting to lock r2");
        lock (r2)
        {
            Console.WriteLine("Thread 2 locked r2");
            // Simulating some work
            Thread.Sleep(100);
            Console.WriteLine("Thread 2 attempting to lock r1");
            lock (r1)
            {
                Console.WriteLine("Thread 2 locked r1");
                // Perform some action
            }
        }
        Console.WriteLine("Thread 2 released r2 and r1");
    }
}
