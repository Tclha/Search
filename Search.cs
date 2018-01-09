using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineProject
{
    class Search
    {
        public Tokens tokens = new Tokens();

        public void initialize()
        {
            tokens.tokenize();
        }

        public void searchTerm(string singleValue)
        {
            int wordHash = singleValue.GetHashCode();
            int count = 0;
            if (tokens.wordOccurDictionary.ContainsKey(singleValue.GetHashCode()))
            {
                List<int> listInt = tokens.wordOccurDictionary[singleValue.GetHashCode()];
                foreach (var i in listInt)
                {
                    Console.WriteLine("\n"+ count);
                    Console.WriteLine(tokens.XMLdata.titles[i]);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("This term doesn't appear to be in the dictionary... Try Again");
            }
        }
    }
}
