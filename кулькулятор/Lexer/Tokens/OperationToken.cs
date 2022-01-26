using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Lexer.Tokens.Operations
{
    public class OperationToken : Token
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
        /// <summary>
        /// Тип операции
        /// </summary>
        private OperationType OpType;
        public OperationToken(OperationType opType)
        {
            OpType = opType;
        }
        public OperationType GetOperationType() =>
            OpType;
    }
}
