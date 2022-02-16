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

            //Due to minute differences between the lowercase and uppercase sentences requirements I had to add some extra code
            var result = ComposeGreeting(LowerOrUpperCase.Lowercase);

            if (upperCaseNames.Count == 1 && lowerCaseNames.Count == 0)
                return $"HELLO, {upperCaseNames[0]}!";
            if (lowerCaseNames.Count > 0 && upperCaseNames.Count > 0)
                result = result + " AND ";
            result = result + ComposeGreeting(LowerOrUpperCase.Uppercase);

            return result;
        }

        private (List<string> lowerCaseNames, List<string> upperCaseNames) StringSubdivision(string[] names)
        {
            var lowerCaseNames = new List<string>();
            var upperCaseNames = new List<string>();
            foreach (var item in names)
            {
                if (item.Any(x => char.IsLower(x)))
                    lowerCaseNames.Add(item);
                else
                    upperCaseNames.Add(item);
            }
            return (lowerCaseNames, upperCaseNames);
        }

        private string ComposeGreeting(LowerOrUpperCase lowerOrUpper)
        {
            var result = string.Empty;
            var nameList = (lowerOrUpper.Equals(LowerOrUpperCase.Lowercase)) ? lowerCaseNames : upperCaseNames;
            if (nameList.Count > 0)
            {
                var sentenceEnd = (lowerOrUpper.Equals(LowerOrUpperCase.Lowercase)) ? '.' : '!';
                if (nameList.Count > 1)
                {
                    result = "Hello";
                    for (int i = 0; i < nameList.Count - 1; i++)
                        result = result + $", {nameList[i]}";
                    result = result + $" and {nameList.Last()}{sentenceEnd}";
                }
                else result = (lowerOrUpper.Equals(LowerOrUpperCase.Lowercase)) ? $"Hello, {nameList[0]}{sentenceEnd}" : $"Hello {nameList[0]}{sentenceEnd}";
            }
            return (lowerOrUpper == LowerOrUpperCase.Lowercase) ? result : result.ToUpper();
        }
    }
}