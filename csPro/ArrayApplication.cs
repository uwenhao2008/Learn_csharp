using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class ArrayApplication
    {
        double GetAverage(int[] arr,int size)
        {
            //int i;
            double avg;
            int sum = 0;
            //for (i = 0; i < size; i++)
            //{
            //    sum += arr[i];
            //}
            foreach(int member in arr)
            {
                sum += member;
            }
            avg = sum / size;
            return avg;
        }
        //多维数组
        public int[,,] MultiArr()
        {
            int[,,] a = new int[2,3,4]
            {
                { {1,2,3,4 },{5,6,7,8 },{9,10,11,12 } },
                { {13,14,15,16 },{17,18,19,20 },{21,22,23,24 } }
            };
            return a;
        }

        public void PrintArr(int[,,] a)
        {
            //输出如下格式：第一个维度中长度为？，分别是？
            ///心得，语言不一样，所以就不要要求按照python的形式输出为[1,2,3,4,5,.....]了，给自己添加不必要的麻烦
            Console.WriteLine("欢迎进入地狱难度：~~~");
            for(int i = 0; i < a.GetLength(0); i++)
            {
                Console.WriteLine("进入第1个维度，维度大小为{0}：",a.GetLength(0));
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    Console.WriteLine("进入第2个维度，维度大小为：{0}",a.GetLength(1));
                    for (int k = 0; k < a.GetLength(2); k++)
                    {
                        Console.Write("{0} ",a[i, j, k]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public void MuArr()
        {
            int[,,] muarr = new int[2, 2, 3]
            {
                {{1,2,3},{4,5,6}},
                {{7,8,9},{2,3,4}}
            };

            int rank = muarr.Rank;
            Console.WriteLine("该多维数组的维数为:{0}", rank);
            int rlength = muarr.GetLength(1);
            Console.WriteLine("该多维数组的第二维有{0}个元素", rlength);
            Console.WriteLine("开始遍历多维数组");
            Console.WriteLine("----------------------------------");
            int wei = 0;
            for (int i = 0; i < muarr.GetLength(0); i++)
            {
                for (int js1 = 0; js1 < muarr.GetLength(1); js1++)
                {
                    for (int js2 = 0; js2 < muarr.GetLength(2); js2++)
                    {
                        Console.WriteLine("最低维度{0}的值为{1}", wei, muarr[i, js1, js2]);
                    }
                    ++wei;
                }
            }
        }

        public void CrossArr()
        {
            //交错数组
            int[][] arr = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 },
                                        new int[] { 5, 6 }, new int[] { 7, 8 } };// System.Int32[][]
            int i, j;
            Console.WriteLine(arr.GetLength(0)); // 4
            //Console.WriteLine(arr.Length);  // 4
            Console.WriteLine("--->>>这里的维度为{0}",arr.Rank);

            for (i = 0; i < arr.GetLength(0); i++)
            {
                for (j = 0; j < 2; j++)
                {
                    Console.WriteLine("arr[{0}][{1}]:{2}",i,j,arr[i][j]);   //搞了半天是这里出错了，参数不匹配。我只一直以为是循环的错
                }
            }
        }

        //传递形参 关键字：param
        public int AddElements(params int[] arr)
        {
            int sum = 0;
            foreach(int i in arr)
            {
                sum += i;
            }
            return sum;
        }


        public void PriArr(int[] a)
        {
            foreach(int member in a)
            {
                Console.Write(member);
            }
        }

        static void Main(string[] args)
        {
            ArrayApplication app = new ArrayApplication();
            int[] balance = new int[] {1000,2,48,36,58 };
            double avg;
            avg = app.GetAverage(balance, 5);
            Console.WriteLine("balance的均值为：{0}",avg);
            //foreach(int str in balance)
            //{
            //    Console.Write(str);
            //}
            Console.WriteLine(app.MultiArr().GetLength(2));
            //int val = app.MultiArr().Length; //24
            //int val = app.MultiArr().GetLength(0);  //2  哲理指第一个维度，即{{},{}}第一个打括号里的小括号数量
            int val = app.MultiArr()[0,1,2];  //7
            Console.WriteLine(val);
            app.PrintArr(app.MultiArr());
            app.MuArr();
            app.CrossArr();
            Console.WriteLine("求得的总和为{0}", app.AddElements(new int[] { 1, 2, 3, 4, 5 }));
            Console.ReadLine();
        }
    }
}
