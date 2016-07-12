using System;
using System.Collections.Generic;
using Core.Lexicon;
using NUnit.Framework;

namespace Tests.CoreTests
{
    internal class LexerTests
    {
        [TestCaseSource(typeof(TestsData.Core.Lexer.TokenProduction), "Data")]
        public void Lexer_can_produce_tokens(string input, IList<AbstractToken> expectedTokens)
        {
            var lexer = new Lexer(input);

            var tokens = new List<AbstractToken>();
            while (lexer.GetNextToken() != null)
            {
                tokens.Add(lexer.CurrentToken);
            }

            Assert.That(tokens, Is.EquivalentTo(expectedTokens));
        }

        [TestCaseSource(typeof(TestsData.Core.Lexer.ExceptionOnInvalidInput), "Data")]
        public void Lexer_throws_exception_if_the_input_is_not_valid(string input)
        {
            Action action = () =>
            {
                var lexer = new Lexer(input);
                while (lexer.GetNextToken() != null)
                {
                }
            };

            TestDelegate testDelegate = new TestDelegate(action);

            Assert.That(testDelegate, Throws.InstanceOf<UnknownTokenException>());
        }
    }
}
