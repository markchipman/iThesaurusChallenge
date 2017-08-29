using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iThesaurusChallenge.Interfaces;

namespace iThesaurusChallenge
{
    /// <summary>
    /// Thesaurus class
    /// </summary>
    public class Thesaurus : IThesaurus
    {
        /// <summary>
        /// The word repository.
        /// </summary>
        private readonly IThesaurusWordRepository _thesaurusWordCache;

        /// <summary> 
        /// Ctor - Instance of the thesaurus class 
        /// </summary> 
        public Thesaurus()
        {
            _thesaurusWordCache = new ThesaurusWordCache(new ThesaurusDataStore());
        }

        /// <summary>
        /// Adds synonyms to the thesaurus
        /// </summary>
        /// <param name="synonyms">The synonyms</param>
        public void AddSynonyms(IEnumerable<string> synonyms)
        {
            var synonymsList = synonyms?.Where(x => !string.IsNullOrEmpty(x)).ToList() ?? new List<string>();
            foreach (string synonym in synonymsList)
            {
                var thesaurusWord = _thesaurusWordCache.GetByWord(synonym) ?? new ThesaurusWord(synonym);
                thesaurusWord.AddSynonyms(synonymsList);

                _thesaurusWordCache.Insert(thesaurusWord);
            }
        }

        /// <summary>
        /// Returns all of the synonyms for a specified word
        /// </summary>
        /// <param name="thesaurusWord">The thesaurus word upon which to find synonyms</param>
        /// <returns>An IEnumerable<string> of synonyms</returns>
        public IEnumerable<string> GetSynonyms(string thesaurusWord)
        {
            ThesaurusWord targetThesaurusWord = _thesaurusWordCache.GetByWord(thesaurusWord);

            return targetThesaurusWord == null ? Enumerable.Empty<string>() : targetThesaurusWord.GetSynonyms();
        }

        /// <summary>
        /// Returns all words from the thesaurus data store
        /// </summary>
        /// <returns>
        /// An IEnumerable<String> containing all the words in the thesaurus data store</returns>
        public IEnumerable<string> GetWords()
        {
            IEnumerable<ThesaurusWord> words = _thesaurusWordCache.GetAll();

            return words?.Select(x => x.GetKey()).ToList() ?? Enumerable.Empty<string>();
        }
    }
}
