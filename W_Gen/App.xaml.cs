using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace W_Gen
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        private void Application_Exit(object sender, ExitEventArgs e)
        {
           string  varPathAns = @"Answers.docx";
            string newXPSDocumentName = @"Answers.xps";
            string varPathTasks = @"Tasks.docx";
            if (varPathAns != null && varPathTasks != null)
            {
                File.Delete(new FileInfo(varPathAns).FullName);
                File.Delete(new FileInfo(varPathTasks).FullName);
            }
            File.Delete(newXPSDocumentName);

        }
    }
}
