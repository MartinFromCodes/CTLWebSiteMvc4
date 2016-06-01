using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CTL.Models;
using CTL.BLL;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System.Web.SessionState;

namespace WebExample
{
	/// <summary>
	/// Handler1 的摘要说明
	/// </summary>
	public class Handler1 : IHttpHandler, IRequiresSessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/html";


			string inputName = context.Request["username"].ToString();
			string intpuPassword = context.Request["password"].ToString();




			if (!string.IsNullOrEmpty(inputName) && !string.IsNullOrEmpty(intpuPassword))
			{

				 

				//if (inputName == sysUser.UserId && MD5Handle.GetMd5Str(intpuPassword) == sysUser.Password)
				//{

				//	//登录成功跳转到页面传入参数
				//	//当前用户ID
				//	context.Response.Redirect("Examine.ashx?userID=" + userID);
				//	context.Session.Add("UserID", userID);
				//	//记录到访问信息到表中或者缓存
				//	context.Response.Cookies.Clear();

				//	context.Response.Cookies.Add(new HttpCookie("name", inputName));
				//	context.Response.Cookies.Add(new HttpCookie("pwd", intpuPassword));


				//	HttpCookie cookie = new HttpCookie("a", "a");
				//	cookie.Expires = DateTime.Now.AddDays(3);



				//	//}

				//}
				//else
				//{

				//}
			}


		}


		public bool IsReusable
		{
			get
			{
				return false;
			}

		}



	}
}