namespace CadastroJogos
{
    class Jogo
    {
        public string titulo;
        public string console;
        public int ano;
        public int ranking;
        public Emprestimo info;
    }

    class Emprestimo
    {
        public string data;
        public string nomePessoa;
        public char emprestado; // 'S' para sim, 'N' para não
    }
}
