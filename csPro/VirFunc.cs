using System;


//namespace VirtualFunc
//{
//    class Enemy
//    {
//        public void Move()
//        {
//            Console.WriteLine("调用了 enemy的move方法");
//        }
//        public virtual void Attack()
//        {
//            Console.WriteLine("enemy attac");
//        }
//    }


//    class Boss : Enemy
//    {
//        public override void Attack()
//        {
//            Console.WriteLine("Boss Attac");
//        }

//        public new void Move()
//        {
//            Console.WriteLine("Boss move");
//        }
//    }

//    class Tester
//    {
//        static void Main(string[] args)
//            {
//                //---- 隐藏方法的调用----begin
//                Boss oneEnemy = new Boss();
//                oneEnemy.Move(); // 调用的是隐藏方法， 用子类的声明来调用的，调用的就是子类的Move。

//                Enemy twoEnemy = new Boss();
//                twoEnemy.Move(); // 调用的隐藏方法， 用父类的声明来调用的，调用的就是父类的Move方法。
//                                    //-----------------------end

//                //-----虚方法的调用----- begin
//                //用什么类型 来构造，在调用方法的时候就会调用什么类型的方法。

//                Enemy threeEnemy = new Enemy();
//                threeEnemy.Attack(); // 调用虚方法，用父类来实例化的，所以调用的是父类的Attac方法。

//                Enemy fourEnemy = new Boss();
//                fourEnemy.Attack();  // 调用虚方法，用子类来实例化的，所以调用的就是子类(Boss)的Attac方法。

//                //-----虚方法的调用------end

//                Console.ReadKey();
//            }
//    }
//}

//using System;
//namespace MySpace
//{
//    class Dad
//    {
//        protected string name;
//        public Dad(string n)
//        {
//            name = n;
//        }
//        public void Say()
//        {
//            Console.WriteLine("父类I am {0}.", name);
//        }
//        public virtual void growup()
//        {
//            Console.WriteLine("父类{0} has grown old.", name);
//        }
//    }
//    class son : Dad
//    {
//        public son(string n) : base(n)    // base调用基类的构造函数！！！
//        {
//            name = n;
//        }
//        public new void Say()
//        {
//            Console.WriteLine("子类I am {0} and a son.", name);
//        }
//        public override void growup()
//        {
//            base.growup();
//            Console.WriteLine("子类{0} is growing up.", name);
//        }
//    }
//    class entrance
//    {
//        public static void Main()
//        {
//            Dad grandpa = new Dad("grandpa");   //用父类生成的父类对象，grandpa，访问隐藏方法是父类的方法，访问重写方法是父类的方法
//            grandpa.Say();
//            grandpa.growup();
//            Dad father = new son("father");     //用子类生成的父类对象，father，访问隐藏方法是父类的方法，访问重写方法是子类的方法
//            father.Say();
//            father.growup();
//            son tom = new son("Tom");           //用子类生成的子类对象，son，访问隐藏方法是子类的方法，访问重写方法是子类的方法
//            tom.Say();
//            tom.growup();
//            Console.ReadKey();
//        }
//    }
//}


//using System;
//public class BaseClass
//{
//    protected string _className = "BaseClass";
//    public virtual void PrintName()
//    {
//        Console.WriteLine("Class Name: {0}", _className);
//    }
//}
//class DerivedClass : BaseClass
//{
//    public string _className = "DerivedClass";
//    public override void PrintName()
//    {
//        Console.Write("The BaseClass Name is {0}");
//        调用基类方法
//        base.PrintName();
//        Console.WriteLine("This DerivedClass is {0}", _className);
//    }
//}
//class TestApp
//{
//    public static void Main()
//    {
//        DerivedClass dc = new DerivedClass();
//        dc.PrintName();
//    }
//}

//class BaseTest
//{
//    public int a = 10;

//    protected int b = 2;
//}

//class ChildTest : BaseTest
//{
//    int c;

//    int d;

//    static void Main(string[] args)
//    {
//        BaseTest basetest = new BaseTest();

//        ChildTest childTest = new ChildTest();

//        Console.WriteLine(childTest.b);
//        Console.ReadLine();
//    }
//}
//class BaseTest
//{
//    public int a = 10;

//    protected int b = 2;
//}
//class ChildTest : BaseTest
//{
//    int c;
//    int d;

//    public void printTest()
//    {
//        BaseTest basetest = new BaseTest();

//        this.a = basetest.a;

//        this.c = basetest.b;//这句有错误
//        // 访问必须是通过派生类类型发生时，在派生类中的基类的protected类型成员才能够被访问
//    }
//}