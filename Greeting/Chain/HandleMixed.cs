using System.Collections.Generic;
using System.Linq;
using Greeting.Enums;

namespace Greeting.Chain
{
    public class HandleMixed : AbstractHandler
    {
        List<string> lowerCaseNames, upperCaseNames; //initialized in StringSubdivision()
        public override string Handle(params string[] names)
        {
            (lowerCaseNames, upperCaseNames) = StringSubdivision(names);

            string result = string.Empty;

            //Due to minute differences between the lowercase and uppercase sentences requirements I had to add some extra code
            result += ComposeGreeting(LowerOrUpperCase.Lowercase);

            if (upperCaseNames.Count == 1 && lowerCaseNames.Count == 0)
                return $"HELLO, {upperCaseNames[0]}!";
            if (lowerCaseNames.Count > 0 && upperCaseNames.Count > 0)
                result += " AND ";
            result += ComposeGreeting(LowerOrUpperCase.Uppercase);

            return result;
        }

        (List<string> lowerCaseNames, List<string> upperCaseNames) StringSubdivision(string[] names)
        {
            List<string>  lowerCaseNames = new List<string>();
            List<string>  upperCaseNames = new List<string>();
            foreach (var item in names)
            {
                if (item.Any(x => char.IsLower(x)))
                    lowerCaseNames.Add(item);
                else
                    upperCaseNames.Add(item);
            }
            return (lowerCaseNames, upperCaseNames);
        }

        string ComposeGreeting(LowerOrUpperCase lowerOrUpper)
        {
            string result = string.Empty;
            List<string> nameList = (lowerOrUpper == LowerOrUpperCase.Lowercase) ? lowerCaseNames : upperCaseNames;
            if (nameList.Count > 0)
            {
                char sentenceEnd = (lowerOrUpper == LowerOrUpperCase.Lowercase) ? '.' : '!';
                if (nameList.Count > 1)
                {
                    result = "Hello";
                    for (int i = 0; i < nameList.Count - 1; i++)
                        result += $", {nameList[i]}";
                    result += $" and {nameList.Last()}{sentenceEnd}";
                }
                else result = (lowerOrUpper == LowerOrUpperCase.Lowercase) ? $"Hello, {nameList[0]}{sentenceEnd}" : $"Hello {nameList[0]}{sentenceEnd}";
            }
            return (lowerOrUpper == LowerOrUpperCase.Lowercase) ? result : result.ToUpper();
        }
    }
}