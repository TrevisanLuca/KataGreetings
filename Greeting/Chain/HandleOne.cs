using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public class HandleOne : AbstractHandler
    {
        public override string Handle(params string[] names)
        {            
            if (names.Length != 1)
            {
                if (_next != null)
                  return _next.Handle(names);
                else throw new Exception();
            }
            return !names[0].Any(x => char.IsLower(x)) ? $"Hello, {names[0]}!".ToUpper() : $"Hello, {names[0]}.";
        }
    }
}
