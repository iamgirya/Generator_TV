using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace W_Gen
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
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {

                text = "Два гроссмейстера играют две партии в шахматы. Вероятность выигрыша в одной партии для первого" +
                    " шахматиста равна ";
                float count1 = rand.Next(1, 5) / 10f;
                text += (count1).ToString();     
                text += ", для второго — ";
                float count2 = rand.Next(1, 5) / 10f;
                text += (count2).ToString();
                text += "; вероятность ничьей — ";
                float count3 = 1 - count1 - count2;
                text += (count3).ToString();
                text += ". Какова вероятность того," +
                    " что первый гроссмейстер выиграет матч?";

                rezult += (count1*(1-count2) + count3*count1).ToString();
                return (text, rezult);
            }
            else
            {
                text = "Барон вызвал графа на дуэль. В пистолетах у дуэлянтов по два патрона. Вероятность попадания в " +
                    "своего противника для барона(он и начинает дуэль) равна ";
                float count1 = rand.Next(3, 8) / 10f;
                text += (count1).ToString();
                text += ", для графа — ";
                float count2 = rand.Next(3, 8) / 10f;
                text += (count2).ToString();
                text += ". Найти вероятность того, что барон останется невредимым, если дуэль продолжается " +
                    "либо до первого попадания в кого-либо из противников, либо до тех пор, пока не закончатся все патроны.";

                rezult += (count1 + (1-count1)*(1-count2)*(count1+ (1 - count1) * (1 - count2))).ToString();
                return (text, rezult);
            }
        }
        public  (string,string) task6(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                text = "В мешке ";
                float count1 = rand.Next(3, 9) ;
                text += (count1).ToString();
                text += " красных и ";
                float count2 = rand.Next(3, 9);
                text += (count2).ToString();
                text += " зеленых шаров. Проводится испытание по последовательному извлечению двух шаров " +
                    "без возвращения. Найдите вероятность того, что второй шар будет зеленый, если известно, что первый шар был красный.";

                rezult += count2.ToString() + "/" + (count2 + count1 - 1).ToString();
                return (text, rezult);
            }
            else
            {
                text = "В корзине ";
                float count1 = rand.Next(15, 30);
                text += (count1).ToString();
                text += " шаров, среди которых ";
                float count2 = rand.Next(5, 15);
                text += (count2).ToString();
                text += " оранжевых. Из нее поочередно извлекаются три шара. Найти вероятность того, что все вынутые шары оранжевые";

                rezult += (count2* (count2-1)*(count2-2)).ToString() + "/" + (count1 * (count1 - 1) * (count1 - 2)).ToString();
                return (text, rezult);
            }
        }
        public (string,string) task7(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                text = "К кладу ведут три дороги. Вероятность погибнуть на первой дороге равна ";
                float count1 = rand.Next(3, 8) / 10f;
                text += (count1).ToString();
                
                text += ", на второй — ";
                float count2 = rand.Next(2, 6) / 10f;
                text += (count2).ToString();

                text += ", на третьей — ";
                float count3 = rand.Next(1, 5) / 10f;
                text += (count3).ToString();

                text += ". Найти вероятность того, что ковбой доберется до клада по одной из них при условии," +
                    " что дорога выбирается им наудачу.";

                rezult += (count2+count1+ count3).ToString() + "/" + (3).ToString();
                return (text, rezult);
            }
            else
            {
                text = "В диагностическом центре прием больных ведут три невропатолога: Фридман, Гудман и Шеерман," +
                    " которые ставят правильный диагноз с вероятностью ";
                float count1 = rand.Next(3, 8) / 10f;
                text += (count1).ToString();

                text += ", ";
                float count2 = rand.Next(2, 6) / 10f;
                text += (count2).ToString();

                text += " и ";
                float count3 = rand.Next(1, 5) / 10f;
                text += (count3).ToString();

                text += " соответственно. Какова вероятность того, что больному Сидорову будет поставлен" +
                    " неверный диагноз, если он выбирает врача случайным образом.";

                rezult += ((1-count2) + (1 - count1) + (1 - count3)).ToString() + "/" + (3).ToString();
                return (text, rezult);
            }
        }
        public (string,string) task8(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                text = "Перед математической олимпиадой особой популярностью пользовались " +
                    "книги Якова Исидоровича Перельмана: в библиотеке ";
                float count1 = rand.Next(10, 20);
                text += (count1).ToString();

                text += " раз заказывали его книгу «Живая математика», ";
                float count2 = rand.Next((int)(count1-5), (int)(count1));
                text += (count2).ToString();

                text += " раз — «Занимательные задачи», ";
                float count3 = rand.Next((int)(count2 - 2), (int)(count2));
                text += (count3).ToString();

                text += " раз — «Загадки и диковинки в мире чисел». Подбор задач для олимпиады таков, что вероятность" +
                    " решить задачу студенту, прочитавшему книгу «Живая математика», равна ";
                float count4 = rand.Next(1,6) / 10f;
                text += (count4).ToString();

                text += ", «Занимательные задачи» — ";
                float count5 = rand.Next(2,8) / 10f;
                text += (count5).ToString();

                text += ", «Загадки» — ";
                float count6 = rand.Next(4,7) / 10f;
                text += (count6).ToString();

                text += ". Студент Филькин радостно сообщил, что решил задачу на олимпиаде. Какую книгу Перельмана" +
                    " вероятнее всего он прочитал?";

                float sum = count1 + count2 + count3;
                if ((count1 / sum) * count4 > (count2 / sum) * count5)
                    if ((count1 / sum) * count4 > (count3 / sum) * count6)
                        rezult += "Живая математика";
                    else
                        rezult += "Загадки и диковинки в мире чисел";
                else
                    if ((count2 / sum) * count4 > (count3 / sum) * count6)
                        rezult += "Занимательные задачи";
                    else
                        rezult += "Загадки и диковинки в мире чисел";

                return (text, rezult);
            }
            else
            {
                text = "В зоопарке живут ";
                float count1 = rand.Next(2,7);
                text += (count1).ToString();

                text += " кенгуру, ";
                float count2 = rand.Next(5,10);
                text += (count2).ToString();

                text += " муравьедов и ";
                float count3 = rand.Next(7, 12);
                text += (count3).ToString();

                text += " горилл. Условия содержания млекопитающих таковы, что вероятность заболеть у" +
                    " этих животных соответственно равна ";
                float count4 = rand.Next(1,8) / 10f;
                text += (count4).ToString();

                text += ", ";
                float count5 = rand.Next(1,9) / 10f;
                text += (count5).ToString();

                text += " и ";
                float count6 = rand.Next(4,8) / 10f;
                text += (count6).ToString();

                text += ". Животное, которое удалось поймать врачу, оказалось здоровым. Какова " +
                    "вероятность того, что врач осматривал муравьеда?";

                rezult += (((1-count5)*(count2/(count1+count2+count3)))/
                    (((1 - count5) * (count2 / (count1 + count2 + count3)))+
                    ((1 - count4) * (count1 / (count1 + count2 + count3))) +
                    ((1 - count6) * (count3 / (count1 + count2 + count3))))).ToString();

                return (text, rezult);
            }
        }
        public (string,string) task9(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                float count1 = rand.Next(10, 20) / 100f;
                int count2 = rand.Next(5, 7);
                int count3 = rand.Next(count2 - 2, count2);

                text = string.Format("При передаче сообщения вероятность искажения одного знака равна {0}. Какова вероятность того," +
                    " что сообщение из {1} знаков содержит:" +
                    "\nа) {2} неправильных знака;" +
                    "\nб) не менее {2} неправильных знаков?", count1.ToString(), count2.ToString(), count3.ToString());

                double ans = 0;
                for (int i = count3; i <= count2; i++)
                {
                    ans += TeorVer.Bernulli(count2, i, count1);
                }

                rezult += (TeorVer.Bernulli(count2, count3, count1)).ToString() + "\n" + (ans).ToString();
                return (text, rezult);
            }
            else
            {
                float count1 = rand.Next(10, 20) / 100f;
                int count2 = rand.Next(5, 7);
                int count3 = rand.Next(count2 - 2, count2);

                text = string.Format("В поезде {1} электрических лампочек. Каждая из них перегорает" +
                    " в течение года с вероятностью {0}. Найти вероятность того, что в течение года" +
                    " перегорит не менее {2} лампочек.", count1.ToString(), count2.ToString(), count3.ToString());

                double ans = 0;
                for (int i = count3; i <= count2; i++)
                {
                    ans += TeorVer.Bernulli(count2, i, count1);
                }

                rezult += (ans).ToString();
                return (text, rezult);
            }
        }
        public (string,string) task10(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                float count1 = rand.Next(40, 61) / 100f;
                int count2 = rand.Next(6, 10)*10;
                int count3 = rand.Next(count2 - 2, count2);

                text = string.Format("Вероятность рождения мальчика равна {0}. Чему равна вероятность того," +
                    " что среди {1} новорожденных:\nа) мальчиков ровно половина;" +
                    "\nб) не менее половины мальчиков", count1.ToString(), count2.ToString());

                double sqrt = Math.Sqrt(count2*(1-count1)*count1);

                rezult += (1/sqrt).ToString() + " * ф("+((count2/2-count2*count1)/sqrt).ToString() +")\n" 
                    +"Ф("+ ((count2 / 2 - count2 * count1) / sqrt).ToString() + ") - Ф(" + ((- count2 * count1) / sqrt).ToString() + ")";
                return (text, rezult);
            }
            else
            {
                float count1 = rand.Next(4, 9) / 10f;
                int count2 = rand.Next(8, 11) * 10;
                int count3 = rand.Next(count2/10-3, count2/10)*10;

                text = string.Format("Имеется {1} станков равной мощности, работающих независимо друг от друга в" +
                    " одинаковом режиме при включенном приводе в течение {0} всего рабочего времени. Какова вероятность" +
                    " того, что в произвольный момент окажутся включенными:\nа) от {3} до {4} станков;" +
                    "\nб) ровно {2} станков ? ", count1.ToString(), count2.ToString(), count3.ToString(), (count3-20).ToString(), (count3 - 5).ToString());

                double sqrt = Math.Sqrt(count2 * (1 - count1) * count1);

                rezult += "Ф(" + (((count3 - 5) - count2 * count1) / sqrt).ToString() + ") - Ф(" + (((count3 - 20) - count2 * count1) / sqrt).ToString() + ")\n"
                    + (1 / sqrt).ToString() + " * ф(" + ((count3 - count2 * count1) / sqrt).ToString() + ")";
                return (text, rezult);
            }
        }
        public (string,string) task11(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                float count1 = rand.Next(2, 7) / 1000f;
                int count2 = rand.Next(2, 5);

                text = string.Format("Аппаратура состоит из 1000 элементов, каждый из которых независимо от остальных" +
                    " выходит из строя за время Т с вероятностью {0}. Найти вероятность того," +
                    "что за время Т откажет не более {1} элементов", count1.ToString(), count2.ToString());

                double a = 1000 * count1;
                double ans = 0;
                for (int i = 0; i <= count2; i++)
                    ans += Math.Pow(a, i) * Math.Exp(-a) / Convert.ToDouble(TeorVer.Fact(i));
                rezult += (ans).ToString();
                return (text, rezult);
            }
            else
            {
                float count1 = rand.Next(2, 7);
                int count2 = rand.Next(2, 5);

                text = string.Format("Некачественные сверла составляют {0}% всей продукции фабрики. Изготовленные" +
                    " сверла упаковываются в ящики по 100 штук. Какова вероятность того, что в ящике окажется" +
                    " не более {1} некачественных сверл ? ", count1.ToString(), count2.ToString());
                count1 /= 100;

                double a = 100 * count1;
                double ans = 0;
                for (int i = 0; i <= count2; i++)
                    ans += Math.Pow(a, i) * Math.Exp(-a) / Convert.ToDouble(TeorVer.Fact(i));
                rezult += (ans).ToString();
                return (text, rezult);
            }
        }
        public (string,string) task12(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                float count1 = rand.Next(4, 8);

                text = string.Format("Имеется {0} ключей, из которых только один подходит к замку. Составить ряд" +
                    " распределения числа подбора ключа к замку, если не подошедший ключ в последующих" +
                    " опробованиях не участвует.Найти М(Х), D(X), σ(X),F(X) этой случайной величины." +
                    "Построить график F(X).", count1);

                List<double> vers = new List<double>();
                vers.Add((1 / count1));
                for (int i = 2; i <= count1; i++)
                {
                    double ver = 1;
                    for (int j = 1; j < i; j++)
                        ver *= (1 - 1 / (count1-j+1));
                    ver *= (1 / (count1 - i + 1));
                    vers.Add(ver);
                }

                double mx =0;
                for (int i = 1; i <= count1; i++)
                    mx += i * vers[i-1];
                    
                double dx = 0;
                for (int i = 1; i <= count1; i++)
                    dx += i*i * vers[i - 1];

                rezult += "\n";
                rezult += String.Format("P(x = {0}) = ", 1) + String.Format("{0:0.0000}", vers[0]) + "\n";
                for (int i = 2; i <= count1; i++)
                {
                    rezult += String.Format("P(x = {0}) = ", i) + String.Format("{0:0.0000}", vers[i-1]) + "\n";
                }

                rezult += "\n" +
                    "M(X) = " + String.Format("{0:0.0000}", mx) + "\n" +
                    "D(X) = " + String.Format("{0:0.0000}", dx) + "\n" +
                    "σ(X) = " + String.Format("{0:0.0000}", Math.Sqrt(dx)) + "\n" +
                    "F(X) = \n";
                rezult += "    | " + String.Format("{0:0.0000}", vers[0]) + String.Format(", x = {0}\n", 1);
                for (int i = 2; i <= count1; i++)
                {
                    double sumVer = 0;
                    for (int j = 0; j < i; j++)
                        sumVer += vers[j];
                    rezult += "    | " + String.Format("{0:0.0000}", sumVer) + String.Format(", x = {0}\n", i);
                }
                return (text, rezult);
            }
            else
            {
                int count1 = rand.Next(18, 31)*100;
                int count2 = rand.Next(3, 9)*100;

                text = string.Format("В лотерее на 1000 билетов разыгрываются три вещи, стоимость которых {0}, {1}, {2} руб. " +
                    "Составить ряд распределения суммы выигрыша для лица, имеющего один билет. Найти " +
                    "М(Х), D(X), σ(X), F(X) суммы выигрыша. Построить график F(X).", count1.ToString(), count2.ToString(), (count2/2).ToString());

                double mx =0;
                mx += count1 * (1 / 1000f) + count2 * (1 / 1000f) + count2 * (1 / 2000f);
                double dx =0;
                dx += count1 * count1 * (1 / 1000f) + count2 * count2 * (1 / 1000f) + count2 * count2 * (1 / 2000f);

                rezult += "\n" +
                        "P(x = 0) = " + String.Format("{0:0.000}", 997f/1000f) + "\n" +
                        String.Format("P(x = {0}) = ", count1.ToString()) + String.Format("{0:0.000}", 1/1000f) + "\n" +
                        String.Format("P(x = {0}) = ", count2.ToString()) + String.Format("{0:0.000}", 1/1000f) + "\n" +
                        String.Format("P(x = {0}) = ", (count2/2).ToString()) + String.Format("{0:0.000}", 1/1000f);
                rezult += "\n" +
                    "M(X) = " + String.Format("{0:0.0000}", mx) + "\n" +
                    "D(X) = " + String.Format("{0:0.0000}", dx) + "\n" +
                    "σ(X) = " + String.Format("{0:0.0000}", Math.Sqrt(dx)) + "\n" +
                    "F(X) = \n" +
                    "    | " + String.Format("{0:0.000}", 997 / 1000f) + ", x = 0\n" +
                    "    | " + String.Format("{0:0.000}", 998 / 1000f) + String.Format(", x = {0}\n", count2/2) +
                    "    | " + String.Format("{0:0.000}", 999 / 1000f) + String.Format(", x = {0}\n", count2) +
                    "    | " + String.Format("{0:0}", 1) + String.Format(", x = {0}\n", count1);
                return (text, rezult);
            }
        }
        public (string,string) task13(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                float count1 = rand.Next(1, 4)/10f;
                int count2 = rand.Next(2, 5);
                text = string.Format("Устройство состоит из {1} независимо работающих элементов. Вероятность отказа" +
                    " каждого из них в одном опыте равна {0}. Составить ряд распределения числа отказавших элементов" +
                    " в одном опыте. Найти M(X) и D(X) этой случайной величины.", count1, count2);

                List<double> vers = new List<double>();
                for (int i = 0; i <= count2; i++)
                {
                    vers.Add(TeorVer.Bernulli(count2, i, count1));
                }
                
                double mx = 0;
                for (int i = 1; i <= count2; i++)
                    mx += i * vers[i];

                double dx = 0;
                for (int i = 1; i <= count2; i++)
                    dx += i * i * vers[i];

                rezult += "\n";
                for (int i = 0; i <= count2; i++)
                {
                    rezult += String.Format("P(x = {0}) = ", i) + String.Format("{0:0.0000}", vers[i]) + "\n";
                }

                rezult += "\n" +
                    "M(X) = " + String.Format("{0:0.0000}", mx) + "\n" +
                    "D(X) = " + String.Format("{0:0.0000}", dx) + "\n";
                return (text, rezult);
            }
            else
            {
                float count1 = rand.Next(6, 10) / 10f;
                int count2 = rand.Next(4, 7);
                text = string.Format("Вероятность приема сигнала равна {0}. Сигнал передается {1} раз." +
                    " Составить ряд распределения числа передач, в которых сигнал будет принят. " +
                    "Найти M(X) и D(X) этой случайной величины", count1, count2);

                List<double> vers = new List<double>();
                for (int i = 0; i <= count2; i++)
                {
                    vers.Add(TeorVer.Bernulli(count2, i, count1));
                }

                double mx = 0;
                for (int i = 1; i <= count2; i++)
                    mx += i * vers[i];

                double dx = 0;
                for (int i = 1; i <= count2; i++)
                    dx += i * i * vers[i];

                rezult += "\n";
                for (int i = 0; i <= count2; i++)
                {
                    rezult += String.Format("P(x = {0}) = ", i) + String.Format("{0:0.0000}", vers[i]) + "\n";
                }

                rezult += "\n" +
                    "M(X) = " + String.Format("{0:0.0000}", mx) + "\n" +
                    "D(X) = " + String.Format("{0:0.0000}", dx) + "\n";
                return (text, rezult);
            }
        }
        public (string,string) task14(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                int count1 = rand.Next(1, 5) * 500;
                text = string.Format("Прядильщица обслуживает 1000 веретен. Вероятность обрыва нити на одном веретене в течение" +
                    " одной минуты равна 0,03. Составить ряд распределения числа обрывов нити в течение одной минуты. " +
                    "Найти M(X) этой случайной величины.", count1);

                double a = count1 * 0.03;

                rezult += String.Format("Pn(m) = (({0:0.0})^m) / (m!) * e^({0:0.0})\n", a);
                rezult += String.Format("M(X) = {0:0.0}", a);

                return (text, rezult);
            }
            else
            {
                int count1 = rand.Next(2, 5) *100;
                text = string.Format("Вероятность для любого абонента позвонить на коммутатор в течение" +
                    " одного часа равна 0,01. Телефонная станция обслуживает {0} абонентов. Составить ряд" +
                    " распределения числа абонентов, которые могут позвонить на коммутатор в течение одного" +
                    " часа. Найти M(X) этой случайной величины.", count1);

                double a = count1 * 0.01;

                rezult += String.Format("Pn(m) = (({0:0.0})^m) / (m!) * e^({0:0.0})\n", a);
                rezult += String.Format("M(X) = {0:0.0}", a);

                return (text, rezult);
            }
        }
        public (string,string) task15(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            //int count1 = rand.Next(2, 5) * 100;
            text += "Независимые случайные величины X и Y заданы таблицами распределений. Найти:" +
                "\n1) M(X), M(Y), D(X), D(Y);" +
                "\n2) таблицы распределения случайных величин Z1 = 2X + Y, Z2 = X * Y;" +
                "\n3) M(Z1), M(Z2), D(Z1), D(Z2) непосредственно по таблицам распределений и на основании" +
                " свойств математического ожидания и дисперсии";

            List<double> xp = new List<double>();
            for(int i = 0; i < 2; i++)
            {
                xp.Add(rand.Next(2, 5)/10f);
            }
            xp.Add(1- xp[0]-xp[1]);
            List<double> yp = new List<double>();
            for (int i = 0; i < 1; i++)
            {
                yp.Add(rand.Next(2, 5) / 10f);
            }
            yp.Add(1 - yp[0]);

            List<int> x = new List<int>();
            x.Add(-rand.Next(1, 4));
            x.Add(rand.Next(1, 3));
            x.Add(rand.Next(3, 6));
            List<int> y = new List<int>();
            y.Add(rand.Next(1, 3));
            y.Add(rand.Next(3, 6));

            double mx = 0;
            for (int i=0; i<3; i++)
            {
                mx += x[i] * xp[i];
            }
            double my = 0;
            for (int i = 0; i < 2; i++)
            {
                my += y[i] * yp[i];
            }
            double mz1 = mx * 2 + my;
            double mz2 = mx * my;

            double dx = 0;
            for (int i = 0; i < 3; i++)
            {
                dx += x[i] * x[i] * xp[i];
            }
            double dy = 0;
            for (int i = 0; i < 2; i++)
            {
                dy += y[i] * y[i] * yp[i];
            }
            double dz1 = dx * 4 + dy;
            double dz2 = dx * dy + mx*mx*dy+ my*my*dx;

            text += String.Format("\nX |  {0} |   {1} |   {2} |\nP | {3} | {4} | {5} |", x[0], x[1], x[2], xp[0], xp[1], xp[2]);
            text += String.Format("\nY |   {0} |   {1} |\nP | {3} | {4} |", y[0], y[1], y[0], yp[0], yp[1]);

            rezult += String.Format("\n1)M(X) = {0}, D(X) = {1}, M(Y) = {2}, D(Y) = {3}\n", mx,dx,my,dy);

            Dictionary<int, double> z1 = new Dictionary<int, double>();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 2; j++)
                {
                    if (!z1.TryGetValue(x[i] *2+ y[j], out mx))
                        z1.Add(x[i] *2+ y[j], xp[i] * yp[j]);
                    else
                        z1[x[i] *2 + y[j]] += xp[i] * yp[j];
                }

            Dictionary<int, double> z2 = new Dictionary<int, double>();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 2; j++)
                {
                    if (!z2.TryGetValue(x[i]*y[j], out mx))
                        z2.Add(x[i] * y[j], xp[i] * yp[j]);
                    else
                        z2[x[i] * y[j]] += xp[i] * yp[j];
                }

            rezult += String.Format("2)\nZ1 |");
            foreach (var i in z1)
            {
                if (i.Key >=10)
                    rezult += String.Format("   {0} |", i.Key);
                else if (i.Key >=0)
                    rezult += String.Format("    {0} |", i.Key);
                else
                    rezult += String.Format("   {0} |", i.Key);
            }
            rezult += String.Format("\nP  |");
            foreach (var i in z1)
            {
                rezult += String.Format(" {0} |", i.Value);
            }

            rezult += String.Format("\nZ2 |");
            foreach (var i in z2)
            {
                if (i.Key >= 10)
                    rezult += String.Format("   {0} |", i.Key);
                else if (i.Key >= 0)
                    rezult += String.Format("    {0} |", i.Key);
                else
                    rezult += String.Format("   {0} |", i.Key);
            }
            rezult += String.Format("\nP  |");
            foreach (var i in z2)
            {
                rezult += String.Format(" {0} |", i.Value);
            }

            rezult += String.Format("\n\n3)M(Z1) = {0}, D(Z1) = {1}, M(Z2) = {2}, D(Z2) = {3}\n", mz1, dz1, mz2, dz2);
            return (text, rezult);
        }
        public (string,string) task16(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            //int count1 = rand.Next(2, 5) * 100;
            text += "Дана функция распределения F(x) непрерывной случайной величины X. Требуется:" +
                "\n1) найти плотность вероятности f(x);" +
                "\n2) построить графики F(x) и f(x);" +
                "\n3) найти Р(a < X < b) для данных a, b.\n";

            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                float count1 = rand.Next(1, 3) /10f;
                float count2 = rand.Next(4, 7) / 10f;
                text += string.Format("F(x) = 0, x<=0; 3*x^2+2x, 0<x<=1/3; 1, x>1/3\na = {0} , b = {1}", count1,count2);

                rezult += ("f(x) = 0, x<=0; 6*x+2, 0<x<=1/3; 0, x>1/3\n");
                rezult += String.Format("P(a < X < b) = {0:0.0000}", 1-(3*count1*count1+2*count1));

                return (text, rezult);
            }
            else
            {
                float count1 = rand.Next(1, 2);
                float count2 = rand.Next(2, 4);
                text += string.Format("F(x) = 0, x<=0; x^2/9, 0<x<=3; 1, x>3\na = {0} , b = {1}", count1, count2);

                rezult += ("\nf(x) = 0, x<=0; 2*x/9, 0<x<=3; 0, x>3\n");
                rezult += String.Format("P(a < X < b) = {0:0.0000}", count2*count2/9-count1*count1/9);

                return (text, rezult);
            }
        }
        public (string,string) task17(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            //int count1 = rand.Next(2, 5) * 100;
            text += "Дана плотность вероятности f(x) непрерывной случайной величины X. Требуется:" +
                "\n1) найти параметр a;" +
                "\n2) найти функцию распределения F(x);" +
                "\n3) построить графики f(x) и F(x);" +
                "\n4) найти асимметрию и эксцесс X.";

            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                text += string.Format("\nf(x) = 0, x<0; a*sin(x)/3, 0<=x<=π/3; 0, x>π/3");

                rezult += ("\na = 6");
                rezult += ("\nF(x) = 0, x<0; -2*cos(x)+2, 0<=x<=1/3; 1, x>1/3");
                rezult += ("\nAs(x) =  -0,50442126889; Ex(x) = -0,68036680404");

                return (text, rezult);
            }
            else
            {
                text += string.Format("\nf(x) = a/(1+x^2) x∈R");

                rezult += ("\na = 1/π");
                rezult += ("\nF(x) = arctan(x)/π x∈R");
                rezult += ("\nAs(x) =  не определено; Ex(x) = не определено");

                return (text, rezult);
            }
        }
        public (string, string) task18(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            text += "Дана плотность вероятности f(x) непрерывной случайной величины X, имеющая две ненулевые составляющие формулы. Требуется:" +
                "\n1)Проверить свойство -∞∫∞(f(x)dx)=1" +
                "\n2)Построить график f(x)" +
                "\n3)Найти функцию распределния F(x)" +
                "\n4)Найти P(a <= X <= b) для данных a,b" +
                "\n5)Найти M(X),D(x),σ(X)";
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                rezult += "\n Условие выполняется.";
                double count1 = rand.Next(0, 13) / -10.0;
                double count2 = rand.Next(1, 30) / 10.0;
                text += string.Format("f(x) = 0, x<=0; x/8, 0<x<=2; 1, 2<x<11/4; 0, x>11/4 \na = {0} , b = {1}", count1, count2);
                rezult += "\n F(x)= 0, x<=0; x^2/16, 0<x<=2; x-7/4, 2<x<11/4; 1, x>11/4 \n";

                double mx = 0.0;
                double dx = 0.0;

                //P(a<x<b) в разных случаях
                if (count2 <= 2.0)
                {
                    rezult += String.Format("P(a < X < b) = {0:0.0000}", (count2 * count2 / 16.0));
                    mx = count2 * count2 * count2 / 24.0;
                    dx = count2 * count2 * count2 * count2 / 32.0;
                }

                if (count2 >= 2.0 && count2 <= 11.0 / 4.0)
                {
                    rezult += String.Format("P(a < X < b) = {0:0.0000}", (2.0 * 2.0 / 16.0) + (count2 - 2.0));
                    mx = count2 * count2 * count2 / 24.0 + (count2 * count2 / 2.0 - 2.0 * 2.0 / 2.0);
                    dx = count2 * count2 * count2 * count2 / 32f + (count2 * count2 * count2 / 3.0 - 2.0 * 2.0 * 2.0 / 3.0);
                }

                if (count2 > 11.0 / 4.0)
                {
                    rezult += String.Format("P(a < X < b) = {0:0.0000}", (2f * 2f / 16f) + (11f / 4f - 2f));
                    mx = 2.0 * 2.0 * 2.0 / 24.0 + ((11.0 / 4.0 * 11.0 / 4.0) / 2.0 - 2.0 * 2.0 / 2.0);
                    dx = 2.0 * 2.0 * 2.0 * 2.0 / 32.0 + ((11.0 / 4.0 * 11.0 / 4.0 * 11.0 / 4.0) / 3.0 - 2.0 * 2.0 * 2.0 / 3.0);
                }

                double sx = Math.Sqrt(dx);
                rezult += String.Format("M(X)={0:0.0000}; D(X)={1:0.0000}; σ(X)={2:0.0000}", mx, dx, sx);
            }
            else
            {
                rezult += "\n Условие выполняется.";
                float count1 = rand.Next(11, 20) / -10f;
                float count2 = rand.Next(-10, 30) / 10f;
                text += string.Format("f(x) = 0, x<=-1; 1/2, -1<x<=0; 1/2-x/4, 0<x<=2; 0, x>2 \na = {0} , b = {1}", count1, count2);
                rezult += "\n F(x)= 0, x<=-1; x/2+1/2, -1<x<=0; -x^2/8+x/2+1/2, 0<x<=2; 1, x>2 \n";
                float mx = 0f;
                float dx = 0f;
                //P(a<x<b) в разных случаях
                if (count2 <= 0f)
                {
                    rezult += String.Format("P(a < X < b) = {0:0.0000}", (count2 / 2f - 1f / -2f));
                    mx = (count2 * count2 / 4f - 1f * 1f / 4f);
                    dx = (count2 * count2 * count2 / 6f - 1f * 1f * 1f / -6f);
                }

                if (count2 > 0f && count2 <= 2f)
                {
                    rezult += String.Format("P(a < X < b) = {0:0.0000}", (0f / 2f + 1f / 2f) + (count2 * count2 / (-8f) + count2 / 2f + 1f / 2f) - (1f / 2f));
                    mx = (0f / 4f - 1f * 1f / 4f) + (count2 * count2 / 4f - count2 * count2 * count2 / 12f) - (0f / 4f - 0f / 12f);
                    dx = (0f / 6f + 1f / 6f) +
                        (count2 * count2 * count2 / 6f - count2 * count2 * count2 * count2 / 16f) - (0f / 6f - 0f / 16f);
                }

                if (count2 > 2f)
                {
                    rezult += String.Format("P(a < X < b) = {0:0.0000}", (1f / 2f) + (1f / 2f));
                    mx = (0f / 4f - 1f * 1f / 4f) + (2f * 2f / 4f - 2f * 2f * 2f / 12f) - (0f / 4f - 0f / 12f);
                    dx = (0f / 6f + 1f / 6f) + (2f * 2f * 2f / 6f - 2f * 2f * 2f * 2f / 16f) - (0f / 4f - 0f / 12f);
                }


                double sx = Math.Sqrt(dx);
                rezult += String.Format("M(X)={0:0.0000}; D(X)={1:0.0000}; σ(X)={2:0.0000}", mx, dx, sx);
            }
            return (text, rezult);
        }
      public (string,string) task19(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                float count1 = rand.Next(1, 5) * 20;
                text = string.Format("Дистанция X между двумя соседними самолетами в строю имеет показательное распределение с MX = 100 м. " +
                    "Опасность столкновения самолетов возникает при уменьшении дистанции до {0} м. Найти вероятность возникно" +
                    "вения этой опасности.", count1);

                rezult += String.Format("{0}", 1-Math.Exp(-count1/100));

                return (text, rezult);
            }
            else
            {
                float count1 = rand.Next(1, 11) / 20f;
                text = string.Format("Исследуется район массовой гибели судов в войне 1939–1945 гг. Вероятность обнаружения" +
                    " затонувшего судна за время поиска t задается формулой: Р(t) = 1– exp(–{0}*t) Пусть случайная величина" +
                    " T — время, необходимое для обнаружения очередного судна(в часах). Найти среднее значение T.", count1);

                rezult += String.Format("{0}", 1/count1);

                return (text, rezult);
            }
        }

        public (string, string) task20(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                double mx = rand.Next(10, 30);
                double sx = rand.Next(1, 10) / 10.0;
                double delta = rand.Next(4, 30) / 100.0;
                text += String.Format("Диаметр детали, вытачиваемой на станке, есть нормальная случайная величина (a = {0} см; σ = {1} см)." +
                    "С какой вероятностью отклонение диаметра детали от среднего значения не превосходит по абсолютной величине {2} см?", mx, sx, delta);
                double forLaplas = delta / sx;
                rezult += String.Format("2*Ф({0:0.0000})", delta / sx);
            }
            else
            {
                double chislitel = rand.Next(1, 10);
                double multStepen = rand.Next(3, 15);
                chislitel = 1;
                multStepen = 3;
                text += "6. Для какого значения А функция" +
                    String.Format("f(x) = 0 , x<0; ({0}/A)*e^(-{1}Ax) x>=0, является \n ,", chislitel, multStepen) +
                "а) плотностью вероятности;" +
                "б) плотностью вероятности экспоненциального закона?";
                double solve = Math.Sqrt(chislitel) / Math.Sqrt(multStepen);
                rezult += String.Format("а) -inf<x<0 ⋃ 0<x<{0:0.0000} ⋃ {0:0.0000}<x<+inf\n", solve);
                rezult += String.Format("б) {0:0.0000} \n", solve);

            }


            return (text, rezult);
        }


         public (string,string) task21(int chooseVar)
        {
            string text = "";
            string rezult = "";
            Random rand = new Random();
            if (chooseVar == 0)
                chooseVar = rand.Next(1, 3);
            if (chooseVar == 1)
            {
                float count1 = rand.Next(1, 8);
                float count2 = rand.Next(3, 7);
                text = string.Format("Колебание прибытия вагонов на промышленную станцию имеет нормальное " +
                    "распределение со средним квадратическим отклонением σ = {2} и средним значением, равным 40" +
                    " вагонам в сутки. Определить вероятность того, что за сутки на станцию прибыло от {0} до {1} вагонов.", 40-count1, 40 + count1, count2);

                rezult += String.Format("2*Ф({0})", count1/count2);

                return (text, rezult);
            }
            else
            {
                float count1 = rand.Next(1, 5)*10;
                float count2 = rand.Next(1, 4)*10;
                text = string.Format("Число вагонов в прибывающем на расформирование составе является" +
                    " случайной величиной, распределенной по нормальному закону с параметрами σ = {1}, m = 100. " +
                    "Определить вероятность того, что в составе будет не более {0} вагонов.", 100-count1, count2);

                rezult += String.Format("0,5 - Ф({0})", count1 / count2);

                return (text, rezult);
            }
        }
        
        (string, string) multiTask(int taskNumber, int chooseVar)
        {
            switch (taskNumber)
            {
                case 1: return task1(chooseVar);
                case 2: return task2(chooseVar);
                case 3: return task3(chooseVar);
                case 4: return task4(chooseVar);
                case 5: return task5(chooseVar);
                case 6: return task6(chooseVar);
                case 7: return task7(chooseVar);
                case 8: return task8(chooseVar);
                case 9: return task9(chooseVar);
                case 10: return task10(chooseVar);
                case 11: return task11(chooseVar);
                case 12: return task12(chooseVar);
                case 13: return task13(chooseVar);
                case 14: return task14(chooseVar);
                case 15: return task15(chooseVar);
                case 16: return task16(chooseVar);
                case 17: return task17(chooseVar);
                case 18: return task18(chooseVar);
                case 19: return task19(chooseVar);
                case 20: return task20(chooseVar);
                case 21: return task21(chooseVar);
                default: return ("","");
            }
        }

        // основная функция, доступная извне. Вот её должна вызывать Ия в своём интерфейсе,
        // а Дима должен её изменить таким образом, чтобы она ещё и делала запись в файл. Но основа выглядит так:
        public void Generate(int numVar, int startTask, int endTask, List<string> fioList = null)
        {
            string fileNameLoad = @"D:\file1.docx";
            //string fileNameSave = @"D:\Tasks.docx";
            //string fileNameSaveAnsw = @"D:\Answers.docx";

            string group = "";
            (fioList, group) = Inp.load(fileNameLoad);
            numVar = fioList.Count;
            var docTask = DocX.Create(@"Tasks.docx");
            var docAnswers = DocX.Create(@"Answers.docx");

            //var docTask = DocX.Create(fileNameSave);
            //var docAnswers = DocX.Create(fileNameSaveAnsw);


            // случай, если требуемое количество сгенерированных вариантов больше, чем количество имеющихся фио.
            // можно вызывать Generate с пустым fio листом, тогда варианты не будут подписаны.
            //if (fioList != null && numVar > fioList.Count)
            //    return;
            // для каждого варианта
            for (int k = 0; k < numVar; k++)
            {
                if (fioList.Count - 1 > k)
                {
                    docTask.InsertParagraph(fioList[k] + " " + group + " " + String.Format("Вариант {0}", k + 1));
                    docTask.InsertParagraph();
                    docAnswers.InsertParagraph(fioList[k] + " " + group + " " + String.Format("Вариант {0}", k + 1));
                    docAnswers.InsertParagraph();
                }
                else
                {
                    docTask.InsertParagraph(String.Format("Вариант {0}", k + 1));
                    docTask.InsertParagraph();
                    docAnswers.InsertParagraph(String.Format("Вариант {0}", k + 1));
                    docAnswers.InsertParagraph();
                }
                // генерим требуемые задачи по номеру.
                for (int i = startTask; i <= endTask && i < 22 && i > 0; i++)
                {
                    // если второй аргумент 0 - то задача рандомно выбирается из 1 или 6 варианта. Если 1 - из 1-го, иначе из 6-го.
                    docTask.InsertParagraph(i.ToString() + "." + multiTask(i, 0).Item1);
                    docTask.InsertParagraph();
                    docAnswers.InsertParagraph(i.ToString() + "." + multiTask(i, 0).Item1);
                    docAnswers.InsertParagraph(i.ToString() + ". Ответ:" + multiTask(i, 0).Item2);
                    docAnswers.InsertParagraph();

                }
                docTask.InsertSectionPageBreak();
                docAnswers.InsertSectionPageBreak();
            }
            docTask.Save();
            docAnswers.Save();
        }
    }
    class Program
    {
        static void main(string[] args)
        {
            Generator_TV test = new Generator_TV();
            test.Generate(10, 1, 8);
            string s1, s2;
            // все функции задания публичны, но это временно сделано для лёгкого тестирования
            (s1,s2) = test.task17(0);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.ReadKey();
        }
    }
}
