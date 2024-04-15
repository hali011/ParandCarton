using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;

namespace ParandCartonUpdate.APIClass
{
    public class ProductAPI
    {
        public class Select
        {

            public string Err { get; set; }
            public int TotalCount { get; set; }
            public List<List<string>> rows { get; set; }
        }

        public static List<List<string>> GetListProductAPI()
        {


            WebClient client1 = new WebClient();
            client1.Encoding = System.Text.Encoding.UTF8;
            var token = CustomerAPI.LoginAPI();
            client1.Headers.Add("X-Requested-With", "XMLHttpRequest");
            client1.Headers.Add("autt", token);  // Token : توکن دریافتی از لاگین
            client1.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            client1.QueryString.Add("id", "GoodsGroup");
            client1.QueryString.Add("Params[0].Name", "IsReqFields");
            client1.QueryString.Add("Params[0].Value", "1");

            client1.QueryString.Add("Params[1].Name", "IsStruct");
            client1.QueryString.Add("Params[1].Value", "1");

            var SelectRes = Encoding.UTF8.GetString(client1.UploadData("http://172.16.150.14:8060/api/api/Select", "POST", new byte[] { }));


            Select SelectJson = JsonConvert.DeserializeObject<Select>(SelectRes);

            List<string> SGGroupCode = new List<string>();
            List<string> SGGroupDesc = new List<string>();

            foreach (var item in SelectJson.rows)
            {
                //customerInfos.FirstOrDefault().CustomerCode=item[1];
                SGGroupCode.Add(item[1]);
                SGGroupDesc.Add(item[2]);

            }

            return SelectJson.rows;

        }
    }
}