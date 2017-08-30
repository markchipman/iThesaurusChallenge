using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using iThesaurusChallenge;

namespace UnitTests
{
    /// <summary>
    /// ThesaurusTest class
    /// </summary>
    public class ThesaurusUnitTests
    {
        /// <summary>
        /// Reusable thesaurus instance
        /// </summary>
        private readonly Thesaurus _thesaurus = new Thesaurus();

        [Fact]
        public void VerifyInstance()
        {  
            Assert.IsType<Thesaurus>(_thesaurus);
        }

        #region AddSynonyms

        [Fact]
        public void AddSynonym()
        {
            var inputList = new List<string> { "C#", "C Sharp", "CSharp" };

            _thesaurus.AddSynonyms(inputList);

            var words = _thesaurus.GetWords();

            Assert.True(inputList.Count == words.Count());
            for (int i = 0; i < inputList.Count-1; i++)
            {
                IEnumerable<string> synonyms = _thesaurus.GetSynonyms(inputList[i]);
                Assert.Equal(inputList.Count-1, synonyms.Count());
                Assert.Contains(inputList[i], words.ToList()[i]);
            }
        }

        #endregion

        #region GetSynonyms


        #endregion


        #region GetWords 


        #endregion
    }
}

