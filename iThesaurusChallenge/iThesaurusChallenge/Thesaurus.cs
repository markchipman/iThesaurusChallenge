using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iThesaurusChallenge.Interfaces;

namespace iThesaurusChallenge
{
    public class Thesaurus : IThesaurus
    {
        public void AddSynonyms(IEnumerable<string> synonyms)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetSynonyms(string word)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetWords()
        {
            throw new NotImplementedException();
        }
    }
}
