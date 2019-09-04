using IronPython.Hosting;
using Microsoft.CSharp;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pyScripts = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CallPythonScript();
        }
       
        void CallPythonScript()
        {
            Stream myStream = null;
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Open File";
            file.Filter = "Choice Python files| *.txt;*.py";
            if (file.ShowDialog() == true)
            {
                try
                {
                    if ((myStream = file.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string[] lines = System.IO.File.ReadAllLines(file.FileName);
                            string str = string.Empty;
                            foreach (var i in lines)
                            {
                                str += i + Environment.NewLine;
                            }
                            pyScripts = str;
                        }
                        ExcScript(pyScripts);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        void ExcScript(string script)
        {
            var py = Python.CreateEngine();
            try
            {
                py.Execute(script);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
