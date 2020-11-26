using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class MathCalculate
    {
        static void Main(string[] args)
        {
            int a = 21, b = 10, c;
            c = a + b;
            Console.WriteLine("Line1 - c:{0}", c);
            c = a - b;
            Console.WriteLine("Line2 - c:{0}", c);
            c = a * b;
            Console.WriteLine("Line3 - c:{0}", c);
            c = a / b;
            Console.WriteLine("Line4 - c:{0}", c);
            c = a % b;
            Console.WriteLine("Line5 - c:{0}", c);

            c = ++a;
            Console.WriteLine("Line6 - c:{0}", c);
            Console.WriteLine("Line7 - 此时a为:{0}", a);
            a = 21;    //  改变a的值
            c = a++;
            Console.WriteLine("Line8 - c:{0}", c);
            Console.WriteLine("Line9 - 此时a为:{0}", a);
            Console.ReadKey();
        }
    }
}
