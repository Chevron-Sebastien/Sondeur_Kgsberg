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
    /// Logique d'interaction pour TVGAutoGainConfig.xaml
    /// </summary>
    public partial class TVGAutoGainConfig : Window
    {
        private MainWindow wd;
        private string value = "";
        public TVGAutoGainConfig(MainWindow wds)
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
        private void buttonDisableSend_Click(object sender, RoutedEventArgs e)
        {
            this.value = "G0";
            wd.sendConfig(value);
        }
        private void buttonDCOffsetSend_Click(object sender, RoutedEventArgs e)
        {
            this.value = "G1";
            wd.sendConfig(value);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.value = "-G";
            wd.sendConfig(value);
        }
    }
}
