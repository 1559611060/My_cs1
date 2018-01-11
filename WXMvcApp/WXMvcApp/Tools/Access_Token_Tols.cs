using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using Newtonsoft.Json;
using WXMvcApp.DTO;
namespace WXMvcApp.Tools
{
    public class Access_Token_Tols
    {

        //静态构造函数
        static  Access_Token_Tols()
        {

            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", "wx77068c783157f3f2", "284c3212143c7f9b3187d805337fbfb9");

            HttpClient ht = new HttpClient();

            //把异步方法按照同步的方式运行  获取Access_token请求方式: GET
            //HttpResponseMessage hrp = ht.GetAsync(url).Result;
            //string Token = hrp.Content.ReadAsStringAsync().Result;
            string Token = ht.GetAsync(url).Result.Content.ReadAsStringAsync().Result;//一步写完

            //另一种更快的 json 转换方法
            DTO_gotToken_retuen dgr = JsonConvert.DeserializeObject<DTO_gotToken_retuen>(Token);

            access_token = dgr.access_token;
        }

        public static string access_token="";
    }
}