using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using webApi.Models;
using webApi.sqlConnect;

namespace webApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    //[Route("api/weatherforecast")]    //  这里修改了
    [Route("api/[controller]")]    //  这里修改了
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        ////GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    retunr new string[] { "values1", "values2" };
        //}

        //GET api/weatherforecast/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return id.ToString();
        }

        private static Dictionary<string, AddRequest> DB = new Dictionary<string, AddRequest>();   //  用内存里的字典模拟数据库存储
        /*[HttpPost]
        public AddResponse Post([FromBody] AddRequest req)
        {

            AddResponse resp = new AddResponse();    // 这里直接把json转换为c#的对象了
            try 
            {
                //DB.Add(req.ID, req);
                resp.ID = req.ID;
                resp.message = req.depID;
                resp.result = "S";   // 接口规定成功用S  失败用F
                //开始连接数据库
                if (resp.message != null)
                {
                    string sqlstr = $"SELECT iUserID,sUserName FROM [fastmanowner].[FSys_User] where iUserID={resp.ID}";
                    ConSql conSql = new ConSql();
                    conSql.ExecSql(sqlstr);
                }
                else
                {
                    string sqlstr = $"SELECT iUserID,sUserName FROM [fastmanowner].[FSys_User]";
                    ConSql conSql = new ConSql();
                    conSql.ExecSql(sqlstr);
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                resp.ID = "";
                resp.message = "交易失败！！~~！";
                resp.result = "F";   // 接口规定成功用S  失败用F
            }
            return resp;
        }*/
    }
}
