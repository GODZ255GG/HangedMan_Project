using HangedMan_Server.Model.DTO;
using HangedMan_Server.Model.POCO;
using System.Collections.Generic;

namespace HangedMan_Server
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WordServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WordServices.svc o WordServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WordServices : IWordServices
    {
        public List<Category> GetCategories()
        {
            return CategoryDTO.getCategories();
        }

        public string getClueEnglish(int wordID)
        {
            return WordDTO.getClueEnglish(wordID);
        }

        public string getClueSpanish(int wordID)
        {
            return WordDTO.getClueSpanish(wordID);
        }

        public string getWordEnglish(int wordID)
        {
            return WordDTO.getWordEnglish(wordID);
        }

        public string getWordSpanish(int wordID)
        {
            return WordDTO.getWordSpanish(wordID);
        }

        public List<Word> GetWordsPerCategory(int category)
        {
            return WordDTO.getWordsPerCategory(category);
        }
    }
}
