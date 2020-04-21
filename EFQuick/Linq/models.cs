using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class models
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Birthday Birthday { get; set; }
    }
    public class Birthday
    {
        public string row { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
}
