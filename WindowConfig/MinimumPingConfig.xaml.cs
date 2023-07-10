
using System.ComponentModel;
using System.Windows;


namespace Sondeur_1007_Kongsberg.WindowConfig
{
    /// <summary>
    /// Logique d'interaction pour MinimumPingConfig.xaml
    /// </summary>
    public partial class MinimumPingConfig : Window
    {
        private MainWindow wd;
        private string msg = "";

        public MinimumPingConfig(MainWindow wds)
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
        private void buttonPingSendSend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "Y" + this.textBoxValue.Text;
            this.wd.sendConfig(msg);
        }

        private void buttonAskConfig_Click(object sender, RoutedEventArgs e)
        {
            this.msg = "-Y";
            this.wd.sendConfig(msg);
        }
    }
}
