using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WXMvcApp.DTO
{
    public class DTO_Menu
    {
        public List<DTO_MenuItem> button { get; set; }//菜单按钮
    }
    public class DTO_MenuItem   // 按钮作用
    {
        public string type { get; set; }
        public string name { get; set; }
        public string key { get; set; }

        public string url { get; set; }
        public string appid { get; set; }
        public string pagepath { get; set; }
        public string media_id { get; set; }
        public List<DTO_MenuItem> sub_button { get; set; }//二级菜单
     }
   
}