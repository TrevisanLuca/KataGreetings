using System;
using System.Linq;
namespace Greeting.Chain
{
    public class HandleEmpty : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            return names.Any(x => !string.IsNullOrWhiteSpace(x)) ?
                _next == null ? throw new Exception() : _next.Handle(names) :
                "Hello, my friend.";
        }
    }
}