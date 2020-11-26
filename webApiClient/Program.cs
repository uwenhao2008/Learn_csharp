using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using webApiClient.Models;
using System.Text.Json;
using System.Net.Http;

namespace webApiClient
{
    public class Program
    {
        public static string POST(string url,string postData)
        {
            Console.WriteLine($"postdata:{postData}");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";   
            request.Method = "POST";
            request.Timeout = 10000;

            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            foreach(var i in bytes)
            {
                Console.Write(i+" ");
            }

            request.ContentLength = bytes.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
            Console.WriteLine();
            Console.WriteLine($"访问的url地址是:{url}");  //-----------OK

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();    // 客户端就没接收到response，为什么？  有可能是服务器端数据类型不匹配
                Console.WriteLine("客户端进入了try");
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;   // 找到问题了，json序列化出问题了
                Console.WriteLine("客户端进入了catch");
            }

            StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(),Encoding.UTF8);
            string result = reader.ReadToEnd();
            response.Close();
            return result;
        }
        
        public static void Main(string[] args)
        {
            string url = "https://localhost:5001/api/user/post";
            AddRequest req = new AddRequest();
            // SELECT iUserID,sUserName FROM [fastmanowner].[FSys_User]

            Console.WriteLine("请输入查询编号，若是输入的是full，那么就会从服务器返回所有列表的查询结果-- > ");
            string sKey = Console.ReadLine();
            if (sKey == "Full")
            {
                req.mState = "Full";
            }
            else
            {
                req.ID = sKey;   // 对应数据库里的iUserID字段
                req.mState = null;    //  我修改的程序，这里若是null，那么服务器就会返回所查询的表里面的所有数据
                //req.userInfo = ui;  //  我这里错了，我以前写的是 new UserInfo()    但是为什么写成这样也不行？这个是我实例化的一个对象啊   这里为null就可以？为什么
                // 因为这里的序列化失败了，导致我只有写null才可以正常序列化   有可能是服务端我使用的是UserInfo，不同大小写导致的问题吗？
                //-------------------
                //  终于找到原因了，因为我我服务器类型里我用的是userInfo[]  而我客户端post过去的数据时userInfo，因为这里不是一个数组
                //-------------------
            }
            string jsonString;
            jsonString = JsonSerializer.Serialize(req);   //  这里就没有把req序列化？没有序列化的原因就是因为Models我少了  get;set;导致数据没有被操作
            Console.WriteLine($"[REQ]{jsonString}");
            string result = POST(url, jsonString);   //  客户端收到了查询结果的字符串，我这里为什么会解析失败？ "{\"result\":\"S\",\"message\":\"成功查询到数据\",\"userInfo\":[{\"name\":\"5\",\"depName\":\"伍春谊\"}]}"

            //  这里返回的值重新装填到我新建立的数据类型里，然后使用LINQ~~~~

            Console.WriteLine($"[RESP]{result}");
            AddResponse resp = JsonSerializer.Deserialize<AddResponse>(result);  // 就是这里出问题了，解析失败
            Console.WriteLine($"取值是否成功？-->{resp.result}");
            Console.WriteLine($"取值是否成功？-->{resp.message}");
            Console.WriteLine($"取值是否成功？-->{resp.userinfo[0]}");
            Console.ReadLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
