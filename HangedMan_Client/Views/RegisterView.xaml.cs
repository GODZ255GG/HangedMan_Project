using HangedMan_Client.PlayerServices;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HangedMan_Client.Views
{
    /// <summary>
    /// Lógica de interacción para RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        PlayerServicesClient playerServicesClient = new PlayerServicesClient();
        private MainWindow mainWindow;
        public RegisterView(MainWindow window)
        {
            InitializeComponent();
            disableErrorLabels();
            this.mainWindow = window;
        }

        private bool checkData()
        {
            bool hasEmptyField = false;

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                labelEmailEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelEmailEmpty.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(txtNickname.Text))
            {
                labelNicknameEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelNicknameEmpty.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(txtNames.Text))
            {
                labelNamesEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelNamesEmpty.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(txtFirstSurname.Text))
            {
                labelFirstSurnameEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelFirstSurnameEmpty.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(txtSecondSurname.Text))
            {
                labelSecondSurnameEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelSecondSurnameEmpty.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                labelTelephoneEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelTelephoneEmpty.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                labelPasswordEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelPasswordEmpty.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrWhiteSpace(txtPasswordConfirmation.Password))
            {
                labelPasswordConfirmationEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelPasswordConfirmationEmpty.Visibility = Visibility.Hidden;
            }

            if (dpBirthDate.SelectedDate == null)
            {
                labelBirthDateEmpty.Visibility = Visibility.Visible;
                hasEmptyField = true;
            }
            else
            {
                labelBirthDateEmpty.Visibility = Visibility.Hidden;
            }

            return hasEmptyField;
        }

        private void disableErrorLabels()
        {
            labelBirthDateEmpty.Visibility = Visibility.Hidden;
            labelEmailEmpty.Visibility = Visibility.Hidden;
            labelNamesEmpty.Visibility = Visibility.Hidden;
            labelNicknameEmpty.Visibility = Visibility.Hidden;
            labelPasswordConfirmationEmpty.Visibility = Visibility.Hidden;
            labelPasswordEmpty.Visibility = Visibility.Hidden;
            labelSecondSurnameEmpty.Visibility = Visibility.Hidden;
            labelFirstSurnameEmpty.Visibility = Visibility.Hidden;
            labelTelephoneEmpty.Visibility = Visibility.Hidden;
        }

        private bool checkPasswords()
        {
            return !string.IsNullOrEmpty(txtPassword.Password) && !string.IsNullOrEmpty(txtPasswordConfirmation.Password);
        }


        private bool checkPasswordsMatch()
        {
            return txtPassword.Password == txtPasswordConfirmation.Password;
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            if (!checkData())
            {
                if (checkPasswords())
                {
                    if (checkPasswordsMatch())
                    {
                        if (allValidate())
                        {
                            if (await playerServicesClient.emailAlreadyRegisteredAsync(txtEmail.Text))
                            {
                                string message = Properties.Resources.NicknameAlreadyRegistered;
                                MessageBox.Show(message);
                            }
                            else if (await playerServicesClient.emailAlreadyRegisteredAsync(txtEmail.Text))
                            {
                                string message = Properties.Resources.EmailAlreadyRegistered;
                                MessageBox.Show(message);
                            }
                            else if (await playerServicesClient.telephoneAlreadyExistAsync(txtTelephone.Text))
                            {
                                string message = Properties.Resources.TelephoneAlreadyRegistered;
                                MessageBox.Show(message);
                            }
                            else
                            {
                                try
                                {
                                    Player newPlayer = createNewPlayer();
                                    bool confirmation = await playerServicesClient.registerPlayerAsync(newPlayer);
                                    if (confirmation)
                                    {
                                        string message = Properties.Resources.ConfirmationUserRegister;
                                        MessageBox.Show(message);
                                        //NavigationService.Navigate(new LogIn(Application.Current.MainWindow as MainWindow));
                                    }
                                    else
                                    {
                                        string message = Properties.Resources.ErrorUserRegister;
                                        MessageBox.Show(message);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        string message = Properties.Resources.PasswordDoesntMatch;
                        MessageBox.Show(message);
                    }
                }
            }
        }

        private Player createNewPlayer()
        {
            Player newPlayer = new Player();
            newPlayer.Email = txtEmail.Text.Trim();
            newPlayer.NickName = txtNickname.Text.Trim();
            newPlayer.Password = txtPassword.Password.Trim();
            newPlayer.PhoneNumber = txtTelephone.Text.Trim();
            newPlayer.Names = txtNames.Text.Trim();
            newPlayer.FirstSurname = txtFirstSurname.Text.Trim();
            newPlayer.SecondSurname = txtSecondSurname.Text.Trim();
            newPlayer.PointsEarned = 0;
            newPlayer.BirthDate = dpBirthDate.Text;

            return newPlayer;
        }

        private bool allValidate()
        {
            string email = txtEmail.Text.Trim();
            string nickName = txtNickname.Text.Trim();
            string name = txtNames.Text.Trim();
            string firstSurname = txtFirstSurname.Text.Trim();
            string secondSurname = txtSecondSurname.Text.Trim();
            string password = txtPassword.Password.Trim();
            string phoneNumber = txtTelephone.Text.Trim();

            if (validateNames(name) && validateNames(firstSurname) && validateNames(secondSurname) && validateNick(nickName)
                && validateEmail(email) && validatePassword(password) && validateTelephone(phoneNumber))
            {
                return true;
            }
            return false;
        }

        private bool validateNames(string name)
        {

            if (Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                return true;
            }
            else
            {
                string message = Properties.Resources.NamesNotValid;
                MessageBox.Show(message);
                return false;
            }
        }

        private bool validateTelephone(string phone)
        {
            string message = Properties.Resources.PhoneNotValid;
            if (phone.Length != 10)
            {
                MessageBox.Show(message);
                return false;
            }

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show(message);
                    txtTelephone.Clear();
                    return false;
                }
            }
            return true;
        }

        private bool validateEmail(string email)
        {
            string message = Properties.Resources.EmailNotValid;
            if (Regex.IsMatch(email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                return true;
            }
            else
            {

                MessageBox.Show(message);
                return false;
            }
        }

        private bool validateNick(string nickName)
        {
            string message = Properties.Resources.NicknameNotValid;
            if (Regex.IsMatch(nickName, @"^[a-zA-Z0-9]+$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show(message);
                return false;
            }
        }

        public bool validatePassword(string password)
        {
            string message = Properties.Resources.PasswordNotValid;
            if (Regex.IsMatch(password, @"^[a-zA-Z0-9]{8,15}$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show(message);
                return false;
            }
        }

        private void BtnChangeEnglish_Click(object sender, RoutedEventArgs e)
        {
            btnChangeEnglish.Tag = "Selected";
            btnChangeSpanish.Tag = null;
            mainWindow.changeLanguage("en");
        }

        private void BtnChangeSpanish_Click(object sender, RoutedEventArgs e)
        {
            btnChangeSpanish.Tag = "Selected";
            btnChangeEnglish.Tag = null;
            mainWindow.changeLanguage("es");
        }

        public void UpdateLanguageResources()
        {
            //Subtitulo
            lblSubtitle.Content = Properties.Resources.labelCreateNewAccount;

            // Botones de idioma
            btnChangeEnglish.Content = Properties.Resources.EnglishButton;
            btnChangeSpanish.Content = Properties.Resources.SpanishButton;

            // Columna Izquierda
            lblEmail.Content = Properties.Resources.EmailRegister;
            labelEmailEmpty.Content = Properties.Resources.LabelEmailEmpty;

            lblNames.Content = Properties.Resources.NamesRegister;
            labelNamesEmpty.Content = Properties.Resources.LabelNamesEmpty;

            lblFirstSurname.Content = Properties.Resources.FirstNameRegister;
            labelFirstSurnameEmpty.Content = Properties.Resources.LabelFirstSurnameEmpty;

            lblPassword.Content = Properties.Resources.PasswordRegister;
            labelPasswordEmpty.Content = Properties.Resources.LabelPasswordEmpty;

            // Columna Derecha
            lblNickname.Content = Properties.Resources.NickNameRegister;
            labelNicknameEmpty.Content = Properties.Resources.LabelNickEmpty;

            lblSecondSurname.Content = Properties.Resources.SecondNameRegister;
            labelSecondSurnameEmpty.Content = Properties.Resources.LabelSecondSurnameEmpty;

            lblTelephone.Content = Properties.Resources.TelephoneRegister;
            labelTelephoneEmpty.Content = Properties.Resources.LabelTelephoneEmpty;

            lblPasswordConfirmation.Content = Properties.Resources.PasswordConfirmationRegister;
            labelPasswordConfirmationEmpty.Content = Properties.Resources.LabelPaswwordConfirmationEmpty;

            // Sección inferior
            lblBirthDate.Content = Properties.Resources.BirthDateRegister;
            labelBirthDateEmpty.Content = Properties.Resources.LabelBirthDateEmpty;

            // Botones de acción
            btnRegister.Content = Properties.Resources.RegisterButton;
            btnBack.Content = Properties.Resources.BackButton;
        }

        public void UpdateButtonColors(bool englishSelected)
        {
            btnChangeEnglish.Background = englishSelected ?
            (SolidColorBrush)new BrushConverter().ConvertFrom("#FF252526") :
            (SolidColorBrush)new BrushConverter().ConvertFrom("#FF007ACC");

            btnChangeSpanish.Background = !englishSelected ?
                (SolidColorBrush)new BrushConverter().ConvertFrom("#FF252526") :
                (SolidColorBrush)new BrushConverter().ConvertFrom("#FF007ACC");
        }
    }
}
