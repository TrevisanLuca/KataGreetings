using System;
namespace Greeting.Chain
{
    [Obsolete]
    public class HandleTwo : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            if (names.Length != 2) 
                return _next != null ? _next.Handle(names) : throw new Exception();

            return $"Hello, {names[0]} and {names[1]}.";
        }
    }
}