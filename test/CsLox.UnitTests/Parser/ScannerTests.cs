using CsLox.Domain.Enums;
using CsLox.Domain.Parser;

namespace CsLox.UnitTests.Parser
{
    [TestClass]
    public class ScannerTests
    {
        //[TestInitialize]
        //public void Setup()
        //{
        //}

        [TestMethod]
        public void TestScanner_TokenizesVariablesCorrectly()
        {
            new ScannerTestBuilder("var x = 100;")
                .Has(TokenType.VAR, "var")
                .Has(TokenType.IDENTIFIER, "x")
                .Has(TokenType.EQUAL, "=")
                .Has(TokenType.NUMBER, "100")
                .Has(TokenType.SEMICOLON, ";")
                .HasEOF()
                .End();
        }
    }
}