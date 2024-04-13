﻿using CsLox.ConsoleApp.Enums;
using System;

namespace CsLox.ConsoleApp
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