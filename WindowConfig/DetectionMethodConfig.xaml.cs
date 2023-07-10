
using System.ComponentModel;
using System.Windows;


namespace Sondeur_1007_Kongsberg.WindowConfig
{
    /// <summary>
    /// Logique d'interaction pour DetectionMethodConfig.xaml
    /// </summary>
    public partial class DetectionMethodConfig : Window
    {
        private MainWindow wd;
        private string value = "0";
        public DetectionMethodConfig(MainWindow wds)
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
        private void buttonFirst_Click(object sender, RoutedEventArgs e)
        {

            this.value = "D0";
            wd.sendConfig(value);
        }
        private void buttonPeakSend_Click(object sender, RoutedEventArgs e)
        {
            this.value = "D2";
            wd.sendConfig(value);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.value = "-D";
            wd.sendConfig(value);
        }
    }
}
