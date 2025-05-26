using HangedMan_Server.Model.POCO;
using System.Collections.Generic;
using System.ServiceModel;

namespace HangedMan_Server
{
    [ServiceContract]
    public interface IWordServices
    {
        [OperationContract]
        List<Category> GetCategories();
        [OperationContract]
        List<Word> GetWordsPerCategory(int category);
        [OperationContract]
        string getWordSpanish(int wordID);
        [OperationContract]
        string getWordEnglish(int wordID);
        [OperationContract]
        string getClueSpanish(int wordID);
        [OperationContract]
        string getClueEnglish(int wordID);
    }
}
