using System;
class DesafioJogoDaVelha
{
    static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int jogadorAtual = 1;
    static int escolhaDoUsuario;
    static int verificarJogo;

    static void Main(string[] args)
    {
        bool jogarNovamente = true;

        while (jogarNovamente)
        {
            jogadorAtual = 1;
            tabuleiro = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        do
        {
            Console.Clear();
            Console.WriteLine("Jogador 1: X e Jogador 2: O");
            Console.WriteLine("\n");
            if (jogadorAtual % 2 == 0)
            {
                Console.WriteLine("Turno do Jogador 2");
            }
            else
            {
                Console.WriteLine("Turno do Jogador 1");
            }
            Console.WriteLine("\n");
            Tabuleiro();

            bool escolhaValida = false;
            while (!escolhaValida)
            {
                bool entradaValida = int.TryParse(Console.ReadLine(), out escolhaDoUsuario);
                if (entradaValida && escolhaDoUsuario >= 1 && escolhaDoUsuario <= 9 && tabuleiro[escolhaDoUsuario - 1] != 'X' && tabuleiro[escolhaDoUsuario - 1] != 'O')
                {
                    escolhaValida = true;
                }
                else
                {
                    Console.WriteLine("Jogada inválida. Por favor, escolha uma posição válida.");
                }
            }

            if (jogadorAtual % 2 == 0)
            {
                tabuleiro[escolhaDoUsuario - 1] = 'O';
            }
            else
            {
                tabuleiro[escolhaDoUsuario - 1] = 'X';
            }

            verificarJogo = VerificarVencedor();
            jogadorAtual++;
        }

        while (verificarJogo != 1 && verificarJogo != -1);

        Console.Clear();
        Tabuleiro();

        if (verificarJogo == 1)
        {
            Console.WriteLine("Jogador {0} venceu!", (jogadorAtual % 2) + 1);
        }
        else
        {
            Console.WriteLine("Empate!");
        }

            Console.WriteLine("Deseja jogar novamente? (s/n)");
            char resposta = Console.ReadKey().KeyChar;
            if (resposta != 's')
            {
                jogarNovamente = false;
            }
        }

        Console.WriteLine("Obrigado por jogar!");
    }

    private static void Tabuleiro()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", tabuleiro[0], tabuleiro[1], tabuleiro[2]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", tabuleiro[3], tabuleiro[4], tabuleiro[5]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", tabuleiro[6], tabuleiro[7], tabuleiro[8]);
        Console.WriteLine("     |     |      ");
    }

    private static int VerificarVencedor()
    {
        // Condição de vitória para a primeira linha
        if (tabuleiro[0] == tabuleiro[1] && tabuleiro[1] == tabuleiro[2])
        {
            return 1;
        }
        // Condição de vitória para a segunda linha
        else if (tabuleiro[3] == tabuleiro[4] && tabuleiro[4] == tabuleiro[5])
        {
            return 1;
        }
        // Condição de vitória para a terceira linha
        else if (tabuleiro[6] == tabuleiro[7] && tabuleiro[7] == tabuleiro[8])
        {
            return 1;
        }

        // Condição de vitória para a primeira coluna
        else if (tabuleiro[0] == tabuleiro[3] && tabuleiro[3] == tabuleiro[6])
        {
            return 1;
        }
        // Condição de vitória para a segunda coluna
        else if (tabuleiro[1] == tabuleiro[4] && tabuleiro[4] == tabuleiro[7])
        {
            return 1;
        }
        // Condição de vitória para a terceira coluna
        else if (tabuleiro[2] == tabuleiro[5] && tabuleiro[5] == tabuleiro[8])
        {
            return 1;
        }

        else if (tabuleiro[0] == tabuleiro[4] && tabuleiro[4] == tabuleiro[8])
        {
            return 1;
        }
        else if (tabuleiro[2] == tabuleiro[4] && tabuleiro[4] == tabuleiro[6])
        {
            return 1;
        }

        // Verifica se o jogo deu velha ou não
        else if (tabuleiro[0] != '1' && tabuleiro[1] != '2' && tabuleiro[2] != '3' && tabuleiro[3] != '4' &&
            tabuleiro[4] != '5' && tabuleiro[5] != '6' && tabuleiro[6] != '7' && tabuleiro[7] != '8' &&
            tabuleiro[8] != '9')
        {
            return -1;
        }
        // Se não, continua o jogo
        else
        {
            return 0;
        }
    }
}
