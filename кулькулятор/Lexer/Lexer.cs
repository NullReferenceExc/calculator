using Calculator.Lexer.Tokens;
using Calculator.Lexer.Tokens.Operations;
using System.Text.RegularExpressions;
using static Calculator.Lexer.Tokens.Operations.OperationToken;
using static Calculator.Lexer.Tokens.Token;

namespace Calculator.Lexer
{
    class Lexer
    {
        // Приватный словарь строка операции - тип операции. Используется для парсинга операций и генерации регулярки для парсинга операций
        private static Dictionary<string, OperationType> OpTypes =
            new Dictionary<string, OperationType>()
            {
                [@"+"] = OperationType.Add,
                [@"-"] = OperationType.Subtract,
                [@"*"] = OperationType.Multiply,
                [@"/"] = OperationType.Divide
            };

        // Регулярки, описывающие лексему
        private static Dictionary<TokenType, Regex> regexes = 
            new Dictionary<TokenType, Regex>()
            {
                //Регулярка генерируется исходя из токенов расположенных в словаре OpTypes. Не трогать
                [TokenType.Operation] = new Regex(string.Concat("^(", string.Join('|', OpTypes.Keys.Select((elem, index) => $@"({Regex.Escape(elem)})")), ")")),

                [TokenType.Number] = new Regex(@"^(\-)?[0-9]+(\.[0-9]+)?", RegexOptions.Compiled)
            };

        //Функции, вызываемые при обнаружении токена
        private static Dictionary<TokenType, Func<string, Token>> creators =
            new Dictionary<TokenType, Func<string, Token>>()
            {
                [TokenType.Operation] = (s) => new OperationToken(OpTypes[s]) { Type = TokenType.Operation },

                [TokenType.Number] = (s) =>
                    s.Contains(".") ?
                        new ValueToken<double>(double.Parse(s.Replace('.', ','))) { Type = TokenType.Number }
                      : new ValueToken<int>(int.Parse(s)) { Type = TokenType.Number}
                
            };

        /// <summary>
        /// Метод, парсящий строку на лексемы
        /// </summary>
        /// <param name="text">Текст который необходимо парсить</param>
        /// <returns>Энумерация лексем</returns>
        /// <exception cref="Exception">Исключение выкидывается в случаее если не обнаруженна подходящая лексема</exception>
        public IEnumerable<Token> Tokenize(string text)
        {
            //Убирает пробелы в тексте
            var remainingText = text.TrimStart();
            while (remainingText != "")
            {
                //Находим наиболее подходящий паттерн:
                var bestMatch =
                   (from pair in regexes
                    let tokenType = pair.Key
                    let regex = pair.Value
                    let match = regex.Match(remainingText)
                    let matchLen = match.Length
                    //Упорядочиваем по длине, а если длина одинаковая - по типу токена
                    orderby matchLen descending, tokenType
                    select new { tokenType, text = match.Value, matchLen }).First();

                // если везде только 0, ошибка
                if (bestMatch.matchLen == 0)
                    throw new Exception("Unknown lexeme");

                var token = creators[bestMatch.tokenType].Invoke(bestMatch.text);

                yield return token;

                // откусываем распознанный кусок и пробелы после него
                remainingText = remainingText.Substring(bestMatch.matchLen).TrimStart();
            }
        }
    }
}

/*
 E -> T + E | T - E | T
 T -> F * T | F / T | F
 F -> N     | (E)


 2 + 3 * ( 4 - 5 ) + 6 - 7
 f(
  f(
   t(2) + t(
    f(3) * f(
     e(
      f(4) - f(5)
       )))) 
        + f(6)
         ) - f(7)
 f(f(t(2) + t(f(3) + f(-1))) + f(6)) - f(7)
 f(f(t(2) + f(2)) + f(6)) - f(7)
 f(f(4) + f(6)) - f(7)
 f(10) - f(7)
 -2

  2 + 2 * 2
  e(
   f(2) +
   t(f(2) * f(2))

 */