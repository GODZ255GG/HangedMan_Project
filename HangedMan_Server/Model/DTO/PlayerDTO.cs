using HangedMan_Server.Model.POCO;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;

namespace HangedMan_Server.Model.DTO
{
    public class PlayerDTO
    {
        public static bool registerPlayer(Player newPlayer)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContex = new DataContext(connection);
                dataContex.GetTable<Player>().InsertOnSubmit(newPlayer);
                dataContex.SubmitChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool emailAlreadyRegistered(string email)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                bool emailRegistered = dataContext.GetTable<Player>().Any(pl => pl.Email == email);
                return emailRegistered;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool telephoneAlreadyRegistered(string telephone)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                bool telephoneRegistered = dataContext.GetTable<Player>().Any(pl => pl.PhoneNumber == telephone);
                return telephoneRegistered;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool nicknameAlreadyRegistered(string nickname)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                bool nicknameRegistered = dataContext.GetTable<Player>().Any(pl => pl.NickName == nickname);
                return nicknameRegistered;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}