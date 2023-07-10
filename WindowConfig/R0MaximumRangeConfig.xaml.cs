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
    /// Logique d'interaction pour R0MaximumRangeConfig.xaml
    /// </summary>
    public partial class R0MaximumRangeConfig : Window
    {
        private MainWindow wd;
        private string msg = "";
        public R0MaximumRangeConfig(MainWindow wds)
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
        private void buttonTresholdSend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "M" + this.textBoxValue.Text;
            wd.sendConfig(msg); ;
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "-M";
            wd.sendConfig(msg); ;
        }
    }
}
