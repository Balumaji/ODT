using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OrchardDNT.ConsoleApp
{
    public class InstagramConsole
    {
        public static void Main()
        {
            var stringToValidate = "instagram";
            Console.WriteLine(Instagram.IsInstagram(stringToValidate));
        }
    }

    public static class Instagram
    {
        public static string IsInstagram(string toCheck)
        {
            var cleanedStr = RemoveNonAlphaNumericCharacters(toCheck);

            if (IsHeterogram(cleanedStr))
                return "HETEROGRAM";

            if (IsIsogram(cleanedStr))
                return "ISOGRAM";

            return "NOTAGRAM";
        }

        private static string RemoveNonAlphaNumericCharacters(string toClean)
        {
            Regex regexCharsToKeep = new Regex("[^a-zA-Z0-9+]");
            toClean = regexCharsToKeep.Replace(toClean, string.Empty);
            return toClean;
        }        

        private static bool IsHeterogram(string toCheck)
        {
            var g = toCheck.ToLower().ToCharArray().GroupBy(c => c, (character, occurence) => new { Character = character, NumberOfOccurences = occurence.Count() });

            var distinctOccurences = g.Select(gc => gc.NumberOfOccurences).Distinct().OrderByDescending(i => i);

            return distinctOccurences.First().Equals(1) && distinctOccurences.Count().Equals(1) ? true : false;
        }

        private static bool IsIsogram(string toCheck)
        {
            var g = toCheck.ToLower().ToCharArray().GroupBy(c => c, (character, occurence) => new { Character = character, NumberOfOccurences = occurence.Count() });

            var distinctOccurences = g.Select(gc => gc.NumberOfOccurences).Distinct().OrderByDescending(i => i);

            return !distinctOccurences.First().Equals(1) && distinctOccurences.Count().Equals(1) ? true : false;
        }
    }
}
