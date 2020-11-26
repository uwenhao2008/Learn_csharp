using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class CountClass
    {
        public CountClass(int n)
        {
            Console.WriteLine("这是第{0}个实例",n);
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                _ = new CountClass(i);
            }
            Console.ReadLine();   //  cr黑窗就在，cw就闪过
        }
    }
}
