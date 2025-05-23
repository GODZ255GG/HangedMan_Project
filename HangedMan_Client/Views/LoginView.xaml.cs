using HangedMan_Client.PlayerServices;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HangedMan_Client.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        PlayerServicesClient playerServices = new PlayerServicesClient();
        private MainWindow mainWindow;
        public LoginView(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void BtnChangeEnglish_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.changeLanguageLogin("en");
        }

        private void BtnChangeSpanish_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.changeLanguageLogin("es");
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.goToRegisterView();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Password;

                if (!checkCredentials(email, password))
                {
                    string message = Properties.Resources.IncompleteLogginMessage;
                    MessageBox.Show(message);
                }
                else
                {
                    Player player = playerServices.logIn(email, password);
                    if (player != null)
                    {
                        string message = Properties.Resources.LogginMessage;
                        string messageComplete = message + " " + player.NickName;
                        MessageBox.Show(messageComplete);
                        SessionManager.Instance.Login(player);

                        NavigationService.Navigate(new Lobby());
                    }
                    else
                    {
                        string message = Properties.Resources.ErrorLogginMessage;
                        MessageBox.Show(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool checkCredentials(string emai, string password)
        {
            if (string.IsNullOrEmpty(emai) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            return true;

        }
    }
}
