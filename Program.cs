using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Search search = new Search();
            search.initialize();
            Console.Write("Ask shamz: ");
            string term = Console.ReadLine();
            search.searchTerm(term);

            List<int> listA = search.tokens.wordOccurDictionary["april".GetHashCode()];
            foreach(var a in listA)
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
        }
    }
}
