using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SearchEngineProject
{
    class Data
    {
        public List<string> titles = new List<string>();
        public List<int> ids = new List<int>();
        public List<string> texts = new List<string>();
        public List<int> parentIds = new List<int>();

        public int count = 0;
        public int idCount = 3;

        // Create an XML reader
        public void getAllTheData()
        {
            using (XmlReader reader = XmlReader.Create("simplewiki-latest-pages-articles_1.xml"))//get file
            {
                Console.WriteLine("Loading Data...");
                while (reader.Read())//read is a built in fucntion of reader
                {
                    // only detect start elements.
                    if (reader.IsStartElement())
                    {
                        //get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "page":
                                break;
                            case "title":
                                if (reader.Read())
                                {
                                    this.titles.Add(reader.Value.Trim());
                                }
                                break;
                            case "id":
                                if ((idCount % 3 == 0)) //main id
                                {
                                    if (reader.Read())
                                    {
                                        this.ids.Add(Int32.Parse(reader.Value.Trim()));
                                    }
                                    idCount++;
                                    break;
                                }
                                else
                                {
                                    idCount++;
                                    break;
                                }
                            case "parentid":
                                if (reader.Read())
                                {
                                    this.parentIds.Add(Int32.Parse(reader.Value.Trim()));
                                }
                                break;
                            case "text":
                                if (reader.Read())
                                {
                                    this.texts.Add(reader.Value.ToLower());
                                    count++;
                                }
                                break;
                        }
                    }
                if (count == 1000) { break; }

                    if (idCount == 2) { idCount = 0; }
                }
                Console.WriteLine("Done, {0} <Page> elements loaded", count);
            }
        }
    }
}
