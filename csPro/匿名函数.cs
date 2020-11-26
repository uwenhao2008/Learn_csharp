using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    delegate int Func(int tem);
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            Func func = delegate (int tem)
                      {
                          int b = 0;
                          for (int i = 0; i <= tem; i++)
                          {
                              Console.WriteLine(i);
                              b += i;
                          }
                          return b;    //  这里使得匿名函数有了返回值
                      };           //   这里有分号
            a = func(5);
            Console.WriteLine("从0加到5的和为："+a);
            a = func(10);
            Console.WriteLine("从0加到10的和为："+a);
            Console.ReadLine();
        }
    }
}
