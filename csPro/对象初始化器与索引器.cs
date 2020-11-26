using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class MyCalss
    {
        public int Count { get; set; }
        public char @class { get; set; }
    }
    class useofIndex
    {
        private long[] arr = new long[100];
        private char[] array = new char[100];
        public long this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
        public char this[char index]
        {
            get
            {
                return ++array[index];
            }
            set
            {
                array[index] = value;
            }
        }
    }
    class objInitDemo
    {
        static void Main(string[] args)
        {
            MyCalss obj = new MyCalss() { Count=100,@class='A'};
            // 构造函数有强制性，对象初始化器可以选择性操作，但是只能初始化属性，但是构造函数的操作余地大很多
            // 对象初始化器只能在创建对象的时候使用，而构造函数是写在类里的
            Console.WriteLine("Count:{0},@class:{1}",obj.Count,obj.@class);

            useofIndex u = new useofIndex();
            u[15] = 100;
            u['M'] = 'A';
            Console.WriteLine("u[15]:{0}",u[15]);
            Console.WriteLine("u['M']:{0}",u['M']);
            Console.WriteLine("u['a']:{0}",u['a']);
            Console.WriteLine("u[33]:{0}",u[33]);

            Console.ReadLine();
        }
    }
}
