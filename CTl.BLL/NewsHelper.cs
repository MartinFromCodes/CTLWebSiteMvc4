using CTL.DAL;
using CTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTL.BLL
{
	public class NewsHelper
	{
		private static readonly NewsMessage message = new NewsMessage();
		public static List<NewsModel> NewsList(int pageIndex,int pageSize)
		{
			int start = (pageIndex - 1) * pageSize + 1;
			int end = pageIndex*pageSize;
			return message.NewsList(start, end);
		}

		/// <summary>
		/// 获取页数
		/// </summary>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public static int GetPageCount(int pageSize)
		{
			int count = message.NewsCount();
			int pageCount= Convert.ToInt32(Math.Ceiling((double)count / pageSize));
			return pageCount;

		}

		/// <summary>
		/// 获取一条新闻信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static NewsModel GetNewsInfo(int id)
		{
			return message.GetNewsInfo(id);
		}


		public static int DelNewsInfo(int id)
		{
			return message.DelNewsInfo(id);
		}
	}
}
