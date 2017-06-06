using NUnit.Framework;
using FluentAssertions;

namespace OrchardDNT.ConsoleApp.Tests
{
    [TestFixture]
    public class PalindromeTest
    {
        [TestCase("malayalam", "TRUE")]
        [TestCase("palindrome", "FALSE")]
        [TestCase("", "UNDETERMINED")]
        [TestCase("Kayak", "TRUE")]
        [TestCase("No lemon, no melon", "TRUE")]
        public void CheckPalindrome_Should_Return_AsExpected(string input, string result)
        {
            Palindrome.IsValid(input).ShouldBeEquivalentTo(result);
        }

        [TestCase("uncopyrightable", "HETEROGRAM")]
        [TestCase("Caucasus", "ISOGRAM")]
        [TestCase("authorising", "NOTAGRAM")]
        public void CheckInstagram_Should_Return_AsExpected(string input, string result)
        {
            Instagram.IsInstagram(input).ShouldBeEquivalentTo(result);
        }
    }
}
