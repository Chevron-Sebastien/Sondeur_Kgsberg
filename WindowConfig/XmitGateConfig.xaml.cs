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
    /// Logique d'interaction pour XmitGateConfig.xaml
    /// </summary>
    public partial class XmitGateConfig : Window
    {
        private MainWindow wd;
        private string value;
        public XmitGateConfig(MainWindow wds)
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
        private void buttonListenSend_Click(object sender, RoutedEventArgs e)
        {
            this.value = "T0";
            this.wd.sendConfig(value);
        }

        private void buttonXMT1Send_Click(object sender, RoutedEventArgs e)
        {
            this.value = "T1";
            this.wd.sendConfig(value);
        }

        private void buttonXMT2Send_Click(object sender, RoutedEventArgs e)
        {
            this.value = "T2";
            this.wd.sendConfig(value);
        }

        private void buttonXMT1and2SEND_Click(object sender, RoutedEventArgs e)
        {
            this.value = "T3";
            this.wd.sendConfig(value);
        }

        private void buttonFTXSend_Click(object sender, RoutedEventArgs e)
        {
            this.value = "T4";
            this.wd.sendConfig(value);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.value = "-T";
            this.wd.sendConfig(value);
        }
    }
}
