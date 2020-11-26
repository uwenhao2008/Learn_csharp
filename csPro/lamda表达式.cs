using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    public delegate int ADelegate(int abm);
    public delegate bool BDelegate(int abm);
    public delegate string ChangeStr(string str);
    class Program
    {
        static void Main(string[] args)
        {
            ADelegate a = (count) => count + 5;             // lambda  左边的count是参数，单个参数可以不用括号， =>右边的是执行的函数
            int x = 0;
            Console.WriteLine("使用lambda表达式ADelegate");
            for (int i = 0; i < 10; i++)
            {
                x = a(x);
                Console.WriteLine(x);
            }
            Console.ReadLine();
            BDelegate b = n => n % 5==0;
            Console.WriteLine("使用lambda表达式BDelegate");
            for(int i = 1; i < 20; i++)
            {
                if (b(i))
                {
                    Console.WriteLine(i+"可以被5整除");
                }
            }
            Console.ReadLine();

            ChangeStr Func1 = s =>
            {
                Console.WriteLine("用连字符替换空格");
                return s.Replace(' ', '-');
            };         //  lambda最后有分号
            ChangeStr Func2 = s =>
            {
                string temp ="";
                Console.WriteLine("删除空格");
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != ' ')
                    {
                        temp += s[i];
                    }
                }
                return temp;
            };      //  lambda最后有分号
            ChangeStr cstr = Func1;   //   实例化对象（委托对象）
            string str = cstr("This is China!");
            Console.WriteLine("结果是："+ str);
            Console.ReadLine();

            cstr = Func2;
            Console.WriteLine("现在的s是："+ str + "，但是马上就会变");
            string ss = "This is 啊 pig";
            str=cstr(ss);
            Console.WriteLine("结果是：" + str);
            Console.ReadLine();
        }
    }
}
