using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace OrchardDNT.ConsoleApp
{
    public class PalindromeConsole
    {
        public static void Main()
        {
            var stringToValidate = "palindrome";
            Console.WriteLine(Palindrome.IsValid(stringToValidate));
        }
    }

    public static class Palindrome
    {
        public static string IsValid(string toCheck)
        {
            if (string.IsNullOrWhiteSpace(toCheck))
                return "UNDETERMINED";

            var cleanedStr = RemoveNonAlphaNumericCharacters(toCheck);

            for (int charIndex = 0; charIndex <= cleanedStr.Length / 2; charIndex++)
            {
                if (!char.ToLower(cleanedStr[charIndex]).Equals(char.ToLower(cleanedStr[cleanedStr.Length - 1 - charIndex])))
                    return "FALSE";
            }
            return "TRUE";
        }

        private static string RemoveNonAlphaNumericCharacters(string toClean)
        {
            Regex regexCharsToKeep = new Regex("[^a-zA-Z0-9+]");
            toClean = regexCharsToKeep.Replace(toClean, string.Empty);
            return toClean;
        }        
    }
}
