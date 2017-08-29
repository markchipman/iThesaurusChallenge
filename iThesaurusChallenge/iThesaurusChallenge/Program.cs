using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace iThesaurusChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            var thesaurus = new Thesaurus();

            var wordsList = new List<string> {"automobile", "car", "vehicle"};
            Console.WriteLine("Select on of the following options: ");
            Console.WriteLine("a.) Add as synonyms ==> automobile car vehicle");
            Console.WriteLine("b.) Get synonyms for car");
            Console.WriteLine("c.) Get all words in the thesaurus");
            Console.WriteLine("esc ==> exit");
            do
            {
                cki = Console.ReadKey();
                switch (cki.Key.ToString().ToLower())
                {
                    case "a":
                        thesaurus.AddSynonyms(wordsList);
                        if (!thesaurus.GetSynonyms("automobile").Any() || !thesaurus.GetSynonyms("car").Any() || !thesaurus.GetSynonyms("vehicle").Any())
                        {
                            Console.WriteLine(" ... the thesaurus doesn't have any synonyms for automobile, car or vehicle");
                        }
                        else
                        {
                            Console.WriteLine(
                                " was selected... The following words were added as synonyms for one another : " + string.Join(", ", wordsList));
                        }

                        break;
                    case "b":
                        var synonyms = thesaurus.GetSynonyms("car");
                        Console.WriteLine(" was selected... The following words are words that are synonyms for car : " + string.Join(", ", synonyms).ToLower());
                        break;
                    case "c":
                        var allThesaurusWords = thesaurus.GetWords();
                        Console.WriteLine(" was selected... The following words are contained in the thesaurus : " + string.Join(", ", allThesaurusWords));
                        break;
                    default:
                        Console.WriteLine("You must enter a,b,c or use the escape key");
                        break;
                }

            } while (cki.Key != ConsoleKey.Escape);

        }


    }
}

