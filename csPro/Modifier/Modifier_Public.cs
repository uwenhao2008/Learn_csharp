using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 只有基类的字段，属性，方法，事件，索引指示器可以被继承，而基类的值，构造函数，析构函数都不能被继承
/// </summary>
namespace csPro.Modifier
{
    class A
    {
        public int x = 123;
        private int _x = 321;
        protected int _x_ = 143;
        internal char cha = 'C';    // 只要是namespace现同的class A的派生类，都可以访问次变量
    }
    class B : A
    {
        public int getBaseData()
        {
            return base._x_;      //  base关键字不能再静态方法中调用，也就是不能在static void Main()里直接使用
        }
        static void Main(string[] args)
        {
            B b = new B();
            b.x = 10;   // public修饰符  派生类可以继承并访问基类的
            //b._x = 10;   //  因为基类是private，所以派生类不能被继承
            b._x_ = 1000;  // 基类的protected，只有在派生类中才可以访问，即使是基类实例化的对象也不能访问

            Console.WriteLine(b.getBaseData());
            Console.ReadLine();
        }
    }
}
