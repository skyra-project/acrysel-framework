using Acrysel.Parsing;
using NUnit.Framework;

namespace Acrysel.Tests.Parsing.Internal
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class InternalTests
    {
        private const string InputString = "!test --option=a hello 1";

        [TestCase(8, 6, "option")]
        [TestCase(0, 5, "!test")]
        [TestCase(17, 5, "hello")]
        [TestCase(17, 7, "hello 1")]
        public void Parser_Peek_ReturnsCorrectSlice(int ahead, int amount, string expectedSlice)
        {
            // assign
            var parser = new Parser(new[] {"!"}, " ",new string[] { "--", "-", "—" }, InputString);
            
            // act
            var slice = parser.Peek(ahead, amount);
            
            // assert
            Assert.AreEqual(expectedSlice, slice);

        }

        [TestCase(2, 'e')]
        [TestCase(7, '-')]
        [TestCase(1, 't')]
        [TestCase(0, '!')]
        public void Parser_Consume_ReturnsCorrectChar(int ahead, char expectedValue)
        {
            // assign
            var parser = new Parser(new[] {"!"}, " ",new string[] { "--", "-", "—" }, InputString);
            
            // act
            var token = parser.Consume(ahead);
            
            // assert
            Assert.AreEqual(expectedValue, token);
        }
        
        [TestCase(2, "e")]
        [TestCase(7, "-")]
        [TestCase(1, "t")]
        [TestCase(0, "!")]
        public void Parser_Consume_MovesHeadCorrectly(int ahead, string expectedValue)
        {
            // assign
            var parser = new Parser(new[] {"!"}, " ",new string[] { "--", "-", "—" }, InputString);
            
            // act
            var _ = parser.Consume(ahead);
            var token = parser.Peek();
            
            // assert
            Assert.AreEqual(expectedValue, token);
        }
    }
}