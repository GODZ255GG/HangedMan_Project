using HangedMan_Client.GameServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HangedMan_Client.Views
{
    /// <summary>
    /// Lógica de interacción para WaitingRoomView.xaml
    /// </summary>
    public partial class WaitingRoomView : Page
    {
        GameServicesClient gameServicesClient = new GameServicesClient();
        Match match;
        private DispatcherTimer dispatcherTimer;
        public WaitingRoomView(Match match)
        {
            InitializeComponent();
            this.match = match;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void BtnLeaveMatch_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseas abandonar la partida?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                LeaveMatch();
            }
        }

        private void LeaveMatch()
        {
            dispatcherTimer.Stop();
            try
            {
                bool exit = gameServicesClient.leaveMatch(match.MatchID);
                if (exit)
                {
                    string message = Properties.Resources.MatchLeaveMessage;
                    MessageBox.Show(message);
                    NavigationService.Navigate(new LobbyView());

                }
                else
                {
                    string message = Properties.Resources.MatchLeaveMessageError;
                    MessageBox.Show(message);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            isThereGuest();
        }

        private void isThereGuest()
        {
            bool isThereGuest = gameServicesClient.isThereGuest(match.MatchID);
            if (isThereGuest)
            {
                dispatcherTimer.Stop();
                string message = Properties.Resources.PlayerJoinedMessage;
                lblWaitingPlayer.Content = message;
                btnLeaveMatch.IsEnabled = false;
                DispatcherTimer delayTimer = new DispatcherTimer();
                delayTimer.Interval = TimeSpan.FromSeconds(1);
                delayTimer.Tick += (sender, e) =>
                {
                    delayTimer.Stop();
                    NavigationService.Navigate(new ChallengedView(match));
                };
                delayTimer.Start();
            }
        }
    }
}
