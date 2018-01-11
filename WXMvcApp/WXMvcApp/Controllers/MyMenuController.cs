using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;
using WXMvcApp.DTO;
using Newtonsoft.Json;
using WXMvcApp.Tools;

namespace WXMvcApp.Controllers
{
    public class MyMenuController : Controller
    {
        //
        // GET: /MyMenu/

        public ActionResult Index()
        {
            GreateMenu();
            return View();
        }

        //访问自定义菜单接口
        public void GreateMenu()
        {
            HttpClient hc = new HttpClient();
            DTO_Menu dm = new DTO_Menu();
            //菜单项
            List<DTO_MenuItem> list = new List<DTO_MenuItem>();

            //二级菜单
            List<DTO_MenuItem> erji = new List<DTO_MenuItem>();
            erji.Add(new DTO_MenuItem() { type = "view", name = "搜索", url = "http://www.baidu.com/" });
            
            
            list.Add(new DTO_MenuItem() { name = "二级菜单", sub_button = erji });
            list.Add(new DTO_MenuItem() { type = "media_id", name = "点击回复一个视频", media_id = "A7CBoHy7ErYK_mp3mdPDRp-IEwOyNiXxsBzk7Q2afRk" });
            list.Add(new DTO_MenuItem() { type = "click", name = "点击回复一个图文", key = "V1001_TODAY_MUSIC" });
            //list.Add(new DTO_MenuItem() { type = "click", name = "哎呀呀", key = "asdfweasdf" });
            


            dm.button = list;

            JsonSerializerSettings jss = new JsonSerializerSettings() {NullValueHandling=NullValueHandling.Ignore };//忽略掉为空的字段

            string josn = JsonConvert.SerializeObject(dm,jss);

            StringContent sc = new StringContent(josn);

            string retrun = hc.PostAsync("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + Access_Token_Tols.access_token, sc).Result.Content.ReadAsStringAsync().Result;
            Response.Write(retrun);

           // Response.Write(josn);
            Response.End();

        }
    }
}
