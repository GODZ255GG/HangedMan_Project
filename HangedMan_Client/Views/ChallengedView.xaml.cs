using HangedMan_Client.GameServices;
using System.Windows.Controls;

namespace HangedMan_Client.Views
{
    /// <summary>
    /// Lógica de interacción para ChallengerView.xaml
    /// </summary>
    public partial class ChallengedView : Page
    {
        GameServicesClient gameServicesClient = new GameServicesClient();
        Match match;
        public ChallengedView(Match match)
        {
            InitializeComponent();
            this.match = match;
        }
    }
}
