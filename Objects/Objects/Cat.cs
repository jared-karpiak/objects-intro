namespace Objects
{
    // A "class" is a blueprint for objects in programming
    // It is a definition of what an object can do, and which properties
    // it has.
    public class Cat
    {
        /* PROPERTIES */

        // "Properties" is the terminology used for variables that
        // describe what a class "looks like". 

        // In this example, every cat has a Name, a Breed, a Color, and
        // a state.

        // Public properties will usually have UpperCamelCase naming
        // conventions.

        // Private properties will often be lowerCamelCase with an
        // underscore as a prefix

        // When declaring properties, it is common to use getters and
        // setters, represented here by the keywords "get" and "set",
        // which will retrieve or change the value of the property
        // respectively.

        // Getters and setters can be useful to help us manage
        // access to certain properties.

        // In the case of Name, we can change the cat's name whenever
        // we want, so we just use the public get/set.
        //                    |    |
        //                    V    V
        public string Name { get; set; }
        
        // With Breed and color, these are things that should never be
        // able to change in our code, so we can use a public "getter"
        // to be able to know what the cat's breed and color are, but 
        // mark the setters as "private" so that other parts of our
        // application won't be able to change it.
        //                            |
        //                            V
        public string Breed { get; private set; }
        public string Color { get; private set; }

        // The private property "_state" is not accessible at all from
        // outside of the Cat class.

        private string _state;

        /* ACCESS MODIFIERS */
        // An access modifier is a keyword that determines how a property
        // can be used. The two most common access modifiers are "private"
        // and "public".

        // Public means that the property or method can be accessed
        // by other methods, classes, files, etc.

        // Private means that the property or method can only be
        // accessed within the class.

        public Cat(string name = "",
            string breed = "",
            string color = "")
        {
            Name = name;
            Breed = breed;
            Color = color;
            _state = "Asleep";
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating...");
            _state = "Eating";
        }

        public string GetState()
        {
            return _state;
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} hisses and attacks you!");
            _state = "Angry";
        }

        public void ChillOut()
        {
            Console.WriteLine($"{Name} chills out a bit.");
            _state = "Calm";
        }
        public void Sleep()
        {
            _state = "Asleep";
        }
    }
}
