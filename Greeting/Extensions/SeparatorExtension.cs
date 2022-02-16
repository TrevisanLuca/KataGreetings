using System.Collections.Generic;
using System.Linq;

namespace Greeting.Extensions
{
    public static class SeparatorExtension
    {
        public static string[] SeparatorHandler(this string[] names)
        {
            var tempList = new List<string>();
            foreach (var item in names)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (!item.Contains("\""))
                        tempList.AddRange(item.Split(","));
                    else
                        tempList.Add(item.Trim('"'));
                }
            }
            return tempList.Select(x => x.Trim()).ToArray();            
        }
    }
}