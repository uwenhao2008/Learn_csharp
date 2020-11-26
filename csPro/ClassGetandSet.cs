using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class ClassGetandSet
    {
        private int money;
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value > 10)
                {
                    Console.WriteLine("该工作值得参与");
                    money = value;
                }
                else
                {
                    Console.WriteLine("不值得花精力");
                }
            }
        }

            static void Main(string[] args)
        {
            ClassGetandSet c = new ClassGetandSet();
            c.Money = 15;
            Console.WriteLine($"Code:{c.money}");   //  一个拼接字符串的简单方法
            Console.ReadLine();
        }
    }
}
