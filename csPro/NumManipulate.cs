using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class NumManipulate
    {
        public int FindMax(int num1, int num2) {
            int result;
            if (num1 > num2)
            {
                result = num1;
            }
            else {
                result = num2;
            }
            return result;
        }
        //递归调用
        public int Factorial(int num) {
            int result;
            if (num == 1){
                return 1;
            }
            else {
                result = Factorial(num - 1) * num;
                return result;
            }  
        }

        public void ArrayList() {
            int[] n = new int[10];
            int i, j;
            for (i = 0; i < 10; i++)
            {
                n[i] = i+100;
            }
            for (j = 0; j < 10; j++)
            {
                Console.WriteLine("Element[{0}]:{1}",j,n[j]);
            }
            Console.WriteLine("进入新阶段：");
            foreach(int a in n)
            {
                int b = a - 100;
                Console.WriteLine("Element[{0}]:{1}",b,a);
            }
        }

        static void Main(string[] args)
        {
            int a = 100;
            int b = 222;
            int ret;

            NumManipulate n = new NumManipulate();
            ret = n.FindMax(a, b);
            Console.WriteLine("最大值：{0}", ret);
            Console.WriteLine("fac(5):{0}",n.Factorial(5));
            n.ArrayList();
            Console.ReadLine();
        }

    }
}
