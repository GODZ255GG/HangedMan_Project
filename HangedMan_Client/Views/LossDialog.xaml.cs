using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HangedMan_Client.Views
{
    /// <summary>
    /// Lógica de interacción para LossDialog.xaml
    /// </summary>
    public partial class LossDialog : Window
    {
        private string message;
        public LossDialog(string message)
        {
            InitializeComponent();
            this.message = message;
            TextView(message);
        }

        private void TextView(String message)
        {
            lblMessage.Content = message;
        }

        private void BtnAcept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.frame.Navigate(new LobbyView());

        }
    }
}
