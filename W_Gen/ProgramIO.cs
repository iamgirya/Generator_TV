using System;
using System.IO;
using System.Collections.Generic;
using Xceed.Words.NET;
using System.Text.RegularExpressions;

namespace W_Gen
{
    public class Inp
    {

        //Функция принимает имя файла со студентами. Формат файла: в первой строке записана группа;
        //во всех последующих записаны Фамилия Имя студентов, каждый новый студент пишется с красной строки(с абзаца(с Enter'а))
        //Возвращает список список студентов в виде коллекции List<string>
        static bool IsEmptyOrWhitespace(string s)
        {
            if (s == null || s.Length == 0) return true;
            for (int i = 0; i < s.Length; i++) if (!char.IsWhiteSpace(s[i])) return false;
            return true;
        }
        public static (List<string>, string) Load(string fileNameLoad)
        {
            if(fileNameLoad == null)
                return (new List<string>(), "");
            FileInfo file = new FileInfo(fileNameLoad);
            Regex regForSpaces = new Regex(@"\s*");
            if(file.Length==0)
                return (new List<string>(),"");
            var doc2 = DocX.Load(fileNameLoad);
            var paraList = doc2.Paragraphs;
            paraList.ToString();
            string group = paraList[0].Text;
            List<string> studList = new List<string>();
            char[] charsToTrim = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };

            for (int i = 1; i < paraList.Count; i++)
            {
                paraList[i].Text.Trim(charsToTrim);
                paraList[i].Text.Trim();
                if(!IsEmptyOrWhitespace(paraList[i].Text))
                    studList.Add(paraList[i].Text);
            }
            return (studList, group);
        }
    }

    public class Outt
    {
        //Функция сохранения. Принимает путь до файла с заданиями, путь до файла с ответами, пару стрингов(задача, ответ)
        //Куча проверок на существование файла, итоговый результат - сохранённый файл. Шобы проверить сработало или нет, лично я лезу в сами файлы
        //Каждая новая задача записывается с абзаца. С ответом так же. Не ведётся подсчёт количества задач, поскольку это нужно будет делать в основном цикле генератора
        //Функция работает для сохранения ТОЛЬКО ОДНОЙ задачи.
        public static void Save(string fileNameSave, string fileNameSaveAnswer, (string, string) pair)
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

    }
}
