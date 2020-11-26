using System;
namespace useofThrow
{
    class useThrow{
        static void Main(string[] args)
        {
            try
            {
                throw new Exception("抛出错误玩玩而已");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString()+"<--->");  // 显示的内容相当丰富
            }
            Console.ReadLine();
        }    
    }
}