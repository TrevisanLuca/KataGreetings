using System;
using System.Collections.Generic;
using System.Linq;

namespace Greeting.Chain
{
    public class HandleSpecial : AbstractHandler
    {
        public override string Handle(params string[] names)
        {
            if (_next == null)
                throw new Exception();

            List<string> tempList = new List<string>();
            foreach (var item in names)
            {
                //if (string.IsNullOrWhiteSpace(item))
                //    continue;
                //else if (!item.Contains(","))
                //    tempList.Add(item);
                //else if (item.Contains("\""))
                //    tempList.Add(item.Trim('"'));
                //else
                //{
                //    //var temp = item.Split(",").ToList();
                //    //temp.ForEach(x => tempList.Add(x.Trim()));
                //    tempList.AddRange(item.Split(","));
                //}
                if (!string.IsNullOrWhiteSpace(item))
                {
                    if (!item.Contains("\""))
                        tempList.AddRange(item.Split(","));
                    else 
                        tempList.Add(item.Trim('"'));
                }
            }
                    tempList = tempList.Select(x => x.Trim()).ToList();
            return _next.Handle(tempList.ToArray());
        }
    }
}
