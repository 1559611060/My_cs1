using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WXMvcApp.DTO
{
    public class DTO_gotToken_retuen
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}