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
    public class ContentInfoesController : Controller
    {
        private readonly UnitContext _context;

        public ContentInfoesController(UnitContext context)
        {
            _context = context;
        }

        // GET: ContentInfoes
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Form([FromRoute] int id)
        {
            var contentInfo = _context.ContentInfos.Find(id);
            ViewBag.ContentInfo = contentInfo;
            var typeData = _context.TypeInfos.ToList();
            return View(typeData);
        }
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="contentInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultData<bool> SaveForm([FromBody] ContentInfo contentInfo)
        {
            if (contentInfo != null)
            {
                if (contentInfo.Id > 0)
                {
                    var model = _context.ContentInfos.Find(contentInfo.Id);
                    if (model != null)
                    {
                        model.Content = contentInfo.Content;
                        model.Title = contentInfo.Title;
                        model.State = contentInfo.State;
                        model.TypeId = contentInfo.TypeId;
                        _context.Update(model);
                    }

                }
                else
                {
                    contentInfo.CreateTime = DateTime.Now;
                    contentInfo.ClickNum = 0;
                    contentInfo.RecommendNum = 0;
                    contentInfo.CreateUserId = 0;
                    _context.Add(contentInfo);
                }
                _context.SaveChangesAsync();
                return new ResultData<bool>(true);
            }
            return new ResultData<bool>(false);
        }
        public TableResult<ContentInfo> GetDataList()
        {
            var data = new TableResult<ContentInfo>() { data = _context.ContentInfos.ToList(), code = 0, count = 1 };
            return data;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultData<bool> DeleteData([FromRoute] int id)
        {
            var contentInfo = _context.ContentInfos.Find(id);
            if (contentInfo == null)
            {
                return new ResultData<bool>(false) { Msg = "数据不存在" };
            }

            _context.ContentInfos.Remove(contentInfo);
            _context.SaveChanges();
            return new ResultData<bool>(true);
        }
        /// <summary>
        /// 获取一条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ResultData<ContentInfo> GetContentInfo([FromRoute] int id)
        {
            var contentInfo = _context.ContentInfos.Find(id);
            if (contentInfo == null)
            {
                return new ResultData<ContentInfo>(new ContentInfo()) { Msg = "数据不存在" };
            }
            return new ResultData<ContentInfo>(contentInfo);
        }
    }
}
