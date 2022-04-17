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
        public (string,string) task2(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                text = "Колода карт, значения карт которой только с 6 по 10, (20 листов) разбивается наугад на" +
                " две равные стопки по 10 листов. Найти вероятность того, что:" +
                "\nа) в первой стопке окажется ";
                int count1 = rand.Next(1, 5);
                text += (count1).ToString();
                if (count1 >= 2)
                    text += " десятки;";
                else
                    text += " десятка;";

                text += "\nб) в первой стопе окажется хотя бы ";
                int count2 = rand.Next(2, 4);
                text += (count2).ToString();
                if (count2 >= 2)
                    text += " десятки.";
                else
                    text += " десятка.";

                ulong ans1, ans2;
                (ans1,ans2) = TeorVer.Baes(20, 10, 4, count1);
                rezult = (ans1).ToString() +"/"+ (ans2).ToString() + "\n";

                double ans3 = 0;
                for (int i = 4; i >= count2; i--)
                {
                    (ans1, ans2) = TeorVer.Baes(20, 10, 4, i);
                    ans3 += Convert.ToDouble(ans1) / Convert.ToDouble(ans2);
                }
                rezult += string.Format("{0:0.000000}", ans3);

                return (text, rezult);
            }
            else
            {
                text = "В розыгрыше кубка по футболу участвуют 16 команд, среди которых ";
                int count1 = rand.Next(5, 8);
                text += (count1).ToString();

                text += " команд первой лиги. Все команды " +
                "по жребию делятся на две группы по 8 команд. Найти вероятность того, что:" +
                "\nа) все команды первой лиги попадут в одну группу;";

                text += "\nб) в одну группу попадут хотя бы ";
                int count2 = rand.Next(count1-3, count1);
                text += (count2).ToString();
                if (count2 != 5)
                    text += " команды первой лиги.";
                else
                    text += " команд первой лиги.";

                ulong ans1, ans2;
                (ans1, ans2) = TeorVer.Baes(16, 8, count1, count1);
                rezult = (ans1).ToString() + "/" + (ans2).ToString() + "\n";

                double ans3 = 0;
                for (int i = count2; i <= count1; i++)
                {
                    (ans1, ans2) = TeorVer.Baes(16, 8, count1, i);
                    ans3 += Convert.ToDouble(ans1) / Convert.ToDouble(ans2);
                }
                rezult += string.Format("{0:0.000000}", ans3);

                return (text, rezult);
            }
        }
        public (string,string) task3(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                text = "Эксперимент состоит в двух выстрелах по мишени. Событие А — попадание в мишень первым выстрелом; " +
                    "событие В — попадание в мишень вторым выстрелом. Постройте множество элементарных исходов и выявите" +
                    " состав подмножеств, соответствующих событиям:" +
                    "\nа) А U В;" +
                    "\nб) А ∩ В;" +
                    "\nв) ¬А U ¬В.";
                
                rezult += "Ω = {q00, q01, q10, q11}\n" +
                    "А U В = { q10, q01, q11}\nА ∩ В ={q11}\n¬А U ¬В = {q00, q10, q01}\nГде q00 - промах двумя выстрелами, " +
                    "q10 - попадание только первым выстрелом, q01 - попадание только вторым выстрелом, q11 - попадание двумя выстрелами.";

                return (text, rezult);
            }
            else
            {
                text = "Электронная схема содержит три транзистора, четыре конденсатора и пять резисторов. Событие Tk — выход из " +
                    "строя k-го транзистора(k = 1, 2, 3), событие Сi — выход из строя i-го конденсатора(i = 1, 2, 3, 4)," +
                    " Rj — выход из строя j -го резистора(j = 1, 2, 3, 4, 5). Электронная схема считается исправной," +
                    " если одновременно исправны все транзисторы, не менее двух конденсаторов и хотя бы один резистор." +
                    "\nЗаписать в алгебре событий событие А: схема исправна.";

                rezult += "A = T1*T2*T3*(C1*C2+C1*C3+C1*C4+C2*C3+C2*C4+C3*C4)*(R1+R2+R3+R4+R5)";

                return (text, rezult);
            }
        }
        public (string,string) task4(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                text = " В библиотеке университета путей сообщения есть две книги по теории вероятностей: В.Е.Гмурмана и " +
                    "А.А.Боровкова. Вероятность того, что в течение семестра будет затребована книга первого автора," +
                    " равна ";
                float count1 = rand.Next(4, 10)/10f;
                text += (count1).ToString();

                text += ", второго — ";
                float count2 = rand.Next(4, 10) / 10f;
                text += (count2).ToString();

                text += ". Какова вероятность того, что к концу семестра: " +
                    "\nа) ни одна, ни другая книга не будут затребованы;" +
                    "\nб) хотя бы одна из книг будет выдана;" +
                    "\nв) будет выдана только книга А. А.Боровкова?";
                
                rezult += string.Format("{0:0.00}", ((1-count1)*(1-count2)))+"\n"+ string.Format("{0:0.00}", 1 - (1 - count1) * (1 - count2)) +
                    "\n" + string.Format("{0:0.00}", (1 - count1) * (count2));
                return (text, rezult);
            }
            else
            {
                text = "Два рыбака ловят рыбу на озере. Вероятность поймать на удочку карася для первого равна ";
                float count1 = rand.Next(4, 10) / 10f;
                text += (count1).ToString();

                text += " для второго — ";
                float count2 = rand.Next(4, 10) / 10f;
                text += (count2).ToString();

                text += ". Какова вероятность того, что:" +
                    "\nа) они поймают хотя бы одного карася;" +
                    "\nб) вообще не поймают карасей;" +
                    "\nв) поймает карася только первый рыбак?";

                rezult += string.Format("{0:0.00}", 1 - (1 - count1) * (1 - count2)) +
                    "\n" + string.Format("{0:0.00}", (1 - count1) * (1 - count2)) + "\n" + string.Format("{0:0.00}", (count1) * (1-count2));

                return (text, rezult);
            }
        }
        public (string,string) task5(int chooseVar)
        {
            return ("","");
        }
        (string,string) task6(int chooseVar)
        {
            return ("","");
        }
        (string,string) task7(int chooseVar)
        {
            return ("","");
        }
        (string,string) task8(int chooseVar)
        {
            return ("","");
        }
        (string,string) task9(int chooseVar)
        {
            return ("","");
        }
        (string,string) task10(int chooseVar)
        {
            return ("","");
        }
        (string,string) task11(int chooseVar)
        {
            return ("","");
        }
        (string,string) task12(int chooseVar)
        {
            return ("","");
        }
        (string,string) task13(int chooseVar)
        {
            return ("","");
        }
        (string,string) task14(int chooseVar)
        {
            return ("","");
        }
        (string,string) task15(int chooseVar)
        {
            return ("","");
        }
        (string,string) task16(int chooseVar)
        {
            return ("","");
        }
        (string,string) task17(int chooseVar)
        {
            return ("","");
        }
        (string,string) task18(int chooseVar)
        {
            return ("","");
        }
        (string,string) task19(int chooseVar)
        {
            return ("","");
        }
        (string,string) task20(int chooseVar)
        {
            return ("","");
        }
        (string,string) task21(int chooseVar)
        {
            return ("","");
        }
        (string,string) task22(int chooseVar)
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
            (s1,s2) = test.task4(0);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.ReadKey();
        }
    }
}
