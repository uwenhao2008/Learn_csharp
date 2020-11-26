using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using webApi.Models;
using webApi.sqlConnect;

namespace webApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    //---------   https://localhost:5001/api/user/hello   通过这个地址访问了自己定义的控制器   最后的hello就是对应需要执行的函数名字 
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("这是我的欢迎世界");
        }

        [HttpPost]
        public AddResponse Post([FromBody] AddRequest req)
        {
            AddRequest server_req = new AddRequest();
            if (req != null)
            {
                server_req.ID = req.ID;
                //Console.WriteLine("接收到的ID为{0}", server_req.ID);
                server_req.mState = req.mState;
                //Console.WriteLine("接收到的mState为{0}", server_req.mState);
            }
            AddResponse resp = new AddResponse();    // 这里直接把json转换为c#的对象了 //验证出来了，前面一直出错的原因就是这里的resp不知道为什么后面失效了，导致return无法执行
            //try
            //{
            //    //resp.ID = req.ID;
            //    //resp.message = req.depID;
            //    //resp.result = "S";   // 接口规定成功用S  失败用F
            //    //开始连接数据库
            //    if (resp.message != null)
            //    {
            //        string sqlstr = $"SELECT iUserID,sUserName FROM [fastmanowner].[FSys_User] where iUserID={resp.ID}";
            //        ConSql conSql = new ConSql();
            //        conSql.ExecSql(sqlstr);
            //    }
            //    else
            //    {
            //        string sqlstr = $"SELECT iUserID,sUserName FROM [fastmanowner].[FSys_User]";
            //        ConSql conSql = new ConSql();
            //        conSql.ExecSql(sqlstr);
            //    }
            //}

            if (server_req.ID != null)
            {
                Console.WriteLine("开始查找单条数据库");
                string sqlstr = $"SELECT iUserID,sUserName FROM [fastmanowner].[FSys_User] where iUserID={server_req.ID}";
                ConSql conSql = new ConSql();
                var cData = conSql.ExecSql(sqlstr,"s");   //  这里s是为了实现重载   代表single
                resp.userinfo = new UserInfo[1];
                resp.userinfo[0] = new UserInfo(cData.name, cData.depName);
                resp.result = "S";
                resp.message = "成功查询到数据";
            }
            if (server_req.mState == "Full")
            {
                Console.WriteLine("开始查找多条数据");
                if (resp == null)
                {
                    Console.WriteLine("2上面我实例化的resp消失了~~~");
                }
                Console.WriteLine("服务器成功接收到post数据，处理中...");
                Console.WriteLine("post数据为-->：{0}", server_req);
                Console.WriteLine("post数据为-->：{0}", server_req.ID);  //  --------OK
                ConSql conSql = new ConSql();    // 貌似是我这里进行数据库连接初始化惹的祸
                try
                {
                    if (resp == null)
                    {
                        Console.WriteLine("3上面我实例化的resp消失了~~~");
                    }
                    //DB.Add(req.ID, req);
                    //  这里为什么resp就消失了？
                    //Console.WriteLine("尝试输出resp{0}",resp.result);
                    //resp.result = "S";
                    //resp.message = $"客户端请求的查询数据为：{req.ID}";
                    //resp.userInfo = null;//????

                    //Console.WriteLine(resp.message);
                    //Console.WriteLine("resp.userInfo的类型为：{0}", resp.userInfo.GetType());

                    string sqlstr = "XXXXX---XXXX";
                        //(server_req.ID != "full") ? $"SELECT iUserID,sUserName FROM [fastmanowner].[FSys_User] where iUserID={req.ID}" : $"SELECT top 40 iUserID,sUserName FROM [fastmanowner].[FSys_User]";
                    Console.WriteLine("得到的查询字符串为{0}", sqlstr);
                    conSql.ExecSql(sqlstr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    resp.message = "交易失败！！~~！";
                    resp.result = "F";   // 接口规定成功用S  失败用F
                    resp.userinfo = null;
                }
            }
            else
            {
                Console.WriteLine("服务器没有收到客户端的数据......");
            }
            return resp;
            //  数据终于成功进去了，我好好整理下思路   尤其是sqlConn.cs文件的41行，那里有没有好办法解决
        }
    }
}
