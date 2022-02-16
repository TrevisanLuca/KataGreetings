using Greeting.Chain;

namespace Greeting
{
    public class Greeting : IGreeting
    {
        private IGreetingHandler _greetHandler;
        public Greeting()
        {
            _greetHandler = new HandleNone();
            _greetHandler
                .SetNext(new HandleEmpty())
                //.SetNext(new HandleOne()) //The obsolete class HandleOne could be still used if a lot of 1 name inputs are expected, giving a slight efficiency boost to the application
                .SetNext(new HandleMixed());
        }
        public string Greet(params string[] name) => _greetHandler.Handle(name);
    }
}