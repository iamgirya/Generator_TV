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
            return ("","");
        }
        public (string,string) task15(int chooseVar)
        {
            return ("","");
        }
        public (string,string) task16(int chooseVar)
        {
            return ("","");
        }
        public (string,string) task17(int chooseVar)
        {
            return ("","");
        }
        public (string,string) task18(int chooseVar)
        {
            return ("","");
        }
        public (string,string) task19(int chooseVar)
        {
            return ("","");
        }
        public (string,string) task20(int chooseVar)
        {
            return ("","");
        }
        public (string,string) task21(int chooseVar)
        {
            return ("","");
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
            // случай, если требуемое количество сгенерированных вариантов больше, чем количество имеющихся фио.
            // можно вызывать Generate с пустым fio листом, тогда варианты не будут подписаны.
            if (fioList != null && numVar > fioList.Count)
                return;
            // для каждого варианта
            for (int k = 0; k < numVar; k++)
            {   
                // генерим требуемые задачи по номеру.
                for (int i = startTask; i <= endTask && i <22 && i > 0; i ++)
                {
                    // если второй аргумент 0 - то задача рандомно выбирается из 1 или 6 варианта. Если 1 - из 1-го, иначе из 6-го.
                    multiTask(i, 0);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Generator_TV test = new Generator_TV();
            test.Generate(10, 1, 8);
            string s1, s2;
            // все функции задания публичны, но это временно сделано для лёгкого тестирования
            (s1,s2) = test.task13(0);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.ReadKey();
        }
    }
}
