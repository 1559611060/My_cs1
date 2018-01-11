using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WXMvcApp.DTO
{
    public class DTO_user
    {
        public int total { get; set; }//关注该公众账号的总用户数
        public int count { get; set; }//	拉取的OPENID个数，最大值为10000
        public List<string> data { get; set; }//	列表数据，OPENID的列表
        public string next_openid { get; set; }//拉取列表的最后一个用户的OPENID
    }
}