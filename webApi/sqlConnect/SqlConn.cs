using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;

using webApi.Models;

namespace webApi.sqlConnect
{
    class ConSql
    {
        private string ds = "127.0.0.1";
        private string dbName = "fastMan_bhgyh";
        private string uID = "sa";
        private string pwd = "wen4632022";

        public string ConStr()
        {
            StringBuilder sqlPath = new StringBuilder();
            sqlPath.Append($"Data Source={ds};");
            sqlPath.Append($@"Initial Catalog={dbName};");
            sqlPath.Append($"User Id={uID};Password={pwd};");
            string connectString = sqlPath.ToString();   //转换为连接字符串
            return connectString;
        }
        // 通过重载实现查询单条数据
        public UserInfo ExecSql(string queryStr,string str)
        {
            using (SqlConnection con = new SqlConnection(ConStr()))
            {
                SqlCommand command = new SqlCommand(queryStr, con);
                con.Open();
                Console.WriteLine("连接成功1");
                SqlDataReader reader = command.ExecuteReader();
                UserInfo userinfo = new UserInfo("1","2");  
                while (reader.Read())
                {
                    userinfo.name = Convert.ToString(reader[0]);
                    userinfo.depName = Convert.ToString(reader[1]);
                }
                Console.WriteLine("1总共从数据库读出来{0}条数据", reader.RecordsAffected);
                reader.Close();
                Console.WriteLine("2总共从数据库读出来{0}条数据", reader.RecordsAffected);
                Console.WriteLine("当前服务器与数据库的连接状态为{0}", reader.IsClosed ? "已关闭" : "未关闭");
                return userinfo;
            }
        }

        public void ExecSql(string queryStr)
        {
            using (SqlConnection con = new SqlConnection(ConStr())) {
                SqlCommand command = new SqlCommand(queryStr, con);
                con.Open();
                Console.WriteLine("连接成功2");
                SqlDataReader reader = command.ExecuteReader();
                UserInfo[] userinfo = new UserInfo[50];  // 先设定数组大小为50吧
                while (reader.Read())
                {
                    for(int i=0;i< userinfo.Length; i++)
                    {
                        userinfo[i].name = (string)reader[0];
                        userinfo[i].depName = (string)reader[1];

                    }
                        //Console.WriteLine(String.Format("{0},{1}", reader[0], reader[1]));
                }
                reader.Close();
                Console.WriteLine("总共从数据库读出来{0}条数据",reader.RecordsAffected);
                Console.WriteLine("当前服务器与数据库的连接状态为{0}",reader.IsClosed?"已关闭":"未关闭");
            }
            //DataTable dt = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(str, con);
            //con.Open();
            ////Console.WriteLine("连接成功");
            //sda.Fill(dt);
            //con.Close();
            //return dt;
        }
    }
}
