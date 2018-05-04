using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Web;

namespace FormBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ViewDict(object sender, RoutedEventArgs e)
        {
            string formdata = tbInput.Text;

            try
            {
                tbOutput.Text =
                    string.Join("\n", formdata
                   .Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(
                       entry => $@"{{{string.Join(", ", entry
                            .Split(new char[] { '=' })
                            .Select(value => $"\"{HttpUtility.UrlDecode(value)}\""))}}}"
                           )
                   .Select(line => $"{line},"));
            }
            catch(Exception ex) { }
        }
    }
}
