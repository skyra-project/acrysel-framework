using Acrysel.Parsing;
using NUnit.Framework;

namespace Acrysel.Tests.Parsing
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class PrefixTests
    {
     
        [TestCase("s!", "s!test foo bar")]
        [TestCase("!", "!test foo bar")]
        [TestCase("hElO", "hElOtest boo")]
        [TestCase("smeg", "smegdingdong")]
        [TestCase("hello from the other side", "hello from the other side its good to see you alive")]
        public void Parser_Parses_CorrectSinglePrefix(string prefix, string input)
        {
            // assign
            var parser = new Parser(new[] {prefix}, "", new[] {""}, input);
            
            // act
            parser.Parse();
            
            // assert
            Assert.True(parser.PrefixFound);
            Assert.AreEqual(prefix, parser.PrefixUsed);
        }

        [TestCase("aa", "s!test")]
        [TestCase("OOGA BOOGA", "t!hello there")]
        [TestCase("1", "2 3 4 5, once I caught a fish alive")]
        public void Parser_DoesNotParse_IncorrectSinglePrefix(string prefix, string input)
        {
            // assign
            var parser = new Parser(new[] {prefix}, "", new[] {""}, input);
            
            // act
            parser.Parse();
            
            // assert
            Assert.False(parser.PrefixFound);
        }
    }
}