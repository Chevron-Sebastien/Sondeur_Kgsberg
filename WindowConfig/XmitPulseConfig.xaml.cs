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
    /// Logique d'interaction pour XmitPulseConfig.xaml
    /// </summary>
    public partial class XmitPulseConfig : Window
    {
        private string msg = "";
        private MainWindow wd;

        public XmitPulseConfig(MainWindow wds)
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

        // Send command
        private void buttonXmitPulseSend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "P" + this.textBoxValue.Text;
            wd.sendConfig(msg);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "-P";
            wd.sendConfig(msg);
        }
    }
}
