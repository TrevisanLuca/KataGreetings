using System;
namespace Greeting.Chain
{
    public class HandleNone : AbstractHandler
    {
        public override string Handle(params string[] names) => names == null ? "Hello, my friend." : _next != null ? _next.Handle(names) : throw new Exception();
    }
}