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
            Console.WriteLine($"���ʵ�url��ַ��:{url}");  //-----------OK

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();    // �ͻ��˾�û���յ�response��Ϊʲô��  �п����Ƿ��������������Ͳ�ƥ��
                Console.WriteLine("�ͻ��˽�����try");
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;   // �ҵ������ˣ�json���л���������
                Console.WriteLine("�ͻ��˽�����catch");
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

            Console.WriteLine("�������ѯ��ţ������������full����ô�ͻ�ӷ��������������б�Ĳ�ѯ���-- > ");
            string sKey = Console.ReadLine();
            if (sKey == "Full")
            {
                req.mState = "Full";
            }
            else
            {
                req.ID = sKey;   // ��Ӧ���ݿ����iUserID�ֶ�
                req.mState = null;    //  ���޸ĵĳ�����������null����ô�������ͻ᷵������ѯ�ı��������������
                //req.userInfo = ui;  //  ��������ˣ�����ǰд���� new UserInfo()    ����Ϊʲôд������Ҳ���У��������ʵ������һ������   ����Ϊnull�Ϳ��ԣ�Ϊʲô
                // ��Ϊ��������л�ʧ���ˣ�������ֻ��дnull�ſ����������л�   �п����Ƿ������ʹ�õ���UserInfo����ͬ��Сд���µ�������
                //-------------------
                //  �����ҵ�ԭ���ˣ���Ϊ���ҷ��������������õ���userInfo[]  ���ҿͻ���post��ȥ������ʱuserInfo����Ϊ���ﲻ��һ������
                //-------------------
            }
            string jsonString;
            jsonString = JsonSerializer.Serialize(req);   //  �����û�а�req���л���û�����л���ԭ�������ΪModels������  get;set;��������û�б�����
            Console.WriteLine($"[REQ]{jsonString}");
            string result = POST(url, jsonString);   //  �ͻ����յ��˲�ѯ������ַ�����������Ϊʲô�����ʧ�ܣ� "{\"result\":\"S\",\"message\":\"�ɹ���ѯ������\",\"userInfo\":[{\"name\":\"5\",\"depName\":\"�鴺��\"}]}"

            //  ���ﷵ�ص�ֵ����װ����½��������������Ȼ��ʹ��LINQ~~~~

            Console.WriteLine($"[RESP]{result}");
            AddResponse resp = JsonSerializer.Deserialize<AddResponse>(result);  // ��������������ˣ�����ʧ��
            Console.WriteLine($"ȡֵ�Ƿ�ɹ���-->{resp.result}");
            Console.WriteLine($"ȡֵ�Ƿ�ɹ���-->{resp.message}");
            Console.WriteLine($"ȡֵ�Ƿ�ɹ���-->{resp.userinfo[0]}");
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
