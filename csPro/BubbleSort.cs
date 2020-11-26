using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class ArrayData
    {
        public void PrintArray()    // 二维数组
        {
            int[,] array1;
            array1 = new int[2, 3] { { 1,2,3},{ 4,5,6} };
            Console.WriteLine(array1[2,2]);
        }
        public void jaggedArray()  // 交错数组
        {
            //int[][] jaggedArray = new int[4][];   // 行数一定要给出
            int[][] jaggedArray = new int[][] { 
                                        new int[]{1},
                                        new int[]{4,3,2},
                                        new int[]{22,33,44,77},
                                        new int[]{111,213,441}
                                   };  
            for(int i=0;i< jaggedArray.Length; i++)
            {
                Console.Write("Element({0})=>",i);
                for(int j=0;j< jaggedArray[i].Length; j++)
                {
                    Console.Write("{0}{1}",jaggedArray[i][j],j==(jaggedArray[i].Length-1)?"":" ");
                }
                Console.WriteLine();
            }
        }
        int[] arr3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public void ParmRef(ref int x,ref int y)    //  改变用作参数的变量的值
        {
            arr3[1] = x;
            arr3[2] = y;
            foreach(int n in arr3)
            {
                Console.Write(n+" ");
            }
            Console.WriteLine();
        }
        public void ParmRefArray(ref int[] arr)
        {
            arr[3] = 3333;
            arr[4] = 4444;
            foreach(int i in arr)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }

        public int ParmOut(int x,int y,out float ox)
        {
            int result;
            result = x / y;
            //ox = (float)x /y;  // 注意这里的类型转换，非常好
            ox = x*1.0f /y;  // 注意这里的类型转换，非常好
            return result;
        }

        public void FillArray(out int[] arr3)
        {
            arr3 = new int[] { 1, 2, 3, 4, 5, 6 };
        }
        //main里调用FillArray(out theArray)后，那么theArray就可以作为数组来被使用了，这里提供了一种初始化的方法
    }
    class ContinueAndBreak
    {
        public void PrintEvenNumber()
        {
            for(int i = 0; i < 50; i++)
            {
                if (i == 47)
                {
                     Console.WriteLine("当i为{0}时跳出了循环，以后再也不会出现{1}", i, i + 1);
                     break;
                }
                if (i % 2 != 0) continue;    // i为偶数才输出
                Console.WriteLine(i);
            }
        }
    }
    
    class VaryingArguments
    {
        public static void DisplayItem(params int[] item)
        {
            Console.WriteLine("欢迎进入关键词param用法解析");
            for(int i = 0; i < item.Length; i++)    // param实现了传入的参数是个数组的作用
            {
                Console.Write(item[i]+"\t");
            }
            Console.WriteLine();
        }
    }
    class BubbleHelper
    {
        public void bubbleSort(int[] array)
        {
            int length = array.Length;
            for(int i = 0; i < length - 2; i++)
            {
                for(int j = length - 1; j >= 1; j--)
                {
                    if (array[j] < array[j - 1])   // 相邻右边的数字大于左边的，就交换
                    {
                        int temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                    PrintArr(array);
                }
            }
        }
        public void PrintArr(int[] arr)
        {
            int lentgh = arr.Length;
            for(int i = 0; i < lentgh; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("--->");
        }
        static void Main(string[] args)
        {
            BubbleHelper bubble = new BubbleHelper();
            bubble.bubbleSort(new int[] { 10, 1, 35, 61, 89,36,55 });
            ContinueAndBreak cb = new ContinueAndBreak();
            cb.PrintEvenNumber();
            ArrayData arr = new ArrayData();
            arr.jaggedArray();

            int i = 11, j = 22;
            arr.ParmRef(ref i,ref j);

            float o = 1000;   // 定义的o变量1000其实没有用，但是这里不定义就会提示下文找不到o
            int result = arr.ParmOut(8, 5, out o);
            Console.WriteLine("result为：{1},o为：{0}",o,result);
            int[] arr_temp = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            arr.ParmRefArray(ref arr_temp);    //  ref直接改变了作为参数的数组

            VaryingArguments.DisplayItem(1, 2, 3, 4);
            VaryingArguments.DisplayItem(new int[] { 11,22,33,44,55});

            Console.ReadLine();
        }
    }
}
