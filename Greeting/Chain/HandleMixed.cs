using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public class HandleMixed : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            //if (condition)
            //{
            //    if (_next != null)
            //        _next.Handle(names);
            //    throw new Exception();
            //}
            List<string> lowerCaseNames = new List<string>();
            List<string> upperCaseNames = new List<string>();
            foreach (var item in names)
            {
                //!item.Any(x => char.IsLower(x)) ? upperCaseNames.Add(item) : lowerCaseNames.Add(item);
                if (!item.Any(x => char.IsLower(x)))
                    upperCaseNames.Add(item);
                else
                    lowerCaseNames.Add(item);
            }

            string result = "Hello";

            if (lowerCaseNames.Count > 1)
            {
                for (int i = 0; i < lowerCaseNames.Count - 1; i++)
                    result += $", {lowerCaseNames[i]}";
                result += $" and {lowerCaseNames.Last()}.";
            }
            else result += $"Hello, {lowerCaseNames[0]}.";

            if (upperCaseNames.Count > 1)
            {
                result += " AND HELLO";
                for (int i = 0; i < upperCaseNames.Count - 1; i++)
                    result += $" {upperCaseNames[i]}";

                result += $" AND {upperCaseNames.Last()}!";

            }
            else result += $" AND HELLO {upperCaseNames[0]}!";

            return result;
        }
    }
}
