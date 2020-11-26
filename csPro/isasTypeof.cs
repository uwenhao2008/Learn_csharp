using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace csPro
{
    class A
    {
    }
    class B:A {
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            if(a is A)
            {
                Console.WriteLine("实例a和类A的类型一样");
            }
            else {
                Console.WriteLine("实例a和类A的类型不一样");
            }
            if(b is A)
            {
                Console.WriteLine("实例b和类A的类型一样");
            }
            else
            {
                Console.WriteLine("实例b和类A的类型不一样");
            }
            if(a is B)
            {
                Console.WriteLine("实例a和类B的类型一样");
            }
            else
            {
                Console.WriteLine("实例a和类B的类型不一样");
            }
            if(b is B)
            {
                Console.WriteLine("实例b和类B的类型一样");
            }
            else
            {
                Console.WriteLine("实例b和类B的类型不一样");
            }
            Console.ReadLine();
  
            b = a as B;     //  使用as把实例a强制转换为类B，若不成功那么b九尾空引用null（这么做的好处是程序不会产生异常）
                            // b = a as A;   无法将类型“csPro.A”隐式转换为“csPro.B”。存在一个显式转换(是否缺少强制转换 ?) 

            if (b == null)
            {
                Console.WriteLine("获取到的b为null");
            }
            Console.WriteLine("此时的b为:{0}",b);
            Console.ReadLine();

            Type tp = typeof(StreamReader);
            Console.WriteLine(tp.FullName);

            if (tp.IsClass)
            {
                Console.WriteLine("这是一个类");
            }
            else
            {
                Console.WriteLine("这不是类");
            }
            Console.ReadLine();
        }
    }
}
