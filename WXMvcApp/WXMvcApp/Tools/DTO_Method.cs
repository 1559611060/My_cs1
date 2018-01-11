using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WXMvcApp.Tools;
using WXMvcApp.DTO;
namespace WXMvcApp.DTO
{
    //微信推送消息回复
    public class DTO_Method
    {
        /// <summary>
        /// datetime转换为unixtime.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }


        //被关注时
        public void Subscribe(string FromUserName, string ToUserName, string Content, HttpResponseBase Response)
        {
            //回复信息
            string resxml = string.Format(@"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[text]]></MsgType>
<Content><![CDATA[{3}]]></Content>
</xml>", FromUserName, ToUserName, ConvertDateTimeInt(DateTime.Now), Content);


            Response.Write(resxml);



        }
        //回复文本信息

        public void Text(string FromUserName, string ToUserName, string Content, HttpResponseBase Response)
        {
            //回复信息
            string resxml = string.Format(@"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[text]]></MsgType>
<Content><![CDATA[{3}]]></Content>
</xml>", FromUserName, ToUserName, ConvertDateTimeInt(DateTime.Now), Content);


            Response.Write(resxml);
        }

        //回复图片信息

        public void A_image(string FromUserName, string ToUserName, string MediaId, HttpResponseBase Response)
        {
            Mylog.Addlog(MediaId, "img", "");

            //回复图片
            string resxml = string.Format(@"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[image]]></MsgType>
<Image>
<MediaId><![CDATA[{3}]]></MediaId>
</Image> 
</xml>", FromUserName, ToUserName, ConvertDateTimeInt(DateTime.Now), MediaId);


            Response.Write(resxml);
        }

        //回复图文

        public void Image_Text (string FromUserName, string ToUserName, HttpResponseBase Response)
        {
           

            //回复图文
            string resxml = string.Format(@"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[news]]></MsgType>
<ArticleCount>2</ArticleCount>
<Articles>
<item>
<Title><![CDATA[我爱所爱]]></Title> 
<Description><![CDATA[可以放弃]]></Description>
<PicUrl><![CDATA[http://mmbiz.qpic.cn/mmbiz_jpg/ic1sFouicoJcvMMFDazsUlAY4ssAjORG6t7VXYjg8H4mNn0Oo0ib3xeU3vsu7B6ib18UYR31qyIH7PE4UzMFPvqaBw/0?wx_fmt=jpeg]]></PicUrl>
<Url><![CDATA[www.baidu.com]]></Url>
</item>
<item>
<Title><![CDATA[我爱所爱]]></Title>
<Description><![CDATA[可以放弃]]></Description>
<PicUrl><![CDATA[http://mmbiz.qpic.cn/mmbiz_jpg/ic1sFouicoJcsECS3Saqcl88LPkib9AWCJbhHUOWia2BOrpd8A2680beOibCdnyBhswANHckIFZatOHlOf9BdJrPQZQ/0?wx_fmt=jpeg]]></PicUrl>
<Url><![CDATA[www.baidu.com]]></Url>
</item>
</Articles>
</xml>", FromUserName, ToUserName, ConvertDateTimeInt(DateTime.Now));


            Response.Write(resxml);
        }


        //回复视频信息

        public void BD_Video(string FromUserName, string ToUserName,  HttpResponseBase Response)
        {
            //回复视频
            string resxml = string.Format(@"<xml>
<ToUserName><![CDATA[{0}]]></ToUserName>
<FromUserName><![CDATA[{1}]]></FromUserName>
<CreateTime>{2}</CreateTime>
<MsgType><![CDATA[video]]></MsgType>
<Video>
<MediaId><![CDATA[A7CBoHy7ErYK_mp3mdPDRqK9krjaf99Vi_aQMYbUfsM]]></MediaId>
<Title><![CDATA[美女哟]]></Title>
<Description><![CDATA[哎呀呀！未成年禁止入内]]></Description>
</Video> 
</xml>", FromUserName, ToUserName, ConvertDateTimeInt(DateTime.Now));


            Response.Write(resxml);
        }


       
    }
}