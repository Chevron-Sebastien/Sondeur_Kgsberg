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
    /// Logique d'interaction pour TresholdConfig.xaml
    /// </summary>
    public partial class TresholdConfig : Window
    {
        private MainWindow wds;

        public TresholdConfig(MainWindow wd)
        {
            wds = wd;
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
            string value = "C" + this.textBoxValueTreshold.Text;
            wds.sendConfig(value);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            string value = "-C";
            wds.sendConfig(value);
        }
    }
}

