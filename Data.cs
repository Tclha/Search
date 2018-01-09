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

        // Create an XML reader for this file.
        public void getAllTheData()
        {
            using (XmlReader reader = XmlReader.Create("simplewiki-latest-pages-articles_1.xml"))
            {
                Console.WriteLine("Loading Data...");
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "page":
                                // Detect this element.
                                break;
                            case "title":
                                // Detect this title element.
                                // Next read will contain text.
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
                    if (count == 100000) { break; }

                    if (idCount == 2) { idCount = 0; }
                }
                Console.WriteLine("Done, {0} <Page> elements loaded", count);
            }
        }
    }
}
