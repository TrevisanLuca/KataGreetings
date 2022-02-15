using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public class HandleThreeOrMore : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            if(names.Any(x=>!x.Any(y=>char.IsLower(y))))
            {
                if (_next != null)
                    return _next.Handle(names);
                else throw new Exception();
            }
            string result = "Hello";
            for (int i = 0; i < names.Length-1; i++)            
                result += $", {names[i]}";
            result += $" and {names[names.Length - 1]}.";
            return result;
        }
    }    
}