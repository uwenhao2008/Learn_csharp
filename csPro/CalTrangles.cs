using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class Rectangle {
        internal double length;
        internal double height;

        public double GetArea() {
            return length * height;
        }
        public void AcceptDetail()
        {
            Console.WriteLine("请输入长度length：");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入高度height：");
            height = Convert.ToDouble(Console.ReadLine());
        }
    }

    class CalTrangles
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.length = 15;
            r.height = 18;    //  因为private所以不可访问
            //r.AcceptDetail();
            Console.WriteLine("得到的面积area为：{0}*{1}={2}",r.length,r.height, r.GetArea());
            Console.ReadKey();
        }
    }
}
