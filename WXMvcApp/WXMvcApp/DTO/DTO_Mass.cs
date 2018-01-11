using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WXMvcApp.DTO
{
    //OpenID列表群发参数
    public class DTO_Mass
    {
        public string touser { get; set; }//填写图文消息的接收者，一串OpenID列表，OpenID最少2个，最多10000个
        public string mpnews { get; set; }//用于设定即将发送的图文消息
        public string media_id { get; set; }//用于群发的图文消息的media_id
        public string msgtype { get; set; }//群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard
        public string title { get; set; }//	消息的标题
        public string description { get; set; }//消息的描述
        public string thumb_media_id { get; set; }// 视频缩略图的媒体ID
        public string send_ignore_reprint { get; set; }//图文消息被判定为转载时，是否继续群发。   1为继续群发（转载），0为停止群发。   该参数默认为0。

    }
}