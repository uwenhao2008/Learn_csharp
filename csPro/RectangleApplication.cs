using System;

namespace RectangleApplication
{
    class Rectangle
    {
        double length;
        double width;
        public void AcceptDetails()
        {
            length = 4.5;
            width = 3.5;
        }
        public double GetArea() {
            return length * width;
        }
        public void Display() {
            double i = 96.256;
            bool b = true;
            Console.WriteLine("length:{0}", length);
            Console.WriteLine("width:{0}", width);
            Console.WriteLine("area:{0}", GetArea());
            Console.WriteLine("double i转换为int是：{0}", (int)i);
            Console.WriteLine("boll b转换为string是：{0}", b.ToString());
            //Console.WriteLine("i强制转换为string是：{0}", (int)i);
        }
        
        class ExecuteRectangle {
            static void Main(string[] args){
                Rectangle r = new Rectangle();
                r.AcceptDetails();
                r.Display();
                //int num = Convert.ToInt32((Console.ReadLine()).GetType());    // (Console.ReadLine()).GetType() -->string
                int num = Convert.ToInt32((Console.ReadLine()));    // (Console.ReadLine()).GetType() -->string
                Console.WriteLine(num);
                Console.ReadLine();
            }
        }
    }
}
