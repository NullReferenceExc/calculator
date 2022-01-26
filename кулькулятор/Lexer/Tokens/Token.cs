using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Lexer.Tokens
{
    public abstract class Token
    {
        public enum TokenType
        {
            /// <summary>
            /// Простая математическая операция(функции сюда не входят)
            /// </summary>
            Operation,
            /// <summary>
            /// Число
            /// </summary>
            Number
        };
        public TokenType Type;
    }
}
