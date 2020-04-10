using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EDT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



        }



        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            Validate.IsEnabled = false;

            UserInterface UI_primary = new UserInterface();
            string Enviroment = cbx_ENV.Text;
            string PrimaryUI_Address = UI_primary.getPrimaryUI(Enviroment);
            string Secoundary_Address = UI_primary.getSecoundaryUI(Enviroment);

            string PrimaryUI_Address_histroy = UI_primary.getPrimaryUI_History(Enviroment);
            string Secoundary_Address_history = UI_primary.getSecoundaryUI_History(Enviroment);

            bool userInterface = CheckUI(PrimaryUI_Address, Secoundary_Address);

            CreatUIThread_Processing(userInterface);


            bool userInterface_history = CheckUI(PrimaryUI_Address_histroy, Secoundary_Address_history);

            CreatUIThread_History(userInterface_history);
            ActiiveMQValidation(Enviroment);







            List<string> servers = new List<string>();
            servers.Add("VA22PWVEGM311");
            servers.Add("VA22PWVEGM312");
            servers.Add("VA22PWVEGM313");

            logLbx.DataContext = servers;

        }

        public void ActiiveMQValidation(string env)
        {
            ActiveMQ AQ = new ActiveMQ();

            string PrimaryAqAddress = AQ.getPrimaryAQ(env);
            string SecoundaryAqAddress = AQ.getSecoundaryAQ(env);
            string PrimaryAqAddress_History = AQ.getPrimaryAQ_History(env);
            string SecoundaryAqAddress_History = AQ.getSecoundaryAQ_History(env);
            bool ActiveMQ = CheckUI(PrimaryAqAddress, SecoundaryAqAddress);
            bool ActivMQ_History = CheckUI(PrimaryAqAddress_History, SecoundaryAqAddress_History);
            CreatUIThread_ActiveMQ(ActiveMQ, ActivMQ_History);
            DatamartValidation(env);
        }

        public void DatamartValidation(string env)
        {
            Datamart DM = new Datamart();

            string PrimaryAqAddress = DM.getPrimaryDM(env);
            string SecoundaryAqAddress = DM.getSecoundaryDM(env);
            string PrimaryDMAddress_History = DM.getPrimaryDM_History(env);
            string SecoundaryDMAddress_History = DM.getSecoundaryDM_History(env);
            bool ActiveMQ = CheckUI(PrimaryAqAddress, SecoundaryAqAddress);
            bool ActivMQ_History = CheckUI(PrimaryDMAddress_History, SecoundaryDMAddress_History);
            CreatUIThread_ActiveDM(ActiveMQ, ActivMQ_History);
        }


        public bool CheckUI(string URL_prim, string URL_secound)
        {
            if (URL_prim.Contains("NULL"))
            {
                return false;
            }


            WebRequest request = WebRequest.Create(URL_prim);
            try
            {

                if (URL_prim.Contains("NULL"))
                {
                    return false;
                }
                request.Timeout = 1000;
                request.GetResponse();

                return true;


            }
            catch //If exception thrown then couldn't get response from address
            {

                try
                {
                    if (URL_secound.Contains("NULL"))
                    {
                        return false;
                    }
                    WebRequest requestSecoundary = WebRequest.Create(URL_secound);
                    request.Timeout = 1000;

                    requestSecoundary.GetResponse();

                    return true;


                }
                catch //If exception thrown then couldn't get response from address
                {

                    return false;
                }
            }



        }
        public void CreatUIThread_ActiveMQ(bool processing, bool history)
        {
            try
            {


                {
                    Thread thread = new Thread(delegate ()
                    {
                        updateUserInterface_ActiveMQ(processing,history);
                    });
                    thread.IsBackground = true;
                    thread.Start();

                }
            }









            catch (Exception ex)//If exception thrown then couldn't get response from address
            {

                MessageBox.Show(ex.ToString());
            }



        }








        public void CreatUIThread_ActiveDM(bool processing, bool history)
        {
            try
            {


                {
                    Thread thread = new Thread(delegate ()
                    {
                        updateUserInterface_ActiveDM(processing, history);
                    });
                    thread.IsBackground = true;
                    thread.Start();

                }
            }


            catch (Exception ex)//If exception thrown then couldn't get response from address
            {

                MessageBox.Show(ex.ToString());
            }



        }










        public void CreatUIThread_Processing(bool results)
        {
            try
            {

             
                {
                    Thread thread = new Thread(delegate ()
                    {
                        updateUserInterface_Processing(results);
                    });
                    thread.IsBackground = true;
                    thread.Start();
                    
                }
            }







            catch (Exception ex)//If exception thrown then couldn't get response from address
            {

                MessageBox.Show(ex.ToString());
            }



        }



        public void CreatUIThread_History(bool results)
        {
            try
            {


                {
                    Thread thread = new Thread(delegate ()
                    {
                        UpdateUserInterface_history(results);
                    });
                    thread.IsBackground = true;
                    thread.Start();

                }
            }







            catch (Exception ex)//If exception thrown then couldn't get response from address
            {

                MessageBox.Show(ex.ToString());
            }



        }


        public void updateUserInterface_Processing(bool result)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (result == true)
                {
                    ProcessingUI_txtbx.Foreground = new SolidColorBrush(Colors.Green);
                    pbMain.IsIndeterminate = true;
                    UIChekbox.IsChecked = true;
                }
                else
                {
                    ProcessingUI_txtbx.Foreground = new SolidColorBrush(Colors.Red);
                    pbMain.IsIndeterminate = true;
                    UIChekbox.IsChecked = true;


                }



            }));
        }



        public void updateUserInterface_ActiveMQ(bool processing, bool history)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (processing == true)
                {
                    activeMQ_ProcessingTxtbx.Foreground = new SolidColorBrush(Colors.Green);
                    activeMQcbx.IsChecked = true;

                    EnvLable.Content = "Current environment:" + "" + cbx_ENV.Text.ToString();
                    EnvLable.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    activeMQ_ProcessingTxtbx.Foreground = new SolidColorBrush(Colors.Red);
                    activeMQcbx.IsChecked = true;

                    EnvLable.Content = "Current environment:" + "" + cbx_ENV.Text.ToString();
                    EnvLable.Foreground = new SolidColorBrush(Colors.Black);



                }


                if (history == true)
                {
                    activeMQ_HistoryTxtbx.Foreground = new SolidColorBrush(Colors.Green);
                    activeMQcbx.IsChecked = true;

                    activeMQ_HistoryTxtbx.Text = "History";

                }
                else
                {
                    activeMQ_HistoryTxtbx.Text = "History";


                    activeMQ_HistoryTxtbx.Foreground = new SolidColorBrush(Colors.Red);
                    activeMQcbx.IsChecked = true;

                    List<string> NoHistoryEveiorment = new List<string>();
                    NoHistoryEveiorment.Add("DEV2");
                    NoHistoryEveiorment.Add("DEV3");
                    NoHistoryEveiorment.Add("Pre-Prod");
                    NoHistoryEveiorment.Add("SIT1");
                    NoHistoryEveiorment.Add("SIT2");

                    int Count = 0; 

                    while(Count < NoHistoryEveiorment.Count)
                    {
                        if (cbx_ENV.Text == NoHistoryEveiorment[Count])
                        {
                            activeMQ_HistoryTxtbx.Text = "No history enviorment for" + "" + ":"+ NoHistoryEveiorment[Count];

                        }
                        ++Count;
                    }
                    


                }



            }));
        }




        public void updateUserInterface_ActiveDM(bool processing, bool history)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (processing == true)
                {
                    DMProcessin.Foreground = new SolidColorBrush(Colors.Green);
                    DMCKbx.IsChecked = true;
                    DMProcessin.Text = "Processing";

                    pbMain.IsIndeterminate = false;
                }
                else
                {
                    pbMain.IsIndeterminate = false;

                    DMProcessin.Text = "Processing";

                    DMProcessin.Foreground = new SolidColorBrush(Colors.Red);
                    DMCKbx.IsChecked = true;

                    List<string> NoDMEveiorment = new List<string>();

                    NoDMEveiorment.Add("SIT2");

                    int Count = 0;

                    while (Count < NoDMEveiorment.Count)
                    {
                        if (cbx_ENV.Text == NoDMEveiorment[Count])
                        {
                            DMProcessin.Text = "No Datamart for" + "" + ":" + NoDMEveiorment[Count];

                        }
                        ++Count;
                    }




                }


                if (history == true)
                {
                    DMHistory.Foreground = new SolidColorBrush(Colors.Green);
                    DMCKbx.IsChecked = true;

                    DMHistory.Text = "History";







                }
                else
                {
                    DMHistory.Text = "History";


                    DMHistory.Foreground = new SolidColorBrush(Colors.Red);
                    DMCKbx.IsChecked = true;

                    List<string> NoHistoryEveiorment = new List<string>();
                    NoHistoryEveiorment.Add("DEV2");
                    NoHistoryEveiorment.Add("DEV3");
                    NoHistoryEveiorment.Add("Pre-Prod");
                    NoHistoryEveiorment.Add("SIT1");
                    NoHistoryEveiorment.Add("SIT2");

                    int Count = 0;

                    while (Count < NoHistoryEveiorment.Count)
                    {
                        if (cbx_ENV.Text == NoHistoryEveiorment[Count])
                        {
                            DMHistory.Text = "No history enviorment for" + "" + ":" + NoHistoryEveiorment[Count];

                        }
                        ++Count;
                    }



                }



            }));
        }







        public void UpdateUserInterface_history(bool result)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (result == true)
                {
                     History_UI_txtbx.Foreground = new SolidColorBrush(Colors.Green);
                    History_UI_txtbx.Text = "History";
                }
                else
                {

                    History_UI_txtbx.Text = "History";
                    List<string> NoHistoryEveiorment = new List<string>();
                    NoHistoryEveiorment.Add("DEV2");
                    NoHistoryEveiorment.Add("DEV3");
                    NoHistoryEveiorment.Add("Pre-Prod");
                    NoHistoryEveiorment.Add("SIT1");
                    NoHistoryEveiorment.Add("SIT2");

                    int Count = 0;

                    while (Count < NoHistoryEveiorment.Count)
                    {
                        if (cbx_ENV.Text == NoHistoryEveiorment[Count])
                        {
                            History_UI_txtbx.Text = "No history enviorment for" + "" + ":" + NoHistoryEveiorment[Count];

                        }
                   
                        ++Count;


                    }
                    History_UI_txtbx.Foreground = new SolidColorBrush(Colors.Red);


                }



            }));
        }

        private bool CheckUI_History(string URL_prim,string URL_secound)
        {
            WebRequest request = WebRequest.Create(URL_prim);
            try
            {
                request.Timeout = 1000;
                request.GetResponse();

                return true;


            }
            catch //If exception thrown then couldn't get response from address
            {

                try
                {

                    if (URL_secound == "NULL")
                    {
                        return false;
                    }
                    WebRequest requestSecoundary = WebRequest.Create(URL_secound);
                    request.Timeout = 1000;

                    requestSecoundary.GetResponse();

                    return true;


                }
                catch //If exception thrown then couldn't get response from address
                {

                    return false;
                }
            }

        }

        private void Cbx_ENV_DropDownClosed(object sender, EventArgs e)



        {


            if (cbx_ENV.Text.ToString() != null)
            {
                Validate.IsEnabled = true;
            }


            if (cbx_ENV.Text.ToString() == "Production")
            {
                List<string> logs_production = new List<string>();
            logs_production.Add("XE Servers:");
           
                logs_production.Add("VA22PWVEGM311");
            logs_production.Add("VA22PWVEGM312");
            logs_production.Add("VA22PWVEGM313");

                logs_production.Add("Service Manager:");
                logs_production.Add("VA22PWVEGM309");
                logs_production.Add("VA22PWVEGM310");

                        
                List<string> logs_productionHistory = new List<string>();
                logs_productionHistory.Add("XE Servers:");

                logs_productionHistory.Add("VA22PWVEGM350");
                logs_productionHistory.Add("VA22PWVEGM351");
                logs_productionHistory.Add("VA22PWVEGM352");



                logLbxHist.ItemsSource = logs_productionHistory;
                logLbx.ItemsSource = logs_production;
            }

            if(cbx_ENV.Text.ToString() == "Pre-Prod")
            {

                List<string> logs_PREPROD = new List<string>();
                logs_PREPROD.Add("XE Servers:");

                logs_PREPROD.Add("VA22PWVEGM304");
                logs_PREPROD.Add("VA22PWVEGM305");
                logs_PREPROD.Add("VA22PWVEGM306");
                logs_PREPROD.Add("Service Manager:");
                logs_PREPROD.Add("VA22PWVEGM302");
                logs_PREPROD.Add("VA22PWVEGM303");


                logLbx.ItemsSource = logs_PREPROD;


            }


            if(cbx_ENV.Text.ToString() == "UAT")
            {
                List<string> logs_UAT = new List<string>();
                logs_UAT.Add("XE Servers:");



                logs_UAT.Add("VA22TWVEGM307");
                logs_UAT.Add("VA22TWVEGM308");
                logs_UAT.Add("VA22TWVEGM309");

                logs_UAT.Add("Service Manager:");
                logs_UAT.Add("VA22TWVEGM305");
                logs_UAT.Add("VA22TWVEGM306");


                List<string> logs_UATHistory = new List<string>();
                logs_UATHistory.Add("XE Servers:");


                logs_UATHistory.Add("VA22TWVEGM319");
                logs_UATHistory.Add("VA22TWVEGM315");

                logs_UATHistory.Add("Service Manager:");
               logs_UATHistory.Add("VA22TWVEGM317");

                logs_UATHistory.Add("VA22TWVEGM318");

                logLbxHist.ItemsSource = logs_UATHistory;
                logLbx.ItemsSource = logs_UATHistory;
            }



        }

        private void Cbx_ENV_DropDownOpened(object sender, EventArgs e)
        {
            //logLbx.ItemsSource = null;
            //logLbxHist.ItemsSource = null;


          

        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {

            logBtn.IsEnabled = false;
            
                string server = logLbx.SelectedItem.ToString();
                Process.Start(@"\\" + server);

            
         






        }

        private void LogLbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (logLbx.SelectedItem.ToString() == null)
                {
                    return;
                }

                if (logLbx.SelectedItem.ToString() == "XE Servers:")
                {
                    logBtn.IsEnabled = false;

                }

                else if (logLbx.SelectedItem.ToString() == "Service Manager:")
                {
                    logBtn.IsEnabled = false;
                }
                else
                {
                    logBtn.IsEnabled = true;
                }
            }
            catch(Exception)
            {
                return;
            }
        }

        private void LogLbxHist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (logLbxHist.SelectedItem.ToString() == "XE Servers:")
                {
                    logBtndelHistory.IsEnabled = false;

                }

                else if (logLbxHist.SelectedItem.ToString() == "Service Manager:")
                {
                    logBtndelHistory.IsEnabled = false;
                }
                else
                {
                    logBtndelHistory.IsEnabled = true;
                }
            }
            catch(Exception)
            {
                return;
            }
        }

        private void LogBtndelHistory_Click(object sender, RoutedEventArgs e)
        {
            logBtndelHistory.IsEnabled = false;

            string server = logLbxHist.SelectedItem.ToString();
            Process.Start(@"\\" + server);
        }
    }


}
    
    




