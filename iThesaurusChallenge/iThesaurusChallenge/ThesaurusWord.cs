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
        /// Current name
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// List of synonym
        /// </summary>
        private List<string> _synonymsList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThesaurusWord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ThesaurusWord(string name)
        {
            _name = name;
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
        public string GetName()
        {
            return _name;
        }

        /// <summary>
        /// Adds a new synonym to the synonyms list
        /// </summary>
        /// <param name="synonyms">The synonyms list</param>
        public void AddSynonyms(IEnumerable<string> synonyms)
        {

        }

        #endregion
    }
}
