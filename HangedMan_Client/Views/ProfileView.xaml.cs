using HangedMan_Client.PlayerServices;
using System.Windows.Controls;

namespace HangedMan_Client.Views
{
    /// <summary>
    /// Lógica de interacción para ProfileView.xaml
    /// </summary>
    public partial class ProfileView : Page
    {
        public ProfileView()
        {
            InitializeComponent();
            showInformationPlayer();
        }

        private void showInformationPlayer()
        {
            Player player = SessionManager.Instance.LoggedInPlayer;
            lblPlayerNickname.Content = player.NickName;
            txtFullName.Text = player.FullName;
            txtEmail.Text = player.Email;
            txtTelephone.Text = player.PhoneNumber;
            txtBirthDate.Text = player.BirthDate;
            lblGlobalScore.Content = player.PointsEarned + " Points";
        }

        private void BtnBackLobby_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new LobbyView());
        }

        private void BtnEditInfo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Player player = SessionManager.Instance.LoggedInPlayer;
            NavigationService.Navigate(new EditProfileView(player));
        }
    }
}
