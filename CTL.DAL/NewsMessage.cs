using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTL.Models;
using System.Data.SqlClient;
using System.Data;
using DotNet.Utilities;

namespace CTL.DAL
{
	public class NewsMessage
	{
		/// <summary>
		/// 获取新闻列表
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public List<NewsModel> NewsList(int start,int end)
		{
			string sql = @"select ROW_NUMBER() over(order by id) as nid ,Id,Title,Msg,SubDateTime,Author,ImagePath  from (select ROW_NUMBER() over(order by id) as num,*
				from news) as t where t.num>=@start and t.num<=@end and IsDel=0";

			SqlParameter[] pars = { 
								  new SqlParameter("@start",SqlDbType.Int),
								  new SqlParameter("@end",SqlDbType.Int)
								  
								  };
			pars[0].Value = start;
			pars[1].Value = end;

			DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connstr, CommandType.Text, sql, pars);
			DataTable dt = null;
			if (ds.Tables.Count>0)
			{
				 dt = ds.Tables[0];
			}
			List<NewsModel> list=new List<NewsModel>();
			if (dt.Rows.Count>0)
			{
				foreach (DataRow item in dt.Rows)
				{
					NewsModel model = new NewsModel();
					model.Id =Int32.Parse( item["Id"].ToString());
					model.NId = Int32.Parse(item["NId"].ToString());
					model.Title = item["Title"] != DBNull.Value ? item["Title"].ToString() : string.Empty;
					model.Msg = item["Msg"].ToString();
					model.SubDateTime = Convert.ToDateTime(item["SubDateTime"].ToString());
					model.Author = item["Author"].ToString();
					list.Add(model);
				}
			}
			return list;

		}

		/// <summary>
		/// 获取总条数
		/// </summary>
		/// <returns></returns>
		public int NewsCount()
		{
			string sql = @"select count(*) from news ";
 
			 
			object obj = SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, sql);

			return Convert.ToInt32(obj);
		}

		/// <summary>
		/// 获取一条新闻信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public NewsModel GetNewsInfo(int id)
		{
			string sql = @"select Id,Title,Msg,SubDateTime,Author,ImagePath from News where Id=@ID";

			SqlParameter[] pars = { 
								  new SqlParameter("@id",SqlDbType.Int),
								   
								  };
			pars[0].Value = id;
			DataSet ds= SqlHelper.ExecuteDataset(SqlHelper.connstr, CommandType.Text, sql,pars);
			NewsModel newsModel = new NewsModel();
			if (ds.Tables[0].Rows.Count>0)
			{
				DataRow dr=ds.Tables[0].Rows[0];
				newsModel.Id = Int32.Parse(dr["Id"].ToString());
				//newsModel.NId = Int32.Parse(dr["NId"].ToString());
				newsModel.Title = dr["Title"] != DBNull.Value ? dr["Title"].ToString() : string.Empty;
				newsModel.Msg = dr["Msg"].ToString();
				newsModel.SubDateTime = Convert.ToDateTime(dr["SubDateTime"].ToString());
				newsModel.Author = dr["Author"].ToString();
				 
			}
			return newsModel;
		}

		public int DelNewsInfo(int id)
		{
			string sql = @"update  News set IsDel=1 where Id=@ID";

			SqlParameter[] pars = { 
								  new SqlParameter("@id",SqlDbType.Int),
								   
								  };
			pars[0].Value = id;
			int reslut= SqlHelper.ExecuteNonQuery(SqlHelper.connstr, CommandType.Text, sql, pars);
			return reslut;
		}
	}
}
