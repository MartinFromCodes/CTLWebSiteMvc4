using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using CTL.Models;
using DotNet.Utilities;
using System.Data;

namespace CTL.DAL
{
	public class UsersInfoMessage
	{
		/// <summary>
		/// 获取所有 users信息
		/// </summary>
		/// <returns></returns>
		public List<UsersModel> UsersList()
		{
			string sql = @"select u_id,u_name,u_gender,u_age,u_remark from Users";
			DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connstr, CommandType.Text, sql);
			List<UsersModel> list = null;
			//如果表中的行数大于0就循环添加到list中
			if (ds.Tables[0].Rows.Count > 0)
			{
				list = new List<UsersModel>();
				foreach (var item in ds.Tables[0].Rows)
				{
					UsersModel user = new UsersModel();
					user.UId = Int32.Parse((item as DataRow)[0].ToString());
					user.UName = (item as DataRow)[1].ToString();
					user.UGender = (item as DataRow)[2].ToString();
					user.UAge = Int32.Parse((item as DataRow)[3].ToString());
					user.U_Remark = (item as DataRow)[4].ToString();
				}
			}

			return list;
		}

		/// <summary>
		/// 获取用户返回DataTable
		/// </summary>
		/// <returns></returns>
		public DataTable GetUsers()
		{
			string sql = @"select u_id,u_name,u_gender,u_age,u_remark from Users";
			DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.connstr, CommandType.Text, sql);
			DataTable dt = null;
			if (ds != null)
			{
				dt = ds.Tables[0];
			}
			return dt;
		}

		/// <summary>
		/// 获取系统用户
		/// </summary>
		/// <returns></returns>
		//public SysUserModel GetSysUser(string userName, string password)
		//{
		//	SysUserModel model = new SysUserModel();
		//	string sql="select * from "
		//}
	}
}
