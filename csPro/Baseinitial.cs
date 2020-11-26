using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 基类初始化
namespace csPro
{
    class Rectangle
    {
        protected double length;
        protected double height;
        public Rectangle(double l,double h)
        {
            length = l;
            height = h;
        }
        public double GetArea()
        {
            return length * height;
        }
        public void Display()
        {
            Console.WriteLine("长度{0}:",length);
            Console.WriteLine("宽度{0}:",height);
            Console.WriteLine("面积{0}:",GetArea());
        }
    }
    class Tabletop : Rectangle
    {
        private double cost;
        public Tabletop(double l, double h) : base(l, h)    //  通过base继承了基类构造函数
        {

        }
        
        public double GetCost()
        {
            cost = GetArea() * 0.7;
            return cost;
        }
        public void DisPlay()
        {
            base.Display();
            Console.WriteLine("成本是{0}",GetCost());
        }
    }
    class Baseinitial
    {
        static void Main(string[] args)
        {
            Tabletop t1 = new Tabletop(4.8,9.6);
            t1.DisPlay();
            
            Tabletop t2 = new Tabletop(48, 96);
            t2.DisPlay();
            Console.ReadLine();
        }
    }
}
