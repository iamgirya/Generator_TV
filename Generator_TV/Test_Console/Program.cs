using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Console
{
    class Generator_TV
    {
        //наши варианты 1 и 6 из файла.
        public (string, string) task1(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                text = "Наугад выбирается номер телефона из ";
                int count = rand.Next(6,10);
                text += (count).ToString();
                text += " цифр. Найти вероятность того, что:\nа) это номер телефона А. Б. Пугачевой;\nб) все цифры номера различны.";

                int ans1 = 1;
                rezult = "1/"+(Math.Pow(10,count)).ToString() + "\n";

                ans1 = 1;
                for (int i = 1; i < count; i++)
                    ans1 *= (10 - i);
                rezult += ans1.ToString() + "/" + (Math.Pow(10, count-1)).ToString();

                return (text,rezult);
            }
            else
            {
                text = "Пронумерованные ";
                int count1 = rand.Next(8, 11);
                text += (count1.ToString());
                text += " вариантов контрольной работы по математике распределяются случайным образом среди ";

                int count2 = rand.Next(count1-2, count1);
                text += (count2.ToString());
                text += " студентов, сидящих в одном ряду. Каждый получает по одному варианту. Найти вероятность того, что:" +
                    "\nа) варианты 1'й и 2'й достанутся первым двум студентам;\nб) первые ";

                int count3 = rand.Next(count2 - 2, count2);
                text += (count2.ToString());
                text += " вариантов распределятся последовательно.";

                rezult = "2/" + (count1*(count1-1)).ToString() + "\n";

                int ans1 = 1;
                for (int i = 0; i < count3; i++)
                    ans1 *= (count1 - i);
                rezult += "1/" + (ans1).ToString();

                return (text, rezult);
            }
        }
        (string,string) task2()
        {
            return ("","");
        }
        (string,string) task3()
        {
            return ("","");
        }
        (string,string) task4()
        {
            return ("","");
        }
        (string,string) task5()
        {
            return ("","");
        }
        (string,string) task6()
        {
            return ("","");
        }
        (string,string) task7()
        {
            return ("","");
        }
        (string,string) task8()
        {
            return ("","");
        }
        (string,string) task9()
        {
            return ("","");
        }
        (string,string) task10()
        {
            return ("","");
        }
        (string,string) task11()
        {
            return ("","");
        }
        (string,string) task12()
        {
            return ("","");
        }
        (string,string) task13()
        {
            return ("","");
        }
        (string,string) task14()
        {
            return ("","");
        }
        (string,string) task15()
        {
            return ("","");
        }
        (string,string) task16()
        {
            return ("","");
        }
        (string,string) task17()
        {
            return ("","");
        }
        (string,string) task18()
        {
            return ("","");
        }
        (string,string) task19()
        {
            return ("","");
        }
        (string,string) task20()
        {
            return ("","");
        }
        (string,string) task21()
        {
            return ("","");
        }
        (string,string) task22()
        {
            return ("","");
        }

        void Generate(int numVar, int startTask, int endTask)
        {
            for (int k = 0; k < numVar; k++)
            {

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Generator_TV test = new Generator_TV();
            string s1, s2;
            (s1,s2) = test.task1(2);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}
