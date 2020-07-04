using System;
using System.Linq;
using System.Xml.Schema;

namespace Regex
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static bool MatchOne(char pattern, char text)
        {
            return pattern == '.' || pattern == text;
        }
        public static bool Match(string pattern, string text)
        {
            if (String.IsNullOrEmpty(pattern))
                return true;
            else if (pattern == "$" && String.IsNullOrEmpty(text))
                return true;
            //else if (String.IsNullOrEmpty(text))             //can't check here as special case a?, a* with empty 
            //    return false;                               //text has to be handled ;pattern but no text
            else if (pattern.Length > 1 && pattern[1] == '?')
                return MatchQuestion(pattern, text);
            else if (pattern.Length > 1 && pattern[1] == '*')
                return MatchStar(pattern, text);
            else
                return !String.IsNullOrEmpty(text) && MatchOne(pattern[0], text[0])
                    && Match(pattern.Substring(1), text.Substring(1));
        }

        public static bool MatchQuestion(string pattern, string text)
        {
            return (!String.IsNullOrEmpty(text) && MatchOne(pattern[0],text[0]) 
                && Match(pattern,text.Substring(1))) || Match(pattern.Substring(2), text);
        }

        public static bool MatchStar(string pattern, string text)
        {
            return (!String.IsNullOrEmpty(text) && MatchOne(pattern[0], text[0])
                && Match(pattern, text.Substring(1))) || Match(pattern.Substring(2), text);
        }
        public static bool Search(string pattern, string text)
        {
            if (String.IsNullOrEmpty(pattern))
                return true;
            else if (String.IsNullOrEmpty(text))
                return Match(pattern, text);
            else if (pattern[0] == '^')
                return Match(pattern.Substring(1), text);
            else
            {
                foreach (char ch in text)
                {
                    if (Match(pattern, text.Substring(text.IndexOf(ch))))
                        return true;
                }
                return false;
            }
        }
    }
}
