using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace WebExample
{
	/// <summary>
	/// ValidCode 的摘要说明
	/// </summary>
	public class ValidCode : IHttpHandler
	{
		Random ran = new Random();
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "image/Jpeg";

			string chkCode = GetCode(4);
			//context.Session["chkCode"]

			using (Image img=new Bitmap(75 ,30))
			{
				using (Graphics g = Graphics.FromImage(img))
				{
					g.Clear(Color.White);
					DrawGanRao(70, g, img);
					g.DrawRectangle(Pens.AliceBlue, new Rectangle(0, 0, img.Width-1, img.Height-1));
					g.DrawString(chkCode, new Font("宋体", 14), Brushes.Red, 3, 3);
					img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
					DrawGanRao(50, g, img);
				}
			}


			context.Response.Write("Hello World");
		}

		void DrawGanRao(int count,Graphics g,Image img)
		{
			for (int i = 0; i < count; i++)
			{
				Point p1 = new Point(ran.Next(img.Width - 5), ran.Next(img.Height - 5));
				//Point p2=new Point(p1.X-1,p1.Y-1);
				Point p2 = new Point(p1.X - ran.Next(8), p1.Y - ran.Next(8));
				g.DrawLine(Pens.Black, p1, p2);
			}
		}
		/// <summary>
		/// 返回一个随机字符串
		/// </summary>
		/// <param name="len"></param>
		/// <returns></returns>
		public string GetCode(int len)
		{
			//初始化字符串
			char[] charStr=new char[15];
			charStr = new char[]{'1','2','3','4','5','6','a','A','b','c','d','啊','呀','呵','哦'};
			
			System.Text.StringBuilder sbStr = new System.Text.StringBuilder(len);
			int index = -1;

			for (int i = 0; i < len; i++)
			{
				index=ran.Next(charStr.Length);
				sbStr.Append(charStr[index].ToString());
			}
			return sbStr.ToString();
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