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
            Assert.Equal(inputList, words); // Order is important
        }

        [Fact]
        public void AddEmpty()
        {
            _thesaurus.AddSynonyms(new List<string>());
            Assert.True(!_thesaurus.GetWords().Any());
        }

        [Fact]
        public void AddNull()
        {
            _thesaurus.AddSynonyms(null);
            Assert.True(!_thesaurus.GetWords().Any());
        }

        #endregion

        #region GetSynonyms

        [Fact]
        public void GetSynonymsSingleWord()
        {
            var inputList = new List<string> { "automobile" };

            _thesaurus.AddSynonyms(inputList);
            IEnumerable<string> synonyms = _thesaurus.GetSynonyms(inputList[0]);
            Assert.Equal(0, synonyms.Count());
            Assert.IsAssignableFrom<IEnumerable<string>>(synonyms);
        }

        [Fact]
        public void GetSynonymsMultipleAdditions()
        {
            var inputList1 = new List<string> { "automobile", "car", "buggy", "station wagon"};
            var inputList2 = new List<string> { "automobile", "station wagon" };

            _thesaurus.AddSynonyms(inputList1);
            _thesaurus.AddSynonyms(inputList2);
            List<string> synonyms = _thesaurus.GetSynonyms("station wagon").ToList();

            Assert.Equal(3, synonyms.Count());
            Assert.Contains("automobile", synonyms);
            Assert.Contains("car", synonyms);
            Assert.Contains("buggy", synonyms);
        }

        [Fact]
        public void GetSynonymsEmptyStringInput()
        {
            IEnumerable<string> synonyms = _thesaurus.GetSynonyms(string.Empty);
            Assert.Equal(0, synonyms.Count());
        }

        [Fact]
        public void GetSynonymsNullInput()
        {
            IEnumerable<string> synonyms = _thesaurus.GetSynonyms(null);
            Assert.Equal(0, synonyms.Count());
        }

        #endregion


        #region GetWords 


        #endregion
    }
}

