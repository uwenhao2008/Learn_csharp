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

namespace csPro
{
    class ConSql
    {
        static void Main(string[] args)
        {
            StringBuilder sqlPath = new StringBuilder();
            sqlPath.Append("Data Source=127.0.0.1;");
            sqlPath.Append(@"Initial Catalog=fastMan_bhgyh;");
            sqlPath.Append("User Id=sa;Password=wen4632022;");
            string connectString = sqlPath.ToString();   //转换为连接字符串

            SqlConnection objConnection = new SqlConnection(connectString);
            objConnection.Open();   // 打开数据库连接
            if (objConnection.State == ConnectionState.Open)
            {
                Console.WriteLine("已建立数据库连接");
            }
            else
            {
                Console.WriteLine("未建立数据库连接");
            }

            //执行sql
            string strSQL = "SELECT sUserName,iUserID FROM [fastmanowner].[FSys_User]";
            //  实例化一个命令处理对象
            SqlCommand sc1 = new SqlCommand();
            sc1.CommandText = strSQL;        //指定对象需要执行的sql
            sc1.Connection = objConnection;  // 指定对象连接的数据库
            //处理命令
            SqlDataReader sda = sc1.ExecuteReader();      //执行命令的方法，并返回结果
            if (sda.HasRows)   // 结果不为空
            {
                int icount = sda.FieldCount;//捕获结果中的数据的列数
                Console.WriteLine("返回的信息");
                while (sda.Read())   //  开始读取信息
                {
                    for (int i = 0; i < icount; i++)
                    {
                        Console.Write(sda[i] + " ");  // 获取每一列的数据
                    }
                    Console.WriteLine();
                }
            }
            objConnection.Close();
            Console.ReadLine();
        }
    }
}
