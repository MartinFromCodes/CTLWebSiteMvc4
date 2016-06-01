using CTL.BLL;
using CTL.Common;
using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebExample
{
    /// <summary>
    /// UserList 的摘要说明
    /// </summary>
    public class UserList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";


            //SysUserInfo userInfo = new SysUserInfo();
            //DataTable dt = userInfo.GetUsers();

            //string html = CommonHelper.RenderHeadle("UserList.html", dt.Rows);
            //context.Response.Write(html);
           
            bool seach = Convert.ToBoolean(context.Request["seach"]);
            if (seach)
            {
                string sname = context.Request["sname"];
                if (!string.IsNullOrEmpty(sname))
                {
                     
                    string sql = @"select * from Users where u_name  like N'%'+@u_name+'%'";
                    DataSet ds=SqlHelper.ExecuteDataset(SqlHelper.connstr,CommandType.Text,sql,new SqlParameter("@u_name",sname));
                    string html=CommonHelper.RenderHeadle("UserList.html",ds.Tables[0].Rows);
                    context.Response.Write(html);
                }
                else
                {
                     
                    DataTable dt = SysUserInfo.GetUsers();

                    string html = CommonHelper.RenderHeadle("UserList.html", dt.Rows);
                    context.Response.Write(html);
                }



            }
            else
            { 
				DataTable dt = SysUserInfo.GetUsers();

                string html = CommonHelper.RenderHeadle("UserList.html", dt.Rows);
                context.Response.Write(html);
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