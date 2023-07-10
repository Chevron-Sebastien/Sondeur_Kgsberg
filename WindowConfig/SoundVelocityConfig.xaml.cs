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
    /// Logique d'interaction pour SoundVelocityConfig.xaml
    /// </summary>
    public partial class SoundVelocityConfig : Window
    {
        private string msg = "";
        private MainWindow wd;
        public SoundVelocityConfig(MainWindow wds)
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
        private void buttonSoundVelocitySend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "V" + this.textBoxValue.Text;
            this.wd.sendConfig(this.msg);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "-V";
            this.wd.sendConfig(this.msg);
        }
    }
}
