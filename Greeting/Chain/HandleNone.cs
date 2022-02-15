using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public class HandleNone : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            return names == null ? $"Hello, my friend." : _next != null ? _next.Handle(names) : throw new Exception();
        }
    }
}
