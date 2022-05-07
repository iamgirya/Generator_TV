using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Xps.Packaging;
using Xceed.Words.NET;

namespace W_Gen
{
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        string groupName = "test";


        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)

        {

            Microsoft.Office.Interop.Word.Application

                wordApplication = new Microsoft.Office.Interop.Word.Application();

            wordApplication.Documents.Add(wordDocName);

            Document doc = wordApplication.ActiveDocument;

            try
            {
                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);
                wordApplication.Quit();
                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);
                return xpsDoc;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
            }
            return null;
        }

        static string toFileS;

        private void Students_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog tasksFile = new Microsoft.Win32.OpenFileDialog();

            tasksFile.Multiselect = false;

            tasksFile.DefaultExt = ".docx";
            tasksFile.Filter = "(.docx)|*.docx";

            bool? response = tasksFile.ShowDialog();
            if (response == true)
            {

                MessageBox.Show("Загружено");

            }

            toFileS = tasksFile.FileName;
        }

      

        // номера заданий 
        // от
        private void TextBox_T(object sender, TextChangedEventArgs e)
        {

        }
        // до 
        private void TextBox_T2(object sender, TextChangedEventArgs e)
        {

        }

        //private void Students_Click(object sender, RoutedEventArgs e)
        //{

        //    var doc1 = DocX.Create(@"jopa4.docx");
        //    FileInfo file = new FileInfo(@"jopa4.docx");
        //    doc1.InsertParagraph("Ya ebal sobaku1");
        //    doc1.InsertParagraph("Ya ebal sobaku2");
        //    doc1.InsertParagraph("Ya ebal sobaku3");
        //    doc1.InsertParagraph("Ya ebal sobaku4");
        //    doc1.InsertParagraph("Ya ebal sobaku5");
        //    doc1.InsertParagraph("Ya ebal sobaku6");
        //    doc1.Save();
        //    string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(file.FullName), "\\",

        //                       System.IO.Path.GetFileNameWithoutExtension(file.FullName), ".xps");

        //    documentViewer1.Document =

        //        ConvertWordDocToXPSDoc(file.FullName, newXPSDocumentName).GetFixedDocumentSequence();
        //    MessageBox.Show("Successfully done");
        //}


        Outt outt = new Outt();


        private int numbOfVars, startTask, endTask;
        string varPathAns;
        string varPathTasks;
        List<string> fioList;

        Generator_TV Generator_TV = new Generator_TV();

        FileInfo file;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        int i = 0;
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            varPathAns = @"Answers.docx";
            

            startTask = Convert.ToInt32(TextboxTasks.Text);
            endTask = Convert.ToInt32(TextboxTasks2.Text);
            
            fioList = Inp.Load(toFileS).Item1;
            numbOfVars = fioList.Count-1;
            if (numbOfVars == 0)
                numbOfVars = Convert.ToInt32(TextboxVars.Text);
            TextboxVars.Text = String.Format("{0}", numbOfVars);
            // numbOfVars = 2;
            //startTask = 1;
            //endTask = 21;
            Generator_TV.Generate(numbOfVars, startTask, endTask, toFileS, fioList);

            file = new FileInfo(varPathAns);

            
            string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(file.FullName), "\\",

                           System.IO.Path.GetFileNameWithoutExtension(file.FullName) + i.ToString(), ".xps");
            i++;

            documentViewer1.Document =

                ConvertWordDocToXPSDoc(file.FullName, newXPSDocumentName).GetFixedDocumentSequence();

            
            
            MessageBox.Show("Успешно");

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void helpBut_Click(object sender, RoutedEventArgs e)
        {
            string helpText = "Все кнопки требуют нажатия только один раз \n \n" +
                "Список студентов должен быть представлен в формате .docx файла БЕЗ пустой строки до и после номера варианта. Пример: \n \n" +
                " Группа 26 \n" +
                " 1. ФИО \n \n " +
                "Загрузить файл со студентами - кнопка Выбрать список студентов \n \n " +
                "При загрузке файла количество вариантов задаётся автоматически \n " +
                "Если файл не загружен, необходимо ввести количество вариантов вручную \n \n" +
                "Перед генерацией ввести номера задач 1-21 \n \n" +
                "Нажать на кнопку Сгенерировать для генерации вариантов ОДИН РАЗ, после этого в окне предпросмотра появится файл с вариантами и ответами\n \n" +
                "Для сохранения файлов нажать на кнопку Сохранить, сначала сохраняется файл с задачами БЕЗ ответов, затем сохраняется файл С ОТВЕТАМИ \n \n" +
                "Готово! Вы великолепны! ";
            MessageBox.Show(helpText);
        }

       

        private void TextBox_I(object sender, TextChangedEventArgs e)
        {
            
            
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            varPathAns = @"Answers.docx";
            varPathTasks = @"Tasks.docx";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
          
            groupName = Inp.Load(toFileS).Item2;
            saveFileDialog.FileName = "Контрольная работа " + groupName + "";
            
            saveFileDialog.Filter = "(*.docx)|*.docx";
           
            //(string, string) solve = ("URAAAAA154", "23154");


            if (saveFileDialog.ShowDialog() == true )
            {
                string p = saveFileDialog.FileName;
                //
                File.Copy(new FileInfo(varPathTasks).FullName, p);
                // fileNameSaveAnswer += " Ответы ";
                

                //Outt.Save(saveFileDialog.FileName, fileNameSaveAnswer, );
            }

            SaveFileDialog fileNameAnswer = new SaveFileDialog();
            fileNameAnswer.FileName = "Контрольная работа " + groupName + " Ответы";
            fileNameAnswer.Filter = "(*.docx)|*.docx";

            if (fileNameAnswer.ShowDialog() == true)
            {
                
                string p2 = fileNameAnswer.FileName;
                //
                File.Copy(new FileInfo(varPathAns).FullName, p2);
                File.Delete(new FileInfo(varPathAns).FullName);
                File.Delete(new FileInfo(varPathTasks).FullName);

                
            }

        }
        
    }
}
