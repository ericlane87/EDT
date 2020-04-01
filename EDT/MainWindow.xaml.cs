using System;
using System.Collections.Generic;
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

        }

        public void ActiiveMQValidation(string env)
        {
            ActiveMQ AQ = new ActiveMQ();

            string PrimaryAqAddress = AQ.getPrimaryAQ(env);
            string SecoundaryAqAddress = AQ.getSecoundaryAQ(env);

            bool ActiveMQ = CheckUI(PrimaryAqAddress, SecoundaryAqAddress);

        }

        public bool CheckUI(string URL_prim, string URL_secound)
        {
            if (URL_secound.Contains("NULL"))
            {
                return false;
            }


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


        public void UpdateUserInterface_history(bool result)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (result == true)
                {
                     History_UI_txtbx.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
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

        private void Cbx_ENV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }


}
    
    




