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
        public Dictionary<int, List<int>> multiWordDictionary = new Dictionary<int, List<int>>();

        public void initialize()
        {
            tokens.tokenize2();
        }
        
        /*public void searchTerm(string singleValue)------OLD SEARCH FUNCTION FOR SINGLE VALUES----------
        {
            int count = 1;
            if (tokens.wordOccurDictionary.ContainsKey(singleValue.GetHashCode())){
                Dictionary<int, List<int>> searchDict = tokens.wordOccurDictionary[singleValue.GetHashCode()];
                Dictionary<int, int> numOfOccur = new Dictionary<int, int>();
                List<int> sortedIntValue = new List<int>();
                foreach (KeyValuePair<int, List<int>> entry in searchDict)
                {
                    numOfOccur.Add(entry.Key, entry.Value.Count()); 
                    sortedIntValue.Add(entry.Value.Count());
                }
                var orderedDictionary = numOfOccur.OrderByDescending(pair => pair.Value);
                foreach (KeyValuePair<int, int> entry in orderedDictionary)
                {
                    Console.WriteLine("\n ============== \n");
                    Console.WriteLine("Rank: {0}, Title: {1}", count, tokens.XMLdata.titles[entry.Key]);
                    Console.WriteLine("Rank: {0}, Title: {1}", count, tokens.XMLdata.texts[entry.Key]);

                    count++;
                }
            }
            else
            {
                Console.WriteLine("This term doesn't appear to be in the dictionary... Try Again");
            }
        }*/
        public void multiWord(List<string> multipleWords)
        {
            int count = 1;
            foreach (var word in multipleWords)
            {
                if (tokens.wordOccurDictionary.ContainsKey(word.GetHashCode()))
                {
                    Dictionary<int, List<int>> tokenDict = tokens.wordOccurDictionary[word.GetHashCode()];
                    foreach (KeyValuePair<int, List<int>> entry in tokenDict)
                    {
                        foreach (var id in entry.Value)
                        {
                            AddtoDict(entry.Key, id);
                        }
                    }

                }
                Dictionary<int, int> numOfOccur = new Dictionary<int, int>();
                foreach (KeyValuePair<int, List<int>> entry in multiWordDictionary)
                {
                    numOfOccur.Add(entry.Key, entry.Value.Count());
                }
                var orderedDictionary = numOfOccur.OrderByDescending(pair => pair.Value);
                foreach (KeyValuePair<int, int> entry in orderedDictionary)
                {
                    Console.WriteLine("\n ============== \n");
                    Console.WriteLine("Rank: {0}, Title: {1}", count, tokens.XMLdata.titles[entry.Key]);
                    count++;
                    if(count > 50) { break; }
                }
            }
            multiWordDictionary.Clear();
        }

        public void AddtoDict(int key, int value)
        {
            if (this.multiWordDictionary.ContainsKey(key))
            {
                List<int> list = this.multiWordDictionary[key];
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
            else
            {
                List<int> list = new List<int>();
                list.Add(value);
                this.multiWordDictionary.Add(key, list);
            }
        }
    }
}

