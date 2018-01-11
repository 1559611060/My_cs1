using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXMvcApp.DTO;
using WXMvcApp.Tools;

using System.IO;
using System.Xml.Linq;

namespace WXMvcApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //微信服务器配置链接 只执行一次就够了
        //public ActionResult Index(string signature, string timestamp, string nonce, string echostr)
        //{
        //    if (echostr!=null)
        //    {
        //        Response.Write(echostr);
        //    }
        //    else
        //    {
        //        Response.Write("传过来的是空字符");
        //    }

        //    Response.End();

        //    return View();
        //}

        private XElement root = null;
        private string XMLcolent = null;
        public JsonResult GetAccess()
        {
            try
            {
                //读取微信推送的内容
                StreamReader sr = new StreamReader(Request.InputStream);

                XMLcolent = sr.ReadToEnd();


                //说明有推送内容过来
                if (XMLcolent!="")
                {
                    root = XElement.Parse(XMLcolent);

                    string FromUserName = root.Element("FromUserName").Value;//谁发送
                    string ToUserName = root.Element("ToUserName").Value;//设接收

                    //读取消息类型
                    string MsgType = root.Element("MsgType").Value;

                    Mylog.Addlog(XMLcolent, "查询微信推送的消息", "" + MsgType);

                    //在键值对中匹配相应的
                    //string Method = DTO_TYPE.type[MsgType];

                    //微信推送的是  事件
                    if (MsgType == "event")
                    {

                        //取出事件类型
                        string Event = root.Element("Event").Value;
                        Mylog.Addlog(XMLcolent + ":" + Event, "取出xml里面具体的值", "");
                        if (Event == "subscribe")//被关注时
                        {
                            Mylog.Addlog(XMLcolent + ":" + Event, "取出xml里面具体的值", "");

                            //被动给发送者回复信息
                            DTO_Method method = new DTO_Method();
                            method.Subscribe(FromUserName, ToUserName, "感谢关注！！", Response);
                        }



                    }
                    //微信推送过来的是  文本类型
                    if (MsgType == "text")
                    {
                        //接收用户发过来的信息
                        string Content = root.Element("Content").Value;

                        //被动给发送者回复信息
                        DTO_Method method = new DTO_Method();
                        method.Text(FromUserName, ToUserName, "用户传来的信息是：" + Content, Response);
                    }

                    //微信推送过来的是 图片类型
                    if (MsgType == "image")
                    {
                        //接收用户发过来的 图片id
                        string MediaId = root.Element("MediaId").Value;

                        //被动给发送者回复 单独的一张原图
                        DTO_Method method = new DTO_Method();
                        method.A_image(FromUserName, ToUserName, MediaId, Response);
                    }

                    if (MsgType == "click")
                    {
                        //被动回复图文
                        DTO_Method method = new DTO_Method();
                        method.Image_Text(FromUserName, ToUserName, Response);
                    }

                    if (MsgType == "media_id")
                    {
                        
                        DTO_Method method = new DTO_Method();
                        //被动回复视频
                        method.BD_Video(FromUserName, ToUserName, Response);
                    }
                }
                else
                {
                   

                }

                
                
                
            }
            catch (Exception ex)
            {
               //记录错误
                Mylog.Addlog( ex.Message,"错误信息" , "");
               
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        



    }
}
