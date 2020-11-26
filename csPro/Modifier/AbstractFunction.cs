using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro.Modifier
{
    abstract class ShapeClass
    {
        abstract public int Area();   // 抽象类方法只能申明在抽象类里，而且不能有方法主体括号，不能把抽象方法声明为static，抽象方法不能用base.func()来访问
                                      //如果抽象方法用的是 public abstract override int Area()，那么子类调用的时候也要重写Area()，也就是public override int Area()
                                      // sealed关键词，也就是密封类不能作为基类，这么做的原因是我们不希望类的层次太复杂，密封类不能有abstract关键词
                                      //sealed override public void F(){},在这个类的派生类中不能对这个方法进行重写
    }
    class Square : ShapeClass
    {
        int side;
        public Square(int n)
        {
            side = n;
        }
        public override int Area()     //  基类里的虚方法，继承的子类里必须都实现，哪怕是空的都可以
        {
            return side * side;
        }
    }
    class AbstractFunction
    {
        static void Main(string[] args)
        {
            Square sq = new Square(12);
            Console.WriteLine("Area of the square={0}",sq.Area());
            Console.ReadLine();
        }
    }
}
