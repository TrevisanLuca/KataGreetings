using System;
using System.Linq;
namespace Greeting.Chain
{
    public class HandleEmpty : AbstractHandler
    {
        public override string Handle(params string[] names) => names.Any(x => !string.IsNullOrWhiteSpace(x)) ?
                _next == null ? throw new Exception("Missing greetings handler") : _next.Handle(names) :
                "Hello, my friend.";        
    }
}