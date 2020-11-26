using System;
using System.IO;

namespace DelegateAppl
{
    /*
    delegate int NumberChanger(int n);
    class TestDelegate
    {
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }

        static void Main(string[] args)
        {
            // 创建委托实例
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            // 使用委托对象调用方法
            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", getNum());
            Console.ReadKey();
        }
    }
    */
    /*
    delegate int NumberChanger(int n);
    namespace DelegateAppl
    {
        class TestDelegate
        {
            static int num = 10;
            public static int AddNum(int p)
            {
                num += p;
                return num;
            }

            public static int MultNum(int q)
            {
                num *= q;
                return num;
            }
            public static int getNum()
            {
                return num;
            }

            static void Main(string[] args)
            {
                // 创建委托实例
                NumberChanger nc;
                NumberChanger nc1 = new NumberChanger(AddNum);
                NumberChanger nc2 = new NumberChanger(MultNum);
                nc = nc1;
                nc += nc2;
                // 调用多播
                nc(5);   // 15*5 = 75   nc2的参数也是5传入的
                Console.WriteLine("Value of Num: {0}", getNum());
                Console.ReadKey();
            }
        }
    }
    */
    
        class PrintString
    {
        static FileStream fs;
        static StreamWriter sw;
        // 委托声明
        public delegate void printString(string s);

        // 该方法打印到控制台
        public static void WriteToScreen(string str)
        {
            Console.WriteLine("The String is: {0}", str);
        }
        // 该方法打印到文件
        public static void WriteToFile(string s)
        {
            fs = new FileStream("F:\\message.txt", FileMode.Append, FileAccess.Write);   // C,D盘符没有权限，导致的写不了文件
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        // 该方法把委托作为参数，并使用它调用方法
        public static void sendString(printString ps)
        {
            ps("Hello World");           //  这里的hello world其实就是相当于委托对应的方法里的参数
        }
        static void Main(string[] args)
        {
            printString ps1 = new printString(WriteToScreen);
            printString ps2 = new printString(WriteToFile);
            sendString(ps1);
            sendString(ps2);
            Console.ReadKey();
        }
    }
}