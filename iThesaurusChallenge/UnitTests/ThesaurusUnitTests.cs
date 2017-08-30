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
        public void AddSynonymsOneAddition()
        {
            var inputList = new List<string> {"C#"};

            _thesaurus.AddSynonyms(inputList);

            var words = _thesaurus.GetWords();
            var synonyms = _thesaurus.GetSynonyms(inputList[0]);

            Assert.Equal(1, words.Count());
            Assert.Equal(0, synonyms.Count());
            Assert.Contains("C#", words);
            Assert.Contains(inputList[0], words.ToList()[0]);
            Assert.Equal(inputList, words); // Order is important
        }

        [Fact]
        public void AddSynonymsMultipleAdditions()
        {
            var inputList = new List<string> {"C#", "C Sharp", "CSharp"};

            _thesaurus.AddSynonyms(inputList);

            var words = _thesaurus.GetWords();

            Assert.True(inputList.Count == words.Count());
            for (int i = 0; i < inputList.Count - 1; i++)
            {
                IEnumerable<string> synonyms = _thesaurus.GetSynonyms(inputList[i]);
                Assert.Equal(inputList.Count - 1, synonyms.Count());
                Assert.Contains(inputList[i], words.ToList()[i]);
            }
            Assert.Equal(inputList, words); // Order is important
        }

        [Fact]
        public void AddSynonymsEmptyListOfStringParameter()
        {
            _thesaurus.AddSynonyms(new List<string>());
            Assert.True(!_thesaurus.GetWords().Any());
        }

        [Fact]
        public void AddSynonymsNullInputParameter()
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
            var inputList1 = new List<string> { "automobile", "car", "buggy", "station wagon" };
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

        [Fact]
        public void GetWordsMultipleAdditions()
        {
            var inputList1 = new List<string> { "automobile", "car", "buggy", "station wagon" };
            var inputList2 = new List<string> { "automobile", "station wagon" };

            _thesaurus.AddSynonyms(inputList1);
            _thesaurus.AddSynonyms(inputList2);
            List<string> words = _thesaurus.GetWords().ToList();

            Assert.Equal(4, words.Count());
            Assert.Contains("automobile", words);
            Assert.Contains("car", words);
            Assert.Contains("buggy", words);
            Assert.Contains("station wagon", words);
        }

        [Fact]
        public void GetWordsNoContentsInThesaurus()
        {
            IEnumerable<string> words = _thesaurus.GetWords();
            Assert.Equal(0, words.Count());
        }

        [Fact]
        public void GetWordsNullInputAdded()
        {
            _thesaurus.AddSynonyms(new List<string> { null });

            IEnumerable<string> words = _thesaurus.GetWords();

            Assert.Equal(0, words.Count());
        }

        [Fact]
        public void GetWordsWhenEmptyStringAdded()
        {
            _thesaurus.AddSynonyms(new List<string> { string.Empty });

            IEnumerable<string> words = _thesaurus.GetWords();

            Assert.Equal(0, words.Count());
        }

        #endregion
    }
}

