﻿using CsLox.ConsoleApp.Domain.Enums;
using System;

namespace CsLox.ConsoleApp.Domain
{
    public class Token
    {
        private TokenType type;
        private string lexeme;
        private object literal;
        private int line;

        public Token(TokenType type, string lexeme, object literal, int line)
        {
            this.type = type;
            this.lexeme = lexeme;
            this.literal = literal;
            this.line = line;
        }

        public override string ToString()
        {
            return $"{type} {lexeme} {literal}";
        }
    }
}
