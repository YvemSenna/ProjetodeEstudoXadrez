using System;
using tabuleiro;
using Xadrez;


namespace tabuleiro;

 class Tela
 {
    public static void ImprimirTabuleiro(Tabuleiro tab)
    {
        for(int i=0; i<tab.linhas; i++) 
        {
            Console.Write(8 - i + " ");

            for(int j=0; j<tab.colunas; j++)
            {
                ImprimirPeca(tab.peca(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  A B C D E F G H ");
    }
    public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] PosicoesPossiveis)
    {
        ConsoleColor FundoOriginal = Console.BackgroundColor;
        ConsoleColor FundoAlterado = ConsoleColor.DarkGray;

        for (int i = 0; i < tab.linhas; i++)
        {
            Console.Write(8 - i + " ");

            for (int j = 0; j < tab.colunas; j++)
            {
                if (PosicoesPossiveis[i, j])
                {
                    Console.BackgroundColor = FundoAlterado;
                }
                else
                {
                    Console.BackgroundColor = FundoOriginal;
                }
                ImprimirPeca(tab.peca(i, j));
                Console.BackgroundColor = FundoOriginal;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  A B C D E F G H ");
        Console.BackgroundColor = FundoOriginal;
    }
    public static PosicaoXadrez LerPosicaoXadrez()
    {
        string s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");
        return new PosicaoXadrez(coluna, linha);
    }
    public static void ImprimirPeca(Peca peca) 
    {
        if (peca == null ) 
        {
            Console.Write("- ");
        }
        else
        {
             if (peca.cor == Cor.Branca)
             {
                Console.Write(peca);
             }
             else
             {
                 ConsoleColor aux = Console.ForegroundColor;
                 Console.ForegroundColor = ConsoleColor.Yellow;
                 Console.Write(peca);
                 Console.ForegroundColor = aux;
             }
            Console.Write(" ");
        }
    }
 }
