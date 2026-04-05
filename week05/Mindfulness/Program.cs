using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice!");
                    Thread.Sleep(1000);
                    continue;
            }

            activity.Run();
        }
    }
}

// BASE CLASS (Abstraction + Encapsulation)
abstract class Activity
{
    private int _duration;
    private string _name;
    private string _description;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected abstract void PerformActivity();

    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration (seconds): ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine("\nGood job!");
        ShowSpinner(2);

        Console.WriteLine($"You have completed {_duration} seconds of {_name}.");
        ShowSpinner(3);
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}

// BREATHING ACTIVITY
class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This helps you relax by breathing slowly.")
    { }

    protected override void PerformActivity()
    {
        int time = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(time);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            Console.Write("\nBreathe out... ");
            ShowCountdown(4);
        }
    }
}

// REFLECTING ACTIVITY
class ReflectingActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Think of a time you helped someone.",
        "Think of a time you overcame a challenge.",
        "Think of a time you did something difficult."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this meaningful?",
        "What did you learn?",
        "How did you feel?",
        "What made this possible?"
    };

    private Random rand = new Random();

    public ReflectingActivity()
        : base("Reflecting Activity", "This helps you reflect on meaningful experiences.")
    { }

    protected override void PerformActivity()
    {
        Console.WriteLine("\n" + prompts[rand.Next(prompts.Count)]);
        ShowCountdown(5);

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.Write("\n" + questions[rand.Next(questions.Count)] + " ");
            ShowSpinner(4);
        }
    }
}

// LISTING ACTIVITY
class ListingActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people you appreciate?",
        "What are your strengths?",
        "Who did you help this week?",
        "Who are your heroes?"
    };

    private Random rand = new Random();

    public ListingActivity()
        : base("Listing Activity", "List as many items as you can.")
    { }

    protected override void PerformActivity()
    {
        Console.WriteLine("\n" + prompts[rand.Next(prompts.Count)]);
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        Console.WriteLine("Start listing:");

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            items.Add(input);
        }

        Console.WriteLine($"You listed {items.Count} items!");
    }
}