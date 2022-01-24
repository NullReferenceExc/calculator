using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Lexer.Tokens.Operations
{
    public enum OperationType
    {
        /// <summary>
        /// Сложение
        /// </summary>
        Add,
        /// <summary>
        /// Вычитание
        /// </summary>
        Subtract,
        /// <summary>
        /// Умножение
        /// </summary>
        Multiply,
        /// <summary>
        /// Деление
        /// </summary>
        Divide
    };
}
