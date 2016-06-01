using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebExample.Templates
{
    /// <summary>
    /// register 的摘要说明
    /// </summary>
    public class register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //string html = CommonHelper.RenderHeadle("register.html", "");
            //context.Response.Write(html);


            string userName = context.Request["userName"];
            if (!string.IsNullOrEmpty(userName))
            {
                int num = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select count(*) from users where u_name=@uname", new SqlParameter("@uname", userName));


                if (userName.Contains("共产党") || userName.Contains("胡锦涛") || userName.Contains("Admin"))
                {
                    context.Response.Write("用户名中含有敏感词！请更换用户名");
                }
                else if (num > 0)
                {
                    context.Response.Write("用户名已被使用!");
                }
                else
                {
                    context.Response.Write("用户名可以使用!");
                }



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