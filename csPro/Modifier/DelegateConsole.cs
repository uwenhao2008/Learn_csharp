using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro.Modifier
{
    public delegate void StrOp(ref string str);
    delegate string MyDelegate();
    class DelegateConsole
    {
        public static void Func1(ref string s)
        {
            Console.WriteLine("用连字符替换空格");
            s = s.Replace(' ', '-');
        }
        public static void Func2(ref string s)
        {
            string temp = "";
            Console.WriteLine("删除空格");
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i]!=' ')
                {
                    temp += s[i];
                }
            }
            s = temp;
        }
        static void Main(string[] args)
        {
            string str="";
            MyDelegate myreadline = new MyDelegate(Console.ReadLine);
            Console.WriteLine("请输入字符串");
            str = myreadline();
            Console.WriteLine("你输入的字符串是{0}", str);

            StrOp strop;
            StrOp op1 = Func1;
            StrOp op2 = Func2;

            string str1 = "Make American Great Again";
            strop = op1;

            strop(ref str1);
            Console.WriteLine("结果是："+ str1);
            Console.ReadLine();

            strop -= op1;
            strop += op2;

            str1 = "Come on!";

            strop(ref str1);
            Console.WriteLine("结果是：{0}",str1);
  
            Console.ReadLine();  
        }
    }
}
