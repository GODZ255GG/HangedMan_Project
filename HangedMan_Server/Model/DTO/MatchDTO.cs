using HangedMan_Server.Model.POCO;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;

namespace HangedMan_Server.Model.DTO
{
    public class MatchDTO
    {
        public static Match createMatch(Match newMatch)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                dataContext.GetTable<Match>().InsertOnSubmit(newMatch);
                dataContext.SubmitChanges();
                return newMatch;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static List<Match> getMatchesAvaliables(int playerID)
        {
            try
            {
                using (var connection = ConnectionDB.getConnection())
                {
                    connection.Open();
                    DataContext dataContext = new DataContext(connection);
                    var matches = (from mat in dataContext.GetTable<Match>()
                                   where mat.StatusMatchID == 1 && mat.ChallengerID != playerID
                                   select mat).ToList();
                    return matches;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static List<Match> getMatchesPlayed(int playerID)
        {
            try
            {
                using (var connection = ConnectionDB.getConnection())
                {
                    connection.Open();
                    DataContext dataContext = new DataContext(connection);

                    var matches = (from mat in dataContext.GetTable<Match>()
                                   where (mat.StatusMatchID == 2 || mat.StatusMatchID == 3) &&
                                         (mat.ChallengerID == playerID || mat.GuestID == playerID)
                                   orderby mat.DateMatch descending
                                   select mat).ToList();

                    return matches;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool initMatch(int guestID, int matchID)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                var matchToUpdate = dataContext.GetTable<Match>().FirstOrDefault(mat => mat.MatchID == matchID);
                if (matchToUpdate != null)
                {
                    matchToUpdate.GuestID = guestID;
                    matchToUpdate.StatusMatchID = 4;
                    dataContext.SubmitChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}