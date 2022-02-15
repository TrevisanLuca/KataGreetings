using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (!item.Contains(","))
                    tempList.Add(item);
                else if (item.Contains("\""))
                    tempList.Add(item.Trim('"'));
                else
                {
                    var temp = item.Split(",").ToList();
                    temp.ForEach(x => tempList.Add(x.Trim()));
                }
            }

            return _next.Handle(tempList.ToArray());
        }
    }
}
