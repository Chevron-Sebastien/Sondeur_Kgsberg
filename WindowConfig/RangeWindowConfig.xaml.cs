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
    /// Logique d'interaction pour RangeWindowConfig.xaml
    /// </summary>
    public partial class RangeWindowConfig : Window
    {
        private string msg = "";
        private MainWindow wd;
        public RangeWindowConfig(MainWindow wds)
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
        private void buttonRangeWindowConfig_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "W" + this.textBoxValue.Text;
            this.wd.sendConfig(msg);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "-W";
            this.wd.sendConfig(msg);
        }
    }
}
