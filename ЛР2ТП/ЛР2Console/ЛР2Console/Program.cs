using System;
using System.IO;

namespace ЛР2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] odd = new string[4];
            FileStream myfile = new FileStream("E:/учеба/Технологии программирования/ЛР2ТП", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(myfile);
            reader.Close();
            myfile.Close();
        }
    }
}
