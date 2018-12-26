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
        public IActionResult Index()
        {
            var data = _unitContext.ContentInfos.Where(a=>a.State==1).ToList();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = _unitContext.ContentInfos.Where(a => a.Id == id).ToList()[0];
            return View(data);
        }
    }
}