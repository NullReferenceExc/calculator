using Calculator.Lexer.Tokens;
using Calculator.Lexer.Tokens.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calculator.Parser
{
    internal class Parser
    {
        public abstract class Node
        {

        }
    }
}

//2 + 2 + 2
/*
 Ищет * или /
 Ищет + или -
  OpNode {2, 2, +} + 2
  OpNode { OpNode {2, 2, + }, 2, +}
 */