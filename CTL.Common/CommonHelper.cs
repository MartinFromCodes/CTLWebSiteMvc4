using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CTL.Common
{
    public class CommonHelper
    {
        
        /// <summary>
        /// 公共方法处理HTML的封装
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string RenderHeadle(string templateName,object data)
        {

            VelocityEngine vltEngine = new VelocityEngine();
            vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/Templates"));//模板文件所在的文件夹
            vltEngine.Init();                                                                                                   

            VelocityContext vltContext = new VelocityContext();
            vltContext.Put("Data", data);

            Template vltTemplate = vltEngine.GetTemplate(templateName);
            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
            vltTemplate.Merge(vltContext, vltWriter);

           return   vltWriter.GetStringBuilder().ToString();
            

        }
    }
}