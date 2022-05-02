using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Xps.Packaging;

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

        private void Students_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog tasksFile = new Microsoft.Win32.OpenFileDialog();

            tasksFile.Multiselect = false;

            tasksFile.DefaultExt = ".docx";
            tasksFile.Filter = "(.docx)|*.docx";

            bool? response = tasksFile.ShowDialog();
            if (response == true)
            {


                string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(tasksFile.FileName), "\\",

                               System.IO.Path.GetFileNameWithoutExtension(tasksFile.FileName), ".xps");

                documentViewer1.Document =

                    ConvertWordDocToXPSDoc(tasksFile.FileName, newXPSDocumentName).GetFixedDocumentSequence();
                MessageBox.Show("Successfully done");

            }
        }

        private Outt outt = new Outt();

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = "Контрольная работа " + groupName + " ";

            saveFileDialog.Filter = "(*.docx)|*.docx";
            (string, string) solve = ("URAAAAA154", "23154");
            string fileNameSaveAnswer = saveFileDialog.FileName + " answer ";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TextboxTasks.Text);
                outt.Save(saveFileDialog.FileName, fileNameSaveAnswer, solve);
            }


        }

        private int numbOfVars, startTask, endTask;
        List<string> fioList = null;

        Generator_TV Generator_TV = new Generator_TV();

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            //numbOfVars = Convert.ToInt32(TextboxVars.Text);
            numbOfVars = 10;
            startTask = 1;
            endTask = 10;
           



        }



        private void TextBox_I(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_T(object sender, TextChangedEventArgs e)
        {

        }
    }
}
