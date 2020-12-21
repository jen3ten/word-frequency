using System;
using System.Collections.Generic;
using System.Text;

namespace word_frequency
{
    public class DataCleaner
    {

        public List<string> TrimListStrings(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Trim();
            }
            return list;
        }

        public List<string> ListItemsToLowerCase(List<string> list)
        {
            throw new NotImplementedException();
        }
    }
}
