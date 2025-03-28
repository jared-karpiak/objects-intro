﻿namespace Objects
{
    // A "class" is a blueprint for objects in programming
    // It is a definition of what an object can do, and which properties
    // it has.
    public class Cat
    {
        /* PROPERTIES */

        // "Properties" is the terminology used for variables that
        // describe what a class "looks like". 

        // In this example, every cat has an Age, a Name, a Breed, a Color, and
        // a state.

        // Public properties will usually have UpperCamelCase naming
        // conventions.

        // Private properties will often be lowerCamelCase with an
        // underscore as a prefix

        // When declaring properties, it is common to use getters and
        // setters, represented here by the keywords "get" and "set",
        // which will retrieve or change the value of the property
        // respectively.

        // Properties should NEVER be declared and initialized at the same time
        // If properties require a starting value, they should be
        // initialized in the constructor.

        // Getters and setters can be useful to help us manage
        // access to certain properties.

        // In the case of Age, we can change the cat's name whenever
        // we want (example: birthday celebration),
        // so we just use the public get/set.
        //                |    |
        //                V    V
        public int Age { get; set; }

        // With Breed and color, these are things that should never be
        // able to change in our code, so we can use a public "getter"
        // to be able to know what the cat's breed and color are, but 
        // mark the setters as "private" so that other parts of our
        // application won't be able to change it.
        //                            |
        //                            V
        public string Breed { get; private set; }
        public string Color { get; private set; }
        // With Name, we will use encapsulation to change it.
        public string Name { get; private set; }

        // The private property "_state" is not accessible at all from
        // outside of the Cat class.

        private string _state;
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                string[] validStates =
                {
                    "Asleep",
                    "Angry",
                    "Calm",
                    "Eating"
                };

                if (!validStates.Contains(value))
                    throw new ArgumentException("Invalid state for the cat!");
                else
                    _state = value;
            }
        }

        /* ACCESS MODIFIERS */
        // An access modifier is a keyword that determines how a property
        // can be used. The two most common access modifiers are "private"
        // and "public".

        // "Public" means that the property or method can be accessed
        // by other methods, classes, files, etc.

        // "Private" means that the property or method can only be
        // accessed within the class.

        /* CONSTRUCTORS */
        // Every class has a special method called a "constructor"
        // The constructor is called when we create a new instance of
        // of a class. We can use it to set some initial values of
        // an object's properties and call some other methods if we want.

        // Unlike regular methods, constructors don't require a return type.
        // The name of the contructor is always the same as the name of the
        // class.

        // Default constructor (initializes a new instance of the object, but the
        // properties will be null):
        public Cat() { }

        // "Greedy" constructor (accepts the property values as parameters and
        // assigns them in the constructor):

        public Cat(string name = "",
            string breed = "",
            string color = "")
        {
            // We can use parameters passed into the constructor to initialize
            // some starting values
            Name = name;

            // notice how we can set the values of Breed and Color here,
            // because we are inside of the Cat class, so we have access to 
            // the setter
            Breed = breed;
            Color = color;

            // There was no parameter for state or Age, but since the Cat must
            // always have an age and have a state,
            // we can set some default values
            Age = 0;
            State = "Asleep";
        }
        /// <summary>
        /// Name: Eat
        /// Purpose: Make the cat eat and change the state to "Eating"
        /// </summary>
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating...");
            State = "Eating";
        }
        /// <summary>
        /// Name: Attack
        /// Purpose: Hiss and attack, change the state to "Angry"
        /// </summary>
        public void Attack()
        {
            Console.WriteLine($"{Name} hisses and attacks you!");
            State = "Angry";
        }
        /// <summary>
        /// Name: Purr
        /// Purpose: Relaxes the cat and change the state to "Calm"
        /// </summary>
        public void Purr()
        {
            Console.WriteLine($"{Name} chills out a bit.");
            Console.WriteLine("Purrrrr....");
            State = "Calm";
        }
        /// <summary>
        /// Name: Sleep
        /// Purpose: The cat goes to sleep and state is changed to "Asleep"
        /// </summary>
        public void Sleep()
        {
            Console.WriteLine($"{Name} passes out.");
            State = "Asleep";
        }

        /* ENCAPSULATION */
        // Encapsulation is the process of giving limited access to particular
        // parts of a class. If we have private properties or
        // methods, things we don't want other parts of the application to be
        // able to use or access directly (or accidentally change),
        // we can use encapsulation to give
        // partial access to it.

        // The GetState() method is an example of encapsulation. We have the
        // private property "_state", which only the Cat class has access to.
        // However, by using the public GetState() method, we are giving
        // other parts of the application access to the value inside of
        // "_state".

        // Encapsulation makes code more reusable, scalable, and easier to
        // maintain, because we have to change the functionality in only one
        // place.

        /// <summary>
        /// Name: ChangeName
        /// Purpose: Change the cat's name
        /// </summary>
        /// <param name="newName">The cat's new name</param>
        /// <exception cref="ArgumentException"></exception>
        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("A name must be provided!");
            }
            else if (newName.Length > 20)
            {
                throw new ArgumentException($"{newName} is too long, make it 20 characters or less!");
            }
            Console.Write($"Are you sure you want to change {Name}'s name to {newName}? ");
            string userChoice = Console.ReadLine().ToLower();
            if (userChoice == "y" || userChoice == "yes")
            {
                Name = newName;
                Console.WriteLine($"Okay. The cat's new name is {Name}.");
            }
            else
            {
                Console.WriteLine($"Okay. The cat's name is still {Name}.");
            }
        }
        /* STATIC keyword */
        // Whenever the keyword "static" is applied to a property or a method,
        // it means that this property or method can be accessed even without
        // creating an instance of that class.

        // A good use of static properties or methods are when that property
        // or method applies to all instances and when it is not necessary to
        // create an instance of that property/method to use that functionality.

        // The WillKnockThingsOver method is static. All cats will knock things
        // over. Because this applies to all cats, and will never change, we 
        // don't need to create an instance of a Cat to be able to able to
        // use it.

        /// <summary>
        /// Name: WillKnockThingsOver
        /// Purpose: All cats knock things over, so it will always return true
        /// </summary>
        /// <returns>boolean</returns>
        public static bool WillKnockThingsOver()
        {
            return true;
        }
    }
}
