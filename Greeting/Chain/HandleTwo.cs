using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public class HandleTwo : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            if (names.Length != 2)
            {
                if (_next != null)
                    return _next.Handle(names);
                else throw new Exception();
            }
            return $"Hello, {names[0]} and {names[1]}.";
        }
    }
}
