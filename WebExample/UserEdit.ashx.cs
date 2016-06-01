using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DotNet.Utilities;
using System.Data;
using CTL.Common;

namespace WebExample
{
    /// <summary>
    /// UserEdit 的摘要说明
    /// </summary>
    public class UserEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action=context.Request["action"];
            if (action=="AddNew")
            {
                bool Save=Convert.ToBoolean(context.Request["Save"]);
                if (Save)
                {
                    string name = context.Request["userName"];
                    int age=Convert.ToInt32(context.Request["age"]);
                    string gender=context.Request["gender"];
                    string remark=context.Request["remark"];
                    //插入到数据库
                    string sql = "insert into Users(u_Name,u_Age,u_Gender,u_Remark) values(@u_Name,@u_Age,@u_Gender,@u_Remark)";
                    SqlParameter[] spm=new SqlParameter[]{
                        new SqlParameter("@u_Name",name),
                        new SqlParameter("@u_Age",age),
                        new SqlParameter("@u_Gender",gender),
                        new SqlParameter("@u_Remark",remark)
                    };
                    SqlHelper.ExecuteNonQuery(SqlHelper.connstr,CommandType.Text,sql,spm);
                    context.Response.Redirect("UserList.ashx");
                }                                                   
                else
                {
                    var data = new { Action = "AddNew", User = new { u_Name = "", u_Age = 20, u_Gander = "男", u_Remark = "" } };

                    string html = CommonHelper.RenderHeadle("UserEdit.html", data);
                    context.Response.Write(html);
                }
                

            }
            else if(action=="Edit")
            {
                bool Save = Convert.ToBoolean(context.Request["Save"]);
                if (Save)
                {
                    string name = context.Request["userName"];
                    int age = Convert.ToInt32(context.Request["age"]);
                    string gender = context.Request["gender"];
                    string remark = context.Request["remark"];
                    int id=Convert.ToInt32(context.Request["id"]);
                    //插入到数据库
                    string sql = "update Users  set u_Name=@u_Name,u_Age=@u_Age,u_Gender=@u_Gender,u_Remark=@u_Remark where u_id=@u_id";
                    SqlParameter[] spm = new SqlParameter[]{
                        new SqlParameter("@u_Name",name),
                        new SqlParameter("@u_Age",age),
                        new SqlParameter("@u_Gender",gender),
                        new SqlParameter("@u_Remark",remark),
                        new SqlParameter("@u_id",id)
                    };
					SqlHelper.ExecuteNonQuery(SqlHelper.connstr, CommandType.Text, sql, spm);
                    context.Response.Redirect("UserList.ashx");
                }
                else
                {
                    
                     int id=Convert.ToInt32(context.Request["id"]);
                     string sql=@"select * from users where u_id=@u_id";
                     DataSet ds=SqlHelper.ExecuteDataset(SqlHelper.connstr,CommandType.Text,sql, new SqlParameter("@u_id",id));

                     if (ds.Tables[0].Rows.Count<=0)
                     {
                         context.Response.Write("没有找到数据："+id);
                     }
                     else if (ds.Tables[0].Rows.Count>1)
                     {
                         context.Response.Write("数据重复：" + id);
                     } 
                     else
                     {
                        var data=new{ Action= "Edit",User=ds.Tables[0].Rows[0]};
                        string html = CommonHelper.RenderHeadle("UserEdit.html", data);

                        context.Response.Write(html);
                     }

                    
                }
                
            
            }
            else if (action == "Delete")
            {
                    int id=Convert.ToInt32(context.Request["id"]);
                    string sql="delete users where u_id=@u_id";
                    int result=SqlHelper.ExecuteNonQuery(SqlHelper.connstr,CommandType.Text,sql,new SqlParameter("@u_id",id));

                    context.Response.Redirect("UserList.ashx");
            }
            else
            {
                context.Response.Write("请求参数错误");
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