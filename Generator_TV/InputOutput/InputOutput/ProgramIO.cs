using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace InputOutput
{
    class Program
    {

        //Функция принимает имя файла со студентами. Формат файла: в первой строке записана группа;
        //во всех последующих записаны Фамилия Имя студентов, каждый новый студент пишется с красной строки(с абзаца(с Enter'а))
        //Возвращает список список студентов в виде коллекции List<string>
        static List<string> load(string fileNameLoad)
        {
            var doc2 = DocX.Load(fileNameLoad);
            var paraList = doc2.Paragraphs;
            paraList.ToString();
            List<string> studList = new List<string>();
            char[] charsToTrim = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };

            for (int i = 1; i < paraList.Count; i++)
            {
                paraList[i].Text.Trim(charsToTrim);
                paraList[i].Text.Trim();
                studList.Add(paraList[i].Text);
            }
            return studList;
        }
        //Функция сохранения. Принимает путь до файла с заданиями, путь до файла с ответами, пару стрингов(задача, ответ)
        //Куча проверок на существование файла, итоговый результат - сохранённый файл. Шобы проверить сработало или нет, лично я лезу в сами файлы
        //Каждая новая задача записывается с абзаца. С ответом так же. Не ведётся подсчёт количества задач, поскольку это нужно будет делать в основном цикле генератора
        //Функция работает для сохранения ТОЛЬКО ОДНОЙ задачи.
        static void save(string fileNameSave, string fileNameSaveAnswer, (string, string) pair)
        {
            FileInfo file = new FileInfo(fileNameSave);
            FileInfo fileAnswer = new FileInfo(fileNameSaveAnswer);
            if (file.Exists && fileAnswer.Exists)
            {
                var docTask = DocX.Load(fileNameSave);
                var docAnsw = DocX.Load(fileNameSaveAnswer);
                docTask.InsertParagraph(pair.Item1);
                docAnsw.InsertParagraph(pair.Item2);
                docTask.Save();
                docAnsw.Save();
            }
            else
            {
                if (!file.Exists && !fileAnswer.Exists)
                {
                    var docTask = DocX.Create(fileNameSave);
                    var docAnsw = DocX.Create(fileNameSaveAnswer);
                    docTask.InsertParagraph(pair.Item1);
                    docAnsw.InsertParagraph(pair.Item2);
                    docTask.Save();
                    docAnsw.Save();
                }

                if (!file.Exists && fileAnswer.Exists)
                {
                    var docTask = DocX.Create(fileNameSave);
                    var docAnsw = DocX.Load(fileNameSaveAnswer);
                    docTask.InsertParagraph(pair.Item1);
                    docAnsw.InsertParagraph(pair.Item2);
                    docTask.Save();
                    docAnsw.Save();
                }

                if (file.Exists && !fileAnswer.Exists)
                {
                    var docTask = DocX.Load(fileNameSave);
                    var docAnsw = DocX.Create(fileNameSaveAnswer);
                    docTask.InsertParagraph(pair.Item1);
                    docAnsw.InsertParagraph(pair.Item2);
                    docTask.Save();
                    docAnsw.Save();
                }

            }

        }


        static void Main(string[] args)
        {
            string fileNameLoad = @"D:\Students.docx";
            string fileNameSave = @"D:\Tasks.docx";
            string fileNameSaveAnsw = @"D:\Answers.docx";
            load(fileNameLoad);
            (string, string) solve = ("URAAAAA154", "23154");
            save(fileNameSave, fileNameSaveAnsw, solve);
            Console.ReadKey();
        }
    }
}