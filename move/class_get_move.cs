using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace move
{
   class class_get_move
    {
        public string GetStringBetween(string token, string first, string second)
        {
            if (!token.Contains(first)) return "";

            var afterFirst = token.Split(new[] { first }, StringSplitOptions.None)[1];

            if (!afterFirst.Contains(second)) return "";

            var result = afterFirst.Split(new[] { second }, StringSplitOptions.None)[0];

            return result;
        }

      public List <string> List_file_move (string token, string first, string second)
        {
            List<string> all = new List<string> ();
            while (true)
            {
                string str = GetStringBetween(token, first, second);
                if (!String.IsNullOrEmpty(str))
                {
                    all.Add(str);
                    str = first + str + second;
                    token = token.Replace(str, "");

                }else
                {
                    break;
                }
            }
            return all;
        }


    }
}
