namespace Calculator
{
    public partial class Form1 : Form
    {
        Lexer.Lexer lexer = new Lexer.Lexer();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Lines = Array.Empty<string>();
            foreach (var token in lexer.Tokenize(textBox1.Text))
                textBox2.Lines = textBox2.Lines.Append($"Token(type: {token.Type})").ToArray();
        }
    }
}