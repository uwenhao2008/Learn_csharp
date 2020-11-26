using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class AddRequest
    {
        public string ID { get; set; }   //用户ID
        public string mState { get; set; }  // 部门ID
    }
    public class UserInfo
    {
        public string name { get; set; }
        public string depName { get; set; }
        public UserInfo(string name,string depName)
        {
            this.name = name;
            this.depName = depName;
        }
    }
    public class AddResponse
    {
        public string result { get; set; }
        public string message { get; set; }
        public UserInfo[] userinfo { get; set; }
    }
}
/*
{
	"ID": 1,
	"depID": 1,
	"userName": [{
			"name": "wenhao",
			"age": 33,
			"sex": "男"
		},
		{
			"name": "雷新惠",
			"age": 63,
			"sex": "女"
		}
	]
}
 */