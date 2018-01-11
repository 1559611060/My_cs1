using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXMvcApp.Controllers;
namespace WXMvcApp.DTO
{
    public class DTO_TYPE
    {
        //微信传过来事件类型匹配成键值对 以便调用相应的方法
        public DTO_TYPE()
        {
            Dictionary<string, Object> _type = new Dictionary<string, Object>();

            _type.Add("event","");//事件
        }

        public static Dictionary<string,string> type;
    }
}