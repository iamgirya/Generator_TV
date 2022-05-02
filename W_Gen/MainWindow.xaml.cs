using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Office.Interop.Word;
using System.Windows.Xps.Packaging;
using System.Collections.Generic;

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
            // Create a WordApplication and add Document to it
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
                // Set DocumentViewer.Document to XPS document

                documentViewer1.Document =

                    ConvertWordDocToXPSDoc(tasksFile.FileName, newXPSDocumentName).GetFixedDocumentSequence();
                MessageBox.Show("Successfully done");

            }
        }

       /* private void Students_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog tasksFile = new Microsoft.Win32.OpenFileDialog();

            tasksFile.Multiselect = false;

            tasksFile.DefaultExt = ".docx";
            tasksFile.Filter = "(.docx)|*.docx";


            bool? response = tasksFile.ShowDialog();
            if (response == true)
            {

                MyImage.Source = new BitmapImage(new Uri(tasksFile.FileName, UriKind.Absolute));
                textbox_input_way.Text = tasksFile.FileName;
                MessageBox.Show("Successfully done");

            }
        }
       */

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = "Контрольная работа " + groupName;

            saveFileDialog.Filter = "(*.docx)|*.docx";

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, TextboxTasks.Text);
            
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
