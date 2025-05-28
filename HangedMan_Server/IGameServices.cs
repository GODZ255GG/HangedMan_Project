using System.Collections.Generic;
using HangedMan_Server.Model.POCO;
using System.ServiceModel;

namespace HangedMan_Server
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGameServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGameServices
    {
        [OperationContract]
        Match createMatch(Match createMatch);
        [OperationContract]
        List<Match> getMatchList(int playerID);
        [OperationContract]
        List<Match> getMatchesPlayed(int playerID);
        [OperationContract]
        bool initMatch(int guestID, int matchID);
        [OperationContract]
        string getGuestNickName(int playerID);

        [OperationContract]
        bool isThereGuest(int matchID);
        [OperationContract]
        bool leaveMatch(int matchID);
    }
}
