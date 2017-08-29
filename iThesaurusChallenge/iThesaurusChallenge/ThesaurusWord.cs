using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iThesaurusChallenge
{
    /// <summary>
    /// Word used in lookup
    /// </summary>
    public class ThesaurusWord
    {

        /// <summary>
        /// Key
        /// </summary>
        private readonly string _key;

        /// <summary>
        /// List of synonym
        /// </summary>
        private List<string> _synonymsList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThesaurusWord"/> class.
        /// </summary>
        /// <param name="word">The name.</param>
        public ThesaurusWord(string word)
        {
            _key = word;
            _synonymsList = new List<string>();
        }

        #region methods
        /// <summary>
        /// Gets the synonyms list
        /// </summary>
        /// <returns>Synonyms</returns>
        public IEnumerable<string> GetSynonyms()
        {
            return _synonymsList;
        }


        /// <summary>
        /// Gets the name
        /// </summary>
        /// <returns>Name</returns>
        public string GetKey()
        {
            return _key;
        }

        /// <summary>
        /// Adds a new synonym to the synonyms list
        /// </summary>
        /// <param name="synonyms">The synonyms list</param>
        public void AddSynonyms(IEnumerable<string> synonyms)
        {
            if (synonyms == null) return;

            // NOTE: This didn't work afterall :(
            // _synonymsList.Clear(); // make sure that the synonym list is reset

            // var candidateWordList = synonyms as IList<string> ?? synonyms.ToList();
            // foreach (var word in candidateWordList)
            // {
            //    if (!candidateWordList.Contains(word) && word != _key)
            //    {
            //        _synonymsList.Add(word);
            //    }
            // }

            // after some googling, i found a workable solution using linq -- see: https://www.dotnetperls.com/union - Union removes duplicates... it combines the two collections and then uses Distinct() on them, removing duplicate elements.
            var synonymListWithoutName = synonyms.Where(x => x != _key);
            _synonymsList = _synonymsList.Union(synonymListWithoutName).ToList();
        }

        #endregion
    }
}
