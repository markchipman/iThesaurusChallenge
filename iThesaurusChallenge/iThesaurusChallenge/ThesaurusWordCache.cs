using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iThesaurusChallenge.Interfaces;

namespace iThesaurusChallenge
{
    /// <summary>
    /// Cache to hold the data of the thesaurus
    /// </summary>
    public class ThesaurusWordCache : IThesaurusWordRepository
    {

        /// <summary>
        /// The thesaurus word repository
        /// </summary>
        private readonly IThesaurusWordRepository _wordStore;

        /// <summary>
        /// The word cache
        /// </summary>
        private Dictionary<String, ThesaurusWord> _wordCache = new Dictionary<string, ThesaurusWord>();

        /// <summary>
        /// Ctor - Instance of the ThesaurusWordCache class.
        /// </summary>
        /// <param name="thesaurusDataStore">The thesaurus dataStore</param>
        public ThesaurusWordCache(IThesaurusWordRepository thesaurusDataStore)
        {
            _wordStore = thesaurusDataStore;
            _wordCache = new Dictionary<string, ThesaurusWord>();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="thesaurusWordObject">The thesaurusWord Object</param>
        public void Delete(ThesaurusWord thesaurusWordObject)
        {
            _wordCache.Remove(thesaurusWordObject.GetKey());
            _wordStore.Delete(thesaurusWordObject);
        }

        /// <summary>
        /// Gets all stored thesaurusWord objects from data store
        /// </summary>
        /// <returns>thesaurusWord objects</returns>
        public IEnumerable<ThesaurusWord> GetAll()
        {
            return _wordStore.GetAll();
        }

        /// <summary>
        /// Gets the stored thesaurusWord objects from data store matched by identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>thesaurusWord objects</returns>
        public IEnumerable<ThesaurusWord> GetById(long id)
        {
            return _wordStore.GetById(id);
        }

        /// <summary>
        /// Gets the stored thesaurusWord objects from data store matched by word
        /// </summary>
        /// <param name="targetWord">The target word</param>
        /// <returns>thesaurusWord object</returns>
        public ThesaurusWord GetByWord(string targetWord)
        {
            if (targetWord == null)
            {
                return null;
            }

            var cachedThesaurusWordWord = _wordCache[targetWord];

            return cachedThesaurusWordWord ?? _wordStore.GetByWord(targetWord);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="thesaurusWordObject">The thesaurusWord object</param>
        public void Insert(ThesaurusWord thesaurusWordObject)
        {
            _wordCache.Add(thesaurusWordObject.GetKey(), thesaurusWordObject);
            _wordStore.Insert(thesaurusWordObject);
            // _wordStore.Save("thesaurus.json");
        }

        /// <summary>
        /// Loads the data store from the contents of the specified json file
        /// </summary>
        public void Load(string fileName)
        {
            _wordStore.Load(fileName);
        }

        /// <summary>
        /// Saves the data store contents to the specified json file
        /// </summary>
        public void Save(string fileName)
        {
            _wordStore.Save(fileName);
        }

        /// <summary>
        /// Updates the specified thesaurusWord object.
        /// </summary>
        /// <param name="thesaurusWordObject">The thesaurusWord object</param>
        public void Update(ThesaurusWord thesaurusWordObject)
        {
            _wordCache.Add(thesaurusWordObject.GetKey(), thesaurusWordObject);
            _wordStore.Update(thesaurusWordObject);
            // _wordStore.Save("thesaurus.json");
        }
    }
}
