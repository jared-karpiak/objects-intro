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
                    [Q] Quit
                    """);
                Console.Write("Enter a choice: ");
                string userChoice = Console.ReadLine().ToLower();
                switch (userChoice)
                {
                    case "a":
                        Console.WriteLine($"You feed {myCat.Name}");
                        myCat.Eat();
                        break;
                    case "b":
                        Console.WriteLine($"You pet {myCat.Name}");
                        if (myCat.GetState() == "Asleep")
                            myCat.Attack();
                        else
                            myCat.ChillOut();
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
                        myCat.Name = Console.ReadLine();
                        Console.WriteLine($"The cat's name is now {myCat.Name}");
                        break;
                    case "f":
                        Console.WriteLine($"{myCat.Name} is currently {myCat.GetState()}.");
                        break;
                    case "q":
                        programRunning = false;
                        break;
                }
            }
        }
    }
}
