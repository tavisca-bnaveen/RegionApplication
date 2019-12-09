using System;
using System.Collections.Generic;
using System.IO;

namespace RegionApplication
{
    public class FileOperation
    {
        public List<string> ReadLines(string path)
        {
            var unParsedStrings = new List<string>();
            try
            {
                using (StreamReader file = new StreamReader(path))
                {

                    string location;

                    while ((location = file.ReadLine()) != null)
                    {
                        unParsedStrings.Add(location);
                    }
                    file.Close();

                    
                }
                return unParsedStrings;
            }
            catch(Exception)
            {
                throw new FileNotFoundException("FileNotFound");
            }

        }
    }
}
