using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class ExeTestData
    {
        public string Fun()
        {
            List<TestData> list = new List<TestData>();
            list.Add(new TestData() { Name = "A", Count = 3, BatNum = "001" });
            list.Add(new TestData() { Name = "A", Count = 3, BatNum = "001" });
            list.Add(new TestData() { Name = "A", Count = 3, BatNum = "002" });
            list.Add(new TestData() { Name = "b", Count = 3, BatNum = "001" });
            list.Add(new TestData() { Name = "b", Count = 6, BatNum = "002" });
            list.Add(new TestData() { Name = "b", Count = 3, BatNum = "003" });
            list.Add(new TestData() { Name = "b", Count = 5, BatNum = "001" });
            var query = from l in list
                        group l by new { l.Name, l.BatNum } into g
                        select new
                        {
                            Name = g.Key.Name,
                            Count = g.Sum(a => a.Count),
                            BatNum = g.Key.BatNum
                        };
            string result = "";
            foreach (var q in query)
            {
                result += "Name=" + q.Name + " ," + "Count=" + q.Count + " ," + "BatNum=" + q.BatNum + "\n";
            }
            return result;
        }
    }
    public class TestData
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string BatNum { get; set; }
    }
}
