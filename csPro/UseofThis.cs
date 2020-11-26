using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// this的用法
/// </summary>
namespace csPro
{
    class UseofThis
    {
        //public int a;
        static int a;

        //public void run()
        static void run()
        {
            int a = 3;
            Console.WriteLine("方法run的a为：{0}",a);
            //Console.WriteLine("类UseofThis的a为：{0}",this.a);
            Console.WriteLine("类UseofThis的a为：{0}",a);
        }
        static void Main(string[] args)
        {
            UseofThis ut = new UseofThis();
            UseofThis.a = 15;
            //ut.a = 15;
            //ut.run();
            UseofThis.run();
            Console.ReadLine();
        }
    }
}
