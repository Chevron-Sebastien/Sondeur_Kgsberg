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
    /// Logique d'interaction pour TransmitPowerConfig.xaml
    /// </summary>
    public partial class TransmitPowerConfig : Window
    {
        private string msg = "";
        private MainWindow wd;

        public TransmitPowerConfig(MainWindow wds)
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

        //Send
        private void buttonLow_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "X0";
            this.wd.sendConfig(msg);
        }

        private void buttonHigh_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "X1";
            this.wd.sendConfig(msg);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "-X";
            this.wd.sendConfig(msg);
        }
    }
}
