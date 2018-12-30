using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class DefaultController : Controller
    {
        private UnitContext _unitContext = new UnitContext();
        public IActionResult Index(int id)
        {
            var data = _unitContext.ContentInfos.Where(a => a.State == 1).ToList();
            if (id > 0)
            {
                data = data.Where(a => a.TypeId == id).ToList();
            }

            foreach (var contentInfo in data)
            {
                var type = _unitContext.TypeInfos.Find(contentInfo.TypeId);
                if (type != null)
                {
                    contentInfo.TypeName = type.TypeName;
                }
            }
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = _unitContext.ContentInfos.Find(id);
            if (data != null)
            {
                var type = _unitContext.TypeInfos.Find(data.TypeId);
                if (type != null)
                {
                    data.TypeName = type.TypeName;
                    data.ClickNum++;
                    _unitContext.Update(data);
                    _unitContext.SaveChanges();
                }
            }

            return View(data);
        }
        /// <summary>
        /// 时间线
        /// </summary>
        /// <returns></returns>
        public IActionResult Timeline()
        {
            return View();
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            return View();
        }
    }
}