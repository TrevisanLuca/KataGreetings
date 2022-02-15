using System;
using System.Linq;

namespace Greeting.Chain
{
    public class HandleThreeOrMore : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            if(names.Any(x=>!x.Any(y=>char.IsLower(y))))
                return _next != null ? _next.Handle(names) : throw new Exception();

            string result = "Hello";
            for (int i = 0; i < names.Length-1; i++)            
                result += $", {names[i]}";
            result += $" and {names[names.Length - 1]}.";
            return result;
        }
    }    
}