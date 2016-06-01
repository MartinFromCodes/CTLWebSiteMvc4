using CTL.BLL;
using CTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTL.WebAppCMS.Controllers
{
    public class AdminNewsController : Controller
    {
        //
        // GET: /AdminNews/
		/// <summary>
		/// 获取分页数据
		/// </summary>
		/// <returns></returns>
        public ActionResult Index()
        {
			int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
			int pageSize = 5;
			int pageCount = NewsHelper.GetPageCount(pageSize);

			pageIndex = pageIndex < 1 ? 1 : pageIndex;
			pageIndex = pageIndex > pageCount ? pageCount : pageIndex;

			List<NewsModel> list = NewsHelper.NewsList(pageIndex,pageSize);
			ViewData["list"] = list;
			ViewData["pageIndex"] = pageIndex;
			ViewData["pageCount"] = pageCount;
            return View();
        }

		/// <summary>
		/// 根据ID获取新闻详情
		/// </summary>
		/// <returns></returns>
		public ActionResult GetNewsInfo()
		{
			int id = Convert.ToInt32(Request["sid"].ToString());
			NewsModel newsModel = new NewsModel();
			newsModel = NewsHelper.GetNewsInfo(id);

			return Json(newsModel, JsonRequestBehavior.AllowGet);

		}

		public ActionResult DelNews()
		{
			int id = Convert.ToInt32(Request["sid"].ToString());
			 
			int result = NewsHelper.DelNewsInfo(id);
			if (result>0)
			{
				return Content("ok");
			}
			else
			{
				return Content("no");
			}
			//return Json(result, JsonRequestBehavior.AllowGet);
		}
		
		/// <summary>
		/// 添加新闻信息
		/// </summary>
		/// <returns></returns>
		public ActionResult ShowAddInfo()
		{
			return View();
		}
	}
}
