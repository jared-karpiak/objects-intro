using System.Xml.Linq;

namespace Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Here we create a new INSTANCE of a class, a new "cat"
            Cat myCat = new Cat("Jadzia", "Tabby", "Ginger");

            bool programRunning = true;
            while (programRunning)
            {
                Console.WriteLine($"""
                    What do you want with {myCat.Name}?
                    [A] Feed
                    [B] Pet
                    [C] Check on them
                    [D] Put to bed
                    [E] Change their name
                    [F] Get state
                    [G] Celebrate Birthday
                    [Q] Quit
                    """);
                Console.Write("Enter a choice: ");
                string userChoice = Console.ReadLine().ToLower();
                switch (userChoice)
                {
                    case "a":
                        Console.WriteLine($"You feed {myCat.Name}");
                        if (myCat.GetState() == "Eating")
                            Console.WriteLine($"{myCat.Name} is already eating.");
                        else
                            myCat.Eat();
                        break;
                    case "b":
                        Console.WriteLine($"You pet {myCat.Name}");
                        if (myCat.GetState() == "Asleep")
                            myCat.Attack();
                        else
                            myCat.Purr();
                        Console.WriteLine($"{myCat.Color} fur erupts all over the house.");
                        break;
                    case "c":
                        Console.WriteLine($"""
                            Name: {myCat.Name}
                            Breed: {myCat.Breed}
                            Color: {myCat.Color}
                            """);
                        break;
                    case "d":
                        if (myCat.GetState() == "Asleep")
                            Console.WriteLine($"{myCat.Name} is already asleep.");
                        else
                            myCat.Sleep();
                        break;
                    case "e":
                        Console.Write($"What do you want to change {myCat.Name}'s to? ");
                        string newName = Console.ReadLine();
                        try
                        {
                            myCat.ChangeName(newName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "f":
                        Console.WriteLine($"{myCat.Name} is currently {myCat.GetState()}.");
                        break;
                    case "g":
                        Console.WriteLine($"It's {myCat.Name}'s birthday!");
                        myCat.Age++;
                        break;
                    case "q":
                        programRunning = false;
                        break;
                }
                //Create a little space in the console.
                Console.WriteLine('\n');
            }
        }
    }
}
