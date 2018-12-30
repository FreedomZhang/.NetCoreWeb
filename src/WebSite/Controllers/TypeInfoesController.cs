using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSite.Models;
using WebSite.Models.Result;

namespace WebSite.Controllers
{
    public class TypeInfoesController : Controller
    {
        private readonly UnitContext _context;

        public TypeInfoesController(UnitContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public TableResult<TypeInfo> GetContList()
        {
            var data = new TableResult<TypeInfo>() {data = _context.TypeInfos.ToList(),code = 0,count = 1};
            return data;
        }

        public IActionResult Form()
        {
            return View();
        }

        public ResultData<TypeInfo> GetTypeInfo(int? id)
        {
            var rel = new ResultData<TypeInfo>(new TypeInfo());
            if (id == null)
            {
                rel.Msg = "id为空";
                return rel;
            }
            var typeInfo = _context.TypeInfos.Find(id);
            if (typeInfo == null)
            {
                rel.Msg = "数据为空";
                return rel;
            }
            rel.Data = typeInfo;
            return rel;
        }
        [HttpPost]
        public void SaveForm([FromBody]TypeInfo typeInfo)
        {
            if (typeInfo!=null)
            {
                if (_context.TypeInfos.Any(a=>a.Id==typeInfo.Id))
                {
                    var tinfo = _context.TypeInfos.Find(typeInfo.Id);
                    if (tinfo!=null)
                    {
                        tinfo.TypeName = typeInfo.TypeName;
                    }
                }
                else
                {
                    typeInfo.CreateTime=DateTime.Now;
                    _context.Add(typeInfo);
                }
                _context.SaveChanges();
            }
        }
        [HttpPost]
        public bool DeletetypeInfo([FromRoute]int id)
        {
            var typeInfo =  _context.TypeInfos.Find(id);
            _context.TypeInfos.Remove(typeInfo);
             _context.SaveChangesAsync();
            return true;
        }
    }
}
