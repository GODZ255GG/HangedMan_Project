using HangedMan_Server.Model.POCO;
using System.Collections.Generic;
using HangedMan_Server.Model.DTO;

namespace HangedMan_Server
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "GameServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione GameServices.svc o GameServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class GameServices : IGameServices
    {
        public Match createMatch(Match createMatch)
        {
            return MatchDTO.createMatch(createMatch);
        }

        public List<Match> getMatchesPlayed(int playerID)
        {
            return MatchDTO.getMatchesPlayed(playerID);
        }

        public List<Match> getMatchList(int playerID)
        {
            return MatchDTO.getMatchesAvaliables(playerID);
        }

        public bool initMatch(int guestID, int matchID)
        {
            return MatchDTO.initMatch(guestID, matchID);
        }

        public string getGuestNickName(int playerID)
        {
            return MatchDTO.getGuestNickName(playerID);
        }

        public bool isThereGuest(int matchID)
        {
            return MatchDTO.isThereGuest(matchID);
        }

        public bool leaveMatch(int matchID)
        {
            return MatchDTO.leaveMatch(matchID);
        }
    }
}
