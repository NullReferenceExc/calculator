namespace Calculator
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            string expr = "2 + 6"; //N:2 OP:ADD N:6 => OP(ADD)[N(2);N(6)]

            List<Lexer.Tokens.Token> tokens = new Lexer.Lexer().Tokenize(expr).ToList();

            foreach (Lexer.Tokens.Token token in tokens)
                Console.WriteLine($"Token(type: {token.Type})");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
//P3 = P2 + P3 | P2 - P3 | P2
//P2 = P1 * P2 | P1 / P2 | P3
//P1 = N | (P3)


//P2 = P3 + P2 | P3 - P2 | P3
//P1 = P2 * P1 | P2 / P1 | P2
//P3 = N

/*
 2 + 2 * 2
 
 */