using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n1. Create Goal");
            Console.WriteLine("2. Show Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Load");
            Console.WriteLine("7. Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: manager.CreateGoal(); break;
                case 2: manager.DisplayGoals(); break;
                case 3: manager.RecordEvent(); break;
                case 4: manager.ShowScore(); break;
                case 5: manager.Save("goals.txt"); break;
                case 6: manager.Load("goals.txt"); break;
                case 7: return;
            }
        }
    }
}