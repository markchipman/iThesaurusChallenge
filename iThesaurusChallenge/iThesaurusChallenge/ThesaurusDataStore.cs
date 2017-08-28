using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iThesaurusChallenge.Interfaces;
using Newtonsoft.Json.Linq;

namespace iThesaurusChallenge
{
    public class ThesaurusDataStore : IThesuarusWordRepository
    {
        /// <summary>
        /// The thesaurus words dictionary
        /// </summary>
        private readonly Dictionary<string, ThesaurusWord> _thesaurusWordsDictionary = new Dictionary<string, ThesaurusWord>();

        /// <summary>
        /// Inserts the specified thesaurus word
        /// </summary>
        /// <param name="thesaurusWord">The thesaurus word</param>
        public void Insert(ThesaurusWord thesaurusWord)
        {
            if (thesaurusWord == null)
            {
                return;
            }

            if (!_thesaurusWordsDictionary.ContainsKey(thesaurusWord.GetTargetWord()))
                _thesaurusWordsDictionary.Add(thesaurusWord.GetTargetWord(), thesaurusWord);
            else
                _thesaurusWordsDictionary[thesaurusWord.GetTargetWord()] = thesaurusWord;
        }

        /// <summary>
        /// Updates the specified thesaurus word.
        /// </summary>
        /// <param name="thesaurusWord">The thesaurus word</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(ThesaurusWord thesaurusWord)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified thesaurus word
        /// </summary>
        /// <param name="thesaurusWord">The thesaurus word</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(ThesaurusWord thesaurusWord)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the thesaurus word by provided word
        /// </summary>
        /// <param name="thesaurusWord">The thesaurus word</param>
        /// <returns></returns>
        public ThesaurusWord GetByWord(string thesaurusWord)
        {
            return _thesaurusWordsDictionary.ContainsKey(thesaurusWord) ? _thesaurusWordsDictionary[thesaurusWord] : null;
        }


        /// <summary>
        /// Gets all theasurus words
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ThesaurusWord> GetAll()
        {
            return _thesaurusWordsDictionary.Values.AsEnumerable();
        }

        /// <summary>
        /// Gets the by identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ThesaurusWord> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Load(string resourceFileName)
        {
            var thesaurusWordsJsonAll = GetEmbeddedResourceAsString(String.IsNullOrEmpty(resourceFileName) ? "thesaurausSeedData.json" : resourceFileName);

            JArray jsonValThesaurusWords = JArray.Parse(thesaurusWordsJsonAll) as JArray;
            dynamic thesaurusData = jsonValThesaurusWords;
            foreach (dynamic data in thesaurusData)
            {
                // load up data 
            }
        }

        public void Save(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }
        }

        private string GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
