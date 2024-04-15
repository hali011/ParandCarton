using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using ParandCartonUpdate.Models;

namespace ParandCartonUpdate.APIClass
{
    public class CustomerAPI
    {
        public class Login
        {
            public string Err { get; set; }
            public string Token { get; set; }
            public bool PassWrong { get; set; }
        }

        public class Select
        {

            public string Err { get; set; }

            public int TotalCount { get; set; }

            public List<List<string>> rows { get; set; }
        }

        public static string LoginAPI()
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            client.Headers.Add("X-Requested-With", "XMLHttpRequest");
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            client.QueryString.Add("user", "API");
            client.QueryString.Add("pass", "123");
            client.QueryString.Add("place", "پرند کارتن پویا");

            var res = System.Text.Encoding.UTF8.GetString(client.UploadData("http://172.16.150.14:8060/api/api/Login", "POST", new byte[] { }));

            var json = JsonConvert.DeserializeObject<Login>(res);
            var Token = json.Token;

            return Token;
        }

        public static List<List<string>> GetListCustomerAPI()
        {


            WebClient client1 = new WebClient();
            client1.Encoding = System.Text.Encoding.UTF8;
            var token = LoginAPI();
            client1.Headers.Add("X-Requested-With", "XMLHttpRequest");
            client1.Headers.Add("autt", token);  // Token : توکن دریافتی از لاگین
            client1.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            client1.QueryString.Add("id", "SaleCustomer");
            client1.QueryString.Add("Params[0].Name", "IsReqFields");
            client1.QueryString.Add("Params[0].Value", "1");

            client1.QueryString.Add("Params[1].Name", "IsStruct");
            client1.QueryString.Add("Params[1].Value", "1");

            var SelectRes = Encoding.UTF8.GetString(client1.UploadData("http://172.16.150.14:8060/api/api/Select", "POST", new byte[] { }));


            Select SelectJson = JsonConvert.DeserializeObject<Select>(SelectRes);

            return SelectJson.rows;

        }
    }
}