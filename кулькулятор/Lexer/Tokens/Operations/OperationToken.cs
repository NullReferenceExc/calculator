using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Lexer.Tokens.Operations
{
    public class OperationToken : Token
    {
        /// <summary>
        /// Тип операции
        /// </summary>
        public OperationType OperationType;
    }
}
