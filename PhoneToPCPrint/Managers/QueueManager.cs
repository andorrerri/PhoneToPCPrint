using System.Collections.Concurrent;
using System.Threading;

public static class QueueManager
{
    private static readonly ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
    private static bool running;

    public static void Start()
    {
        running = true;
        new Thread(Process).Start();
    }

    public static void Stop()
    {
        running = false;
    }

    public static void Enqueue(string file)
    {
        queue.Enqueue(file);
    }

    private static void Process()
    {
        while (running)
        {
            if (queue.TryDequeue(out string file))
            {
                PrinterManager.Print(file);
                Logger.Print("Printed: " + file);
            }

            Thread.Sleep(ConfigManager.Interval);
        }
    }
}