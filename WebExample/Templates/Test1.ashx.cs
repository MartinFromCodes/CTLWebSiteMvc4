using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebExample.Templates
{
    /// <summary>
    /// Test1 的摘要说明
    /// </summary>
    public class Test1 : IHttpHandler
    {
         
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //bool IsPostBack =Convert.ToBoolean( context.Request["IsPostBack"]);
            //if (IsPostBack)
            //{
            //    string action = context.Request["action"];
            //    if (action=="Zan")
            //    {
            //        int Zan = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select   Zan from Person where BusinessEntityID=1");
            //        context.Response.Write(Zan);
            //    }
            //    else
            //    {
            //        int Cai = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select   Cai from Person where BusinessEntityID=1");
            //       context.Response.Write(Cai);
            //       }
            //}
            //else
            //{
            //    int Zan = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select   Zan from Person where BusinessEntityID=1");
            //    int Cai = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select   Cai from Person where BusinessEntityID=1");
            //    var data=new{Zan,Cai};
            //    string html= CommonHelper.RenderHeadle("Test1.html",data);
            //    context.Response.Write(html);
            //}


            string action = context.Request["Action"];
            if (action == "Zan")
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.connstr, CommandType.Text, @"
                update Person set Zan=Zan+1 where BusinessEntityID=1");
                int Zan = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select   Zan from Person where BusinessEntityID=1");
                context.Response.Write(Zan);
            }
            else if (action == "Cai")
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.connstr, CommandType.Text, @"
                update Person set Cai=Cai+1 where BusinessEntityID=1");
                int Cai = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select   Cai from Person where BusinessEntityID=1");
                context.Response.Write(Cai);

            }
            else if(action=="getNum")
            {
                int Zans = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select   Zan from Person where BusinessEntityID=1");
                int Cais = (int)SqlHelper.ExecuteScalar(SqlHelper.connstr, CommandType.Text, @"select   Cai from Person where BusinessEntityID=1");
                var a = new { Zans = Zans, Cais = Cais };

                JavaScriptSerializer jser = new JavaScriptSerializer();
                string jsons = jser.Serialize(a);
                context.Response.Write(jsons);
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