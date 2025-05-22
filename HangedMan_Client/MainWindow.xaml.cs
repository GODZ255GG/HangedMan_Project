using HangedMan_Client.Views;
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
using System.Windows.Shapes;

namespace HangedMan_Client
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            goToRegisterView();

        }

        private void goToRegisterView()
        {
            this.frame.Navigate(new RegisterView(this));
        }

        public void changeLanguage(string cultureCode)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureCode);

            // Guardar el estado actual de los botones
            var currentView = frame.Content as RegisterView;
            bool wasEnglishSelected = currentView?.btnChangeEnglish.Background.ToString() == "#FF007ACC";

            // Actualizar la vista existente
            if (currentView != null)
            {
                currentView.UpdateLanguageResources();
                currentView.UpdateButtonColors(wasEnglishSelected);
            }
        }
    }
}
