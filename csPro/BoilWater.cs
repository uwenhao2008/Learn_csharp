using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;


// 重构检查者模式，其实就是委托事件
namespace csPro
{
    class Heater
    {
        private int temperature;
        //声明事件
        public delegate void BoilHandler(int parm);
        //声明委托
        public event BoilHandler BoilEvent;

        //烧水
        public void BoilWater()
        {
            for (int i = 1; i < 101; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    if (BoilEvent != null)
                    {
                        BoilEvent(temperature);
                    }
                }
                else if (temperature > 90)
                {
                    Console.WriteLine("阶段90，现在的温度是{0}度", temperature);
                    Thread.Sleep(200);
                }
                else if (temperature > 60)
                {
                    Console.WriteLine("阶段60，现在的温度是{0}度", temperature);
                    Thread.Sleep(200);
                }
            }
        }



    }
    public class Alert
    {
        public void MakeAlert(int temperature)
        {
            Console.WriteLine("嘀嘀嘀~~~~当前温度{0}摄氏度", temperature);
        }
    }
    public class Show
    {
        public static void ShowTemp(int temperature)
        {
            Console.WriteLine("水快开了，小心啊");
        }
    }
    class Display
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            heater.BoilEvent += (new Alert()).MakeAlert;
            heater.BoilEvent += Show.ShowTemp;

            heater.BoilWater();
            Console.ReadLine();
        }
    }
}
