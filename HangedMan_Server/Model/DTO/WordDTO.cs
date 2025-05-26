﻿using HangedMan_Server.Model.POCO;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;

namespace HangedMan_Server.Model.DTO
{
    public class WordDTO
    {
        public static List<Word> getWordsPerCategory(int category)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                var words = (from wor in dataContext.GetTable<Word>()
                             where wor.CategoryID == category
                             select wor).ToList();
                return words;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static string getWordSpanish(int wordID)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                var word = (from wor in dataContext.GetTable<Word>()
                            where wor.WordID == wordID
                            select wor.SpanishWord).FirstOrDefault();
                return word;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static string getWordEnglish(int wordID)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                var word = (from wor in dataContext.GetTable<Word>()
                            where wor.WordID == wordID
                            select wor.EnglishWord).FirstOrDefault();
                return word;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static string getClueSpanish(int wordID)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                var clue = (from clu in dataContext.GetTable<Word>()
                            where clu.WordID == wordID
                            select clu.SpanishClue).FirstOrDefault();
                return clue;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static string getClueEnglish(int wordID)
        {
            try
            {
                var connection = ConnectionDB.getConnection();
                connection.Open();
                DataContext dataContext = new DataContext(connection);
                var clue = (from clu in dataContext.GetTable<Word>()
                            where clu.WordID == wordID
                            select clu.EnglishClue).FirstOrDefault();
                return clue;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
