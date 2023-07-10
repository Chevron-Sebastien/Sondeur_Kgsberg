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
    /// Logique d'interaction pour MaximumRangeConfig.xaml
    /// </summary>
    public partial class MaximumRangeConfig : Window
    {
        private MainWindow wd;
        private string msg;

        public MaximumRangeConfig(MainWindow wds)
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
        //Send Command
        private void button20mSend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "R1";
            wd.sendConfig(msg);
        }

        private void button50mSend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "R2";
            wd.sendConfig(msg);
        }

        private void button100mSend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "R3";
            wd.sendConfig(msg);
        }

        private void button200mSend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "R4";
            wd.sendConfig(msg);
        }

        private void buttonCustomR0Send_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "R0";
            wd.sendConfig(msg);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "-R";
            wd.sendConfig(msg);
        }
    }
}
