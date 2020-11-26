using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro.Modifier
{
    class Vehicle
    {
        public int wheels; //轮胎通用
        private float weight; //
        public Vehicle(int w,float g)
        {
            wheels = w;
            weight = g;
            Console.WriteLine("{0}",this.weight);    // 这里有this和没有this有区别吗？
        }
    }
    class Car : Vehicle
    {
        int passenger;
        public Car(int w,float g,int p) : base(w, g)    //  w,g都是来自于基类
        {
            passenger = p;
        }
        public void Show()
        {
            Console.WriteLine("the wheels of Car is:{0}",wheels);
            Console.WriteLine("the passengeris:{0}",passenger);
        }
    }
    class CarModifier
    {
        public static void Main(string[] args)
        {
            Car c1 = new Car(0, 2, 4);   // Main()方法没有对基类方法的调用，但是该方法通过base关键字调用了，因此成员字段被实例化了
            c1.Show();
            Console.ReadLine();
        }
    }
}
