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
    public interface IThesuarusWordRepository : IRepository<ThesaurusWord>
    {
        /// <summary>
        /// Gets the theasaurusWord object by targeted word
        /// </summary>
        /// <param name="targetedWord">The targeted word</param>
        /// <returns>ThesaurusWord</returns>
        ThesaurusWord GetByWord(String targetedWord);

        /// <summary>
        /// Saves the data to the specified file
        /// </summary>
        /// <param name="fileName">The file to save data to</param>
        void Save(String fileName);

        /// <summary>
        /// Loads the data from the specified resource file
        /// </summary>
        /// <param name="resourceFileName">The file to load from</param>
        void Load(String resourceFileName);
    }
}
