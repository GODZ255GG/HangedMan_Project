using HangedMan_Server.Model.POCO;
using HangedMan_Server.Model.DTO;

namespace HangedMan_Server
{
    public class PlayerServices : IPlayerServices
    {
        public bool registerPlayer(Player newPlayer)
        {
            return PlayerDTO.registerPlayer(newPlayer);
        }

        public bool emailAlreadyRegistered(string email)
        {
            return PlayerDTO.emailAlreadyRegistered(email);
        }

        public bool nicknameAlreadyRegistered(string nickname)
        {
            return PlayerDTO.nicknameAlreadyRegistered(nickname);
        }

        public bool telephoneAlreadyExist(string telephone)
        {
            return PlayerDTO.telephoneAlreadyRegistered(telephone);
        }

        public Player logIn(string email, string password)
        {
            return PlayerDTO.logIn(email, password);
        }
    }
}
