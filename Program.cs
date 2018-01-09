using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchEngineProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordRx = @"\w+";
            Search search = new Search();
            search.initialize();
            string term = "o";
            while (term != "")
            {
                Console.Write("Ask shamz: ");
                term = Console.ReadLine();
                Match match = Regex.Match(term, wordRx, RegexOptions.IgnoreCase);
                List<string> searchTerms = new List<string>();
                while (match.Success)
                {
                    searchTerms.Add(match.Value);
                    match = match.NextMatch();
                }
                search.multiWord(searchTerms);
            }

            Console.ReadKey();
        }
    }
}
