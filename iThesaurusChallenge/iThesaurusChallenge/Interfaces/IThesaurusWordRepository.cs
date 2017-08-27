using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iThesaurusChallenge.Interfaces
{
    /// <summary>
    /// ThesaurusWord Repository
    /// </summary>
    /// <seealso cref="ThesaurusWord" />
    interface IWordRepository : IRepository<ThesaurusWord>
    {
        /// <summary>
        /// Gets the theasaurusWord object by targeted word.
        /// </summary>
        /// <param name="targetedWord">The word.</param>
        /// <returns>ThesaurusWord</returns>
        ThesaurusWord GetByWord(String targetedWord);
    }
}
