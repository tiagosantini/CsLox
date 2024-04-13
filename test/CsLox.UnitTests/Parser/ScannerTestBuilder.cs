using CsLox.Domain.Enums;
using CsLox.Domain.Parser;

namespace CsLox.UnitTests.Parser
{
    public class ScannerTestBuilder
    {
        private readonly Scanner scanner;
        private readonly List<Token> tokens;
        private int currentTokenIndex = 0;

        public ScannerTestBuilder(string source)
        {
            scanner = new Scanner(source);
            tokens = scanner.ScanTokens();
        }

        public ScannerTestBuilder Has(TokenType expectedType, string expectedLexeme)
        {
            if (currentTokenIndex >= tokens.Count)
            {
                throw new Exception("No more tokens available for assertion.");
            }

            var token = tokens[currentTokenIndex++];
            Assert.AreEqual(expectedType, token.Type, $"Expected token type {expectedType} but got {token.Type}.");
            Assert.AreEqual(expectedLexeme, token.Lexeme, $"Expected lexeme '{expectedLexeme}' but got '{token.Lexeme}'.");

            return this;
        }

        public ScannerTestBuilder HasEOF()
        {
            return Has(TokenType.EOF, "");
        }

        public void End()
        {
            if (currentTokenIndex != tokens.Count)
            {
                throw new Exception("Not all tokens were asserted.");
            }
        }
    }
}
