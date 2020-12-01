using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class xigouFunc
    {
        public xigouFunc()
        {
            Console.WriteLine("进入了构造函数");
        }
        ~xigouFunc()
        {
            Console.WriteLine("进入了析构函数");
        }
        static void Main(string[] args)
        {
            xigouFunc xg = new xigouFunc();   // 进入构造函数
            xg = null;                        // 进入析构函数   实际上不需要这行，对象不使用的时候也会自动析构的  程序员无法直接操作析构函数，只能通过GC来实现
            Console.ReadLine();
        }
    }
}
