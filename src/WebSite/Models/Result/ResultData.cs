using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Result
{
    public class ResultData<T>
    {
        public ResultData(T t)
        {
            this.Code = 200;
            Data = t;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        public string Msg { get; set; }

        public  T Data { get; set; }
    }
}
