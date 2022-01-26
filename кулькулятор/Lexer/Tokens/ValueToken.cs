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
        private T Value;
        public ValueToken(T value)
        {
            Value = value;
        }
        public T GetValue() =>
            Value;
    }
}
