using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Result
{
    public class TableResult<T>
    {
        public  int code { get; set; }
        public  string msg { get; set; }
        public  int count { get; set; }
        public  List<T> data { get; set; }
    }
}
