using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangedMan_Client.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
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
    }
}
