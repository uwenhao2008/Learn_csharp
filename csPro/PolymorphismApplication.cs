using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismApplication
{
    class Shape
    {
        protected int width, height;
        public Shape(int a = 0, int b = 0)
        {
            width = a;
            height = b;
        }
        public virtual int area()
        {
            Console.WriteLine("父类的面积：");
            return 0;
        }
    }
    class Rectangle : Shape
    {
        public Rectangle(int a = 0, int b = 0) : base(a, b)
        {

        }
        public override int area()
        {
            Console.WriteLine("Rectangle 类的面积：");
            return (width * height);
        }
    }
    class Triangle : Shape
    {
        public Triangle(int a = 0, int b = 0) : base(a, b)
        {

        }
        public override int area()
        {
            Console.WriteLine("Triangle 类的面积：");
            return (width * height / 2);
        }
    }
    class Caller
    {
        public void CallArea(Shape sh)    //  类还可以当作参数
        {
            int a;
            a = sh.area();
            Console.WriteLine("面积： {0}", a);
        }
    }
    class Tester
    {

        static void Main(string[] args)
        {
            Caller c = new Caller();
            Rectangle r = new Rectangle(10, 7);
            Triangle t = new Triangle(10, 5);
            c.CallArea(r);
            c.CallArea(t);
            Console.ReadKey();
        }
    }
}
