using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WXMvcApp.Tools;
using WXMvcApp.DTO;

namespace WXMvcApp.Controllers
{
    public class UpLoginFileController : Controller
    {
        //
        // GET: /UpLoginFile/

        public ActionResult Index()
        {
            return View();
        }

        //上传图片
        public ActionResult SendImg()
        {
            return View();
        }
        //上传视频
        public ActionResult SendVideo()
        {
            return View();
        }
        //群发
        public ActionResult Mass()
        {
            return View();
        }

        //根据标签进行群发
        public void _Mass_1()
        {
            var MassCs = new
            {

                clientmsgid = new Random().Next(1000000001, 2000000001),

                filter = new
                {
                    is_to_all = true,

                },
                text = new
                {
                    content = "我看见了一个美女哟",
                },
                msgtype = "text",

            };



            HttpClient hc = new HttpClient();

            string json = JsonConvert.SerializeObject(MassCs);

            StringContent sc = new StringContent(json);

            sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string retrun = hc.PostAsync("https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token=" + Access_Token_Tols.access_token, sc).Result.Content.ReadAsStringAsync().Result;
            Response.Write(retrun);

        }

        //根据OpenID列表群发
        public void _Mass_2()
        {
             HttpClient hc = new HttpClient();
            //获取关注用户id

             string userJson = hc.GetAsync("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + Access_Token_Tols.access_token ).Result.Content.ReadAsStringAsync().Result;

             //DTO_user _User = JsonConvert.DeserializeObject<DTO_user>(userJson);



             var MassCs = new
             {

                 clientmsgid = new Random().Next(1000000001, 2000000001),

                 touser = new List<string>() {"ortKSxGp_uzAH420_NPA9kwr43Ks","ortKSxBN-XnxQhYHlfv1zsoqUe1E" },
                 msgtype = "text",
                 text = new { content = "这是一个秘密" }

             };
            string json = JsonConvert.SerializeObject(MassCs);

            StringContent sc = new StringContent(json);

            sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string retrun = hc.PostAsync("https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token=" + Access_Token_Tols.access_token, sc).Result.Content.ReadAsStringAsync().Result;
            Response.Write(retrun);

        }

        //二维码 QRcode
        public ActionResult QRcode()
        {
            return View();
        }
        //带参的二维码 永久
        public void QRcode_1()
        {
            HttpClient hc = new HttpClient();

            var json = new
            {
                expire_seconds=600,
                action_name = "QR_LIMIT_STR_SCENE", 
                action_info=new {
                    scene=new {
                        scene_str= "www.baidu.com"
                    }
                }
            };
            string _json = JsonConvert.SerializeObject(json);

            StringContent sc = new StringContent(_json);

            sc.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string rt= hc.PostAsync("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token="+ Access_Token_Tols.access_token, sc).Result.Content.ReadAsStringAsync().Result;

            
            Response.Redirect("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=gQHw8TwAAAAAAAAAAS5odHRwOi8vd2VpeGluLnFxLmNvbS9xLzAyeFRYWVZZS2llaTQxMDAwME0wNzUAAgSIiRJaAwQAAAAA");
        }




    }
}
