using CsLox.ConsoleApp.Enums;

namespace CsLox.ConsoleApp
{
    public class Scanner
    {
        private string source;

        private List<Token> tokens = new List<Token>();
        private static Dictionary<string, TokenType> keywords;

        private int start = 0;
        private int current = 0;
        private int line = 1;

        static Scanner() {
            keywords = new Dictionary<string, TokenType>
            {
                { "and", TokenType.AND },
                { "class", TokenType.CLASS },
                { "else", TokenType.ELSE },
                { "false", TokenType.FALSE },
                { "for", TokenType.FOR },
                { "fun", TokenType.FUN },
                { "if", TokenType.IF },
                { "nil", TokenType.NIL },
                { "or", TokenType.OR },
                { "print", TokenType.PRINT },
                { "return", TokenType.RETURN },
                { "super", TokenType.SUPER },
                { "this", TokenType.THIS },
                { "true", TokenType.TRUE },
                { "var", TokenType.VAR },
                { "while", TokenType.WHILE }
            };

        }

        public Scanner(string source)
        {
            this.source = source;
        }

        public List<Token> ScanTokens()
        {
            while (!IsAtEnd())
            {
                start = current;
                ScanToken();
            }

            tokens.Add(new Token(TokenType.EOF, "", null, line));

            return tokens;
        }

        private bool IsAtEnd()
        {
            return current >= source.Length;
        }

        private void ScanToken()
        {
            char c = Advance();

            switch (c)
            {
                case '(': AddToken(TokenType.LEFT_PAREN); break;
                case ')': AddToken(TokenType.RIGHT_PAREN); break;
                case '{': AddToken(TokenType.LEFT_BRACE); break;
                case '}': AddToken(TokenType.RIGHT_BRACE); break;
                case ',': AddToken(TokenType.COMMA); break;
                case '.': AddToken(TokenType.DOT); break;
                case '-': AddToken(TokenType.MINUS); break;
                case '+': AddToken(TokenType.PLUS); break;
                case ';': AddToken(TokenType.SEMICOLON); break;
                case '*': AddToken(TokenType.STAR); break;

                case '!':
                    AddToken(Match('=') ? TokenType.BANG_EQUAL : TokenType.BANG);
                    break;

                case '=':
                    AddToken(Match('=') ? TokenType.EQUAL_EQUAL : TokenType.EQUAL);
                    break;

                case '<':
                    AddToken(Match('=') ? TokenType.LESS_EQUAL : TokenType.LESS);
                    break;

                case '>':
                    AddToken(Match('=') ? TokenType.GREATER_EQUAL : TokenType.GREATER);
                    break;

                case '/':
                    if (Match('/'))
                    {
                        while (Peek() != '\n' && !IsAtEnd())
                            Advance();
                    }
                    else
                        AddToken(TokenType.SLASH);
                    break;

                case ' ':
                case '\r':
                case '\t':
                    break;

                case '\n':
                    line++;
                    break;

                case '"': AddStringToken(); break;

                case 'o':
                    if (Match('r'))
                        AddToken(TokenType.OR);

                    break;

                default:
                    if (IsDigit(c)) AddNumberToken();

                    else if (IsAlpha(c)) AddIdentifierToken();

                    else
                        CsLox.Error(line, $"Unexpected character '{c}'.");

                    break;
            }
        }

        private char Advance()
        {
            return source.ElementAt(current++);
        }

        private void AddToken(TokenType type)
        {
            AddToken(type, null);
        }

        private void AddToken(TokenType type, object literal)
        {
            string text = source.Substring(start, current - start);

            tokens.Add(new Token(type, text, literal, line));
        }

        private void AddStringToken()
        {
            while (Peek() != '"' && !IsAtEnd())
            {
                if (Peek() == '\n') line++;
                Advance();
            }

            if (IsAtEnd())
            {
                CsLox.Error(line, "Unterminated string.");
                return;
            }

            Advance();

            // Extract string value between quotes... eg: "{value}"
            string value = source.Substring(start + 1, current - start - 1);

            AddToken(TokenType.STRING, value);
        }

        private void AddNumberToken()
        {
            // Parse number tokens
            while (IsDigit(Peek())) Advance();

            // Look for decimal point and keep parsing if true
            if (Peek() == '.' && IsDigit(PeekNext()))
            {
                Advance();

                while (IsDigit(Peek())) Advance();
            }

            AddToken(TokenType.NUMBER, double.Parse(source.Substring(start, current - start)));
        }

        private void AddIdentifierToken()
        {
            while (IsAlphaNumeric(Peek())) Advance();

            string text = source.Substring(start, current - start);

            TokenType type = keywords.GetValueOrDefault(text);

            if (type == default) type = TokenType.IDENTIFIER;

            AddToken(type);
        }

        private bool Match(char expected)
        {
            if (IsAtEnd()) return false;
            if (source.ElementAt(current) != expected) return false;

            current++;
            return true;
        }

        private char Peek()
        {
            // Return null in case line is at an end
            if (IsAtEnd()) return '\0';

            return source.ElementAt(current);
        }

        private char PeekNext()
        {
            if (current + 1 >= source.Length) return '\0';

            return source.ElementAt(current + 1);
        }

        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private bool IsAlpha(char c)
        {
            return
                (c >= 'a' && c <= 'z') ||
                (c >= 'A' && c <= 'Z') ||
                c == '_';
        }

        private bool IsAlphaNumeric(char c)
        {
            return IsAlpha(c) || IsDigit(c);
        }
    }
}
