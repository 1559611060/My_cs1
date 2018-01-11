using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace WXMvcApp.Tools
{
    public class Mylog
    {
        public static void Addlog(string content,string type,string reamark)
        {
            string fileName = DateTime.Now.ToShortDateString().Replace("/", "-") + ".txt";
            //记录日志到文本
            FileStream fs = new FileStream("c:/微信日志/"+fileName,FileMode.Append);

            //字符串写入流
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("发生时间："+DateTime.Now.ToString());
            sw.WriteLine("content:" + content);
            sw.WriteLine("type:" + type);
            sw.WriteLine("reamark:" + reamark);
            sw.WriteLine("--------------------------------------------------------------------------");

            sw.Flush();
            sw.Close();


        } 
    }
}