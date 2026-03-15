using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What did I learn today?"
        };

        Random random = new Random();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                int index = random.Next(prompts.Count);
                string prompt = prompts[index];

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry entry = new Entry();
                entry.Date = DateTime.Now.ToShortDateString();
                entry.Prompt = prompt;
                entry.Response = response;

                journal.AddEntry(entry);
            }

            else if (choice == 2)
            {
                journal.DisplayEntries();
            }

            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }

            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }
        }
    }
}