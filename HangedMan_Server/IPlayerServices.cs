using HangedMan_Server.Model.POCO;
using System.ServiceModel;

namespace HangedMan_Server
{
    [ServiceContract]
    public interface IPlayerServices
    {
        [OperationContract]
        bool registerPlayer(Player newPlayer);
        [OperationContract]
        bool emailAlreadyRegistered(string email);
        [OperationContract]
        bool nicknameAlreadyRegistered(string nickname);
        [OperationContract]
        bool telephoneAlreadyExist(string telephone);
        [OperationContract]
        Player logIn(string email, string password);
        [OperationContract]
        bool updatePlayerProfile(Player updatePlayer);
        [OperationContract]
        int GetPoints(int playerID);
    }
}
