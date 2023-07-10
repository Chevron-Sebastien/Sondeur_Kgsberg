using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Sondeur_1007_Kongsberg.WindowConfig
{
    /// <summary>
    /// Logique d'interaction pour OutputFormatConfig.xaml
    /// </summary>
    public partial class OutputFormatConfig : Window
    {
        private MainWindow wd;
        private string value = "0";
        public OutputFormatConfig(MainWindow wds)
        {
            this.wd = wds;
            InitializeComponent();
            this.Hide();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        //Send command
        private void buttonSTDSend_Click(object sender, RoutedEventArgs e)
        {
            this.value = "F0";
            wd.sendConfig(value);
        }

        private void buttonNMEA_Click(object sender, RoutedEventArgs e)
        {
            this.value = "F1";
            wd.sendConfig(value);
        }

        private void buttonSampleSend_Click(object sender, RoutedEventArgs e)
        {
            this.value = "F2";
            wd.sendConfig(value);
        }

        private void buttonUsecSend_Click(object sender, RoutedEventArgs e)
        {
            this.value = "F3";
            wd.sendConfig(value);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.value = "-F";
            wd.sendConfig(value);
        }
    }
}
