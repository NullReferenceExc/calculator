using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Lexer.Tokens
{
    public class ValueToken<T> : Token
    {
        /// <summary>
        /// Значение
        /// </summary>
        public T Value { get; set; }
    }
}
