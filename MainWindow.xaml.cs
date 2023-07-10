
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using Sondeur_1007_Kongsberg.WindowConfig;


namespace Sondeur_1007_Kongsberg
{
    public partial class MainWindow : Window
    {
        private comRS232 comRS232Sondeur;
        private ServeurTCPIP tcpipRedirect;
        private bool flagRedirect = false;
        private int portTCPIP = 0;
        private string msg;


        //1st line
        private TresholdConfig tresholdWindow;
        private DetectionMethodConfig detectionMethodWindow;
        private OutputFormatConfig outputFormatWindow;
        private TVGAutoGainConfig tvgAutoGainWindow;
        private MinimumGapWidthConfig MinimumGapWidthConfigWindow;
        //2nd line
        private MinimumValidReturnConfig MinimumValidReturnConfigWindow;
        private R0MaximumRangeConfig R0MaximumRangeConfigWindow;
        private R0MinimumRangeConfig R0MinimumRangeConfigWindow;
        private XmitPulseConfig XmitPulseConfigWindow;
        private MaximumResolutionConfig MaximumResolutionConfigWindow;
        //3rd line
        private MaximumRangeConfig MaximumRangeConfigWindow;
        private NMEAScaleConfig NMEAScaleConfigWindow;
        private XmitGateConfig XmitGateConfigWindow;
        private TVGConfig TVGConfigWindow;
        private SoundVelocityConfig soundVelocityConfigWindow;
        //4th line
        private RangeWindowConfig rangeWindowConfigWindow;
        private TransmitPowerConfig transmitPowerConfigWindow;
        private MinimumPingConfig minimumPingConfigWindow;

        public MainWindow()
        {
            InitializeComponent();
            this.tresholdWindow = new TresholdConfig(this);
            this.detectionMethodWindow = new DetectionMethodConfig(this);
            this.outputFormatWindow = new OutputFormatConfig(this);
            this.tvgAutoGainWindow = new TVGAutoGainConfig(this);
            this.MinimumGapWidthConfigWindow = new MinimumGapWidthConfig(this);

            this.MinimumValidReturnConfigWindow = new MinimumValidReturnConfig(this);
            this.R0MaximumRangeConfigWindow = new R0MaximumRangeConfig(this);
            this.R0MinimumRangeConfigWindow = new R0MinimumRangeConfig(this);
            this.XmitPulseConfigWindow = new XmitPulseConfig(this);
            this.MaximumResolutionConfigWindow = new MaximumResolutionConfig(this);

            this.MaximumRangeConfigWindow = new MaximumRangeConfig(this);
            this.NMEAScaleConfigWindow = new NMEAScaleConfig(this);
            this.XmitGateConfigWindow = new XmitGateConfig(this);
            this.TVGConfigWindow = new TVGConfig(this);
            this.soundVelocityConfigWindow = new SoundVelocityConfig(this);

            this.rangeWindowConfigWindow = new RangeWindowConfig(this);
            this.transmitPowerConfigWindow = new TransmitPowerConfig(this);
            this.minimumPingConfigWindow = new MinimumPingConfig(this);
        }

        private void buttonConnect(object sender, RoutedEventArgs e)        //BOutton de connection
        {
            if (this.textBoxInputCOM.Text != "")            //Si champ texte != vide
            {
                try
                {
                    string portCOM = "COM" + this.textBoxInputCOM.Text;

                    this.comRS232Sondeur = new comRS232("Sondeur", portCOM, 9600, this);
                    this.buttonSendQ.IsEnabled = true;
                    this.buttonSendS.IsEnabled = true;
                    this.buttonDetectionMethod.IsEnabled = true;
                    this.buttonMinimumGap.IsEnabled = true;
                    this.buttonMinimaValidReturn.IsEnabled = true;
                    this.buttonOutputFormat.IsEnabled = true;
                    this.buttonTreshold.IsEnabled = true;
                    this.buttonTVGAutoGain.IsEnabled = true;
                    this.buttonR0MaximumRange.IsEnabled = true;
                    this.buttonR0MinimumRange.IsEnabled = true;
                    this.buttonMaximumResolution.IsEnabled = true;
                    this.buttonXmitPulse.IsEnabled = true;
                    this.buttonMaximumRange.IsEnabled = true;
                    this.buttonNMEAscale.IsEnabled = true;
                    this.buttonXmitGate.IsEnabled = true;
                    this.buttonTVG.IsEnabled = true;
                    this.buttonSoundVelocity.IsEnabled = true;
                    this.buttonTransmitPower.IsEnabled = true;
                    this.buttonMinimumPingPeriod.IsEnabled = true;
                    this.buttonRangeWindow.IsEnabled = true;
                    this.buttonInputToSend.IsEnabled = true;

                    voyantCOM.Fill = new SolidColorBrush(Colors.Green);
                }
                catch
                {
                    MessageBox.Show("Echec création port COM");
                }
            }
            else
            {
                MessageBox.Show("Pas de port COM référencé");
            }
        }

        // Redirect data
        private void buttonRedirectTCPIP_Click(object sender, RoutedEventArgs e)  //Connect
        {
            try
            {
                this.portTCPIP = Int32.Parse(this.textBoxRedirectTCPIP.Text.ToString());
                this.tcpipRedirect = new ServeurTCPIP(portTCPIP, this);
                this.flagRedirect = true;
                voyantRedirect.Fill = new SolidColorBrush(Colors.Green);
            }
            catch
            {
                MessageBox.Show("Echec création port COM");
            }
        }

        public void sendToRedirect(string msg, string name)        //Send msg
        {
            if ((this.flagRedirect==true) && name== "Sondeur")
            {
                if (msg.Contains("$"))
                {
                    this.tcpipRedirect.newMessage = true;
                    this.tcpipRedirect.message = msg + "\r\n";
                }
            }
            else { }
        }


        //CLOSE WINDOWS - CLOSE COMM !
        private  void FermetureClosing(object sender, CancelEventArgs e)
        {
            try
            {
                this.comRS232Sondeur.closeCOM();
            }
            catch { }
            try {this.tcpipRedirect.closeServer(); } catch { }
            
            Trace.WriteLine("Fermeture");
        }

        //MAJ Display
        public void majDebugDisplay(string msg)
        {

            if (System.Windows.Application.Current.Dispatcher.CheckAccess())
            {
                //do whatever you want to do with shared object.              
                this.textBlockDebug.AppendText(msg +"\n");
                this.textBlockDebug.ScrollToEnd();
            }
            else
            {
                //Other wise re-invoke the method with UI thread access
                System.Windows.Application.Current.Dispatcher.Invoke(new System.Action(() => majDebugDisplay(msg)));
            }
        }

        //Send command
        private char Ctrls = (char)19;
        private char Ctrlq = (char)17;
        private string command;
        private void SendS_Click(object sender, RoutedEventArgs e)
        {
            this.command = Ctrls.ToString();
            this.comRS232Sondeur.write(this.command);
        }
        private void SendQ_Click(object sender, RoutedEventArgs e)
        {
            this.command = Ctrlq.ToString();
            this.comRS232Sondeur.write(this.command);
        }

        public void sendConfig(string msg)
        {
            this.comRS232Sondeur.write(msg);
        }


        //Treshold
        private void openTresholdConfig(object sender, RoutedEventArgs e)
        {
            this.tresholdWindow.Show();
        }

        //Detection Method
        private void buttonDetectionMethod_Click(object sender, RoutedEventArgs e)
        {
            this.detectionMethodWindow.Show();
        }

        //Output Format
        private void buttonOutputFormat_Click(object sender, RoutedEventArgs e)
        {
            this.outputFormatWindow.Show();
        }

        //TVG Auto Gain
        private void buttonTVGAutoGain_Click(object sender, RoutedEventArgs e)
        {
            this.tvgAutoGainWindow.Show();
        }

        //Minimum gap width
        private void buttonMinimumGap_Click(object sender, RoutedEventArgs e)
        {
            this.MinimumGapWidthConfigWindow.Show();
        }

        //Minimum Valid return
        private void buttonMinimaValidReturn_Click(object sender, RoutedEventArgs e)
        {
            this.MinimumValidReturnConfigWindow.Show();
        }

        //R0 Maximum Range
        private void buttonR0MaximumRange_Click(object sender, RoutedEventArgs e)
        {
            this.R0MaximumRangeConfigWindow.Show();
        }


        //R0 Minimum Range
        private void buttonR0MinimumRange_Click(object sender, RoutedEventArgs e)
        {
            this.R0MinimumRangeConfigWindow.Show();
        }

        //Xmit pulse
        private void buttonXmitPulse_Click(object sender, RoutedEventArgs e)
        {
            this.XmitPulseConfigWindow.Show();
        }

        //Maximum Resolution
        private void buttonMaximumResolution_Click(object sender, RoutedEventArgs e)
        {
            this.MaximumResolutionConfigWindow.Show();
        }

        //Maximum Range
        private void buttonMaximumRange_Click(object sender, RoutedEventArgs e)
        {
            this.MaximumRangeConfigWindow.Show();
        }

        //mNMEA o/p scale
        private void buttonNMEAscal_Click(object sender, RoutedEventArgs e)
        {
            this.NMEAScaleConfigWindow.Show();
        }

        //XmitGate
        private void buttonXmitGate_Click(object sender, RoutedEventArgs e)
        {
            this.XmitGateConfigWindow.Show();
        }

        //TVG
        private void buttonTVG_Click(object sender, RoutedEventArgs e)
        {
            this.TVGConfigWindow.Show();
        }

        //Sound Velocity
        private void buttonSoundVelocity_Click(object sender, RoutedEventArgs e)
        {
            this.soundVelocityConfigWindow.Show();
        }

        //Range Window
        private void buttonRangeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.rangeWindowConfigWindow.Show();
        }

        //Transmit power
        private void buttonTransmitPower_Click(object sender, RoutedEventArgs e)
        {
            this.transmitPowerConfigWindow.Show();
        }

        //Minimum Ping
        private void buttonMinimumPingPeriod_Click(object sender, RoutedEventArgs e)
        {
            this.minimumPingConfigWindow.Show();
        }
        
        //Send manual command
        private void buttonInputToSend_Click(object sender, RoutedEventArgs e)
        {
            this.msg = this.textBoxInput.Text;
            this.textBoxInput.Text = "";
            sendConfig(msg);
        }

        private void searchGotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxInput.Text = "";
        }

        private void textBoxRedirectGotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxInputCOM.Text = "";
        }


        public void errorDisplay(int number)
        {
            if(number == 2)
            {
                MessageBox.Show("Erreur écriture, port fermé");
            }          
        }
    }
}

