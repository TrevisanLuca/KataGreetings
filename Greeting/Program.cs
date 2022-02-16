using System;
using Greeting.Extensions;

namespace Greeting
{
    class Program
    {
        static void Main(string[] names)
        {
            //Main takes the application arguments as inputs and generate an appropriate greeting
            //("Andrea, Luca" Giovanni MARCO Michele DORIANO) are already entered as debug parameters
            //Expected result is: Hello, Andrea, Luca, Giovanni and Michele. AND HELLO, MARCO AND DORIANO!
            var greeter = new Greeting();
            Console.WriteLine("Greetings generator application:");
            Console.WriteLine(greeter.Greet(names));
        }
    }
}