using System.Collections.Generic;
using System.Linq;

namespace Greeting.Chain
{
    public class HandleMixed : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            //if (condition)
            //    return _next != null ? _next.Handle(names) : throw new Exception();
            #region string_subdivision
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
            #endregion
            string result = string.Empty;
            if (lowerCaseNames.Count > 0)
            {
                if (lowerCaseNames.Count > 1)
                {
                result = "Hello";
                    for (int i = 0; i < lowerCaseNames.Count - 1; i++)
                        result += $", {lowerCaseNames[i]}";
                    result += $" and {lowerCaseNames.Last()}.";
                }
                else result = $"Hello, {lowerCaseNames[0]}.";
            }

            if (upperCaseNames.Count > 0)
            {
                //temp
                if (upperCaseNames.Count == 1 && lowerCaseNames.Count == 0)
                    return $"HELLO, {upperCaseNames[0]}!";
                //endTemp

                result = lowerCaseNames.Count == 0 ? "HELLO" : result + " AND HELLO";

                if (upperCaseNames.Count > 1)
                {
                    for (int i = 0; i < upperCaseNames.Count - 1; i++)
                        result += $", {upperCaseNames[i]}";

                    result += $" AND {upperCaseNames.Last()}!";

                }
                else result += $" {upperCaseNames[0]}!";
            }

            return result;
        }
    }
}