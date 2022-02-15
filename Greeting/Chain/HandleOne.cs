using System;
using System.Linq;
namespace Greeting.Chain
{
    public class HandleOne : AbstractHandler
    {
        public override string Handle(params string[] names)
        {            
            if (names.Length != 1)            
                return _next != null ? _next.Handle(names) : throw new Exception();                
            
            return !names[0].Any(x => char.IsLower(x)) ? $"Hello, {names[0]}!".ToUpper() : $"Hello, {names[0]}.";
        }
    }
}