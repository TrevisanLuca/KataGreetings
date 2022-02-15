using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public abstract class AbstractHandler : IGreetingHandler
    {
        protected IGreetingHandler _next;
        public abstract string Handle(params string[] names);

        public IGreetingHandler SetNext(IGreetingHandler greetingHandler) => _next = greetingHandler;
    }
}
