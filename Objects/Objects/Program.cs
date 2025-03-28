﻿using System.Security.Cryptography.X509Certificates;
using System.Text;
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
                DisplayMenu(myCat);
                Console.Write("Enter a choice: ");
                string userChoice = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (userChoice)
                {
                    case "a":
                        Console.WriteLine($"You feed {myCat.Name}");
                        if (myCat.State == "Eating")
                            Console.WriteLine($"{myCat.Name} is already eating.");
                        else
                            myCat.Eat();
                        break;
                    case "b":
                        Console.WriteLine($"You pet {myCat.Name}");
                        if (myCat.State == "Asleep")
                            myCat.Attack();
                        else
                            myCat.Purr();
                        Console.WriteLine($"{myCat.Color} fur erupts all over the house.");
                        break;
                    case "c":
                        PrintCatDetails(myCat);
                        break;
                    case "d":
                        if (myCat.State == "Asleep")
                            Console.WriteLine($"{myCat.Name} is already asleep.");
                        else
                            myCat.Sleep();
                        break;
                    case "e":
                        Console.Write($"What do you want to change {myCat.Name}'s to? ");
                        string newName = Console.ReadLine().Trim();
                        // since we know there is a possibility of runtime exceptions
                        // it is good to put the ChangeName method in a try/catch
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
                        Console.WriteLine($"{myCat.Name} is currently {myCat.State}.");
                        break;
                    case "g":
                        IncreaseCatAge(myCat);
                        Console.WriteLine($"{myCat.Name} is now {myCat.Age} years old.");
                        break;
                    case "q":
                        programRunning = false;
                        break;
                }
                //Create a little space in the console.
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        // In C#, and many other object oriented programming languages,
        // all objects are reference types, meaning that whenever we
        // access them, even when passing them in a method, we are
        // accessing their location in memory and performing operations.
        // on the object.

        // Whenever we pass an object as a parameter into a method,
        // we are passing the object by reference, even if we don't
        // use the "ref" keyword.
        
        /// <summary>
        /// Name: IncreaseCatAge
        /// Purpose: Increment the cat's age by one.
        /// </summary>
        /// <param name="cat">The cat whose age is increasing</param>
        static void IncreaseCatAge(Cat cat)
        {
            Console.WriteLine($"It's {cat.Name}'s birthday!");
            cat.Age++;
        }

        static void DisplayMenu(Cat cat)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"""
                What do you want with {cat.Name}?
                [A] Feed
                [B] Pet
                [C] Check on them
                [D] Put to bed
                [E] Change their name
                [F] Get state
                [G] Celebrate Birthday
                [Q] Quit
                """);
            Console.ResetColor();
        }

        static void PrintCatDetails(Cat cat)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine($"""
                Name: {cat.Name}
                Breed: {cat.Breed}
                Color: {cat.Color}
                Age: {cat.Age}
                Knocks things over? {Cat.WillKnockThingsOver}
                """);
        }
    }
}
