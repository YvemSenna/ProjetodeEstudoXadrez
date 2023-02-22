using System;
using tabuleiro;
using Xadrez;
using System.Collections.Generic;


namespace tabuleiro;

 class Tela
 {
    public static void ImprimirPartida(PartidadeXadrez partida)
    {
        ImprimirTabuleiro(partida.tab);
        Console.WriteLine();
        ImprimirPecasCapturadas(partida);
        Console.WriteLine();
        Console.WriteLine("Turno: " + partida.turno);
        if (!partida.terminada)
        {
            Console.WriteLine("Aguardando: " + partida.JogadorAtual);
            if (partida.xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }
        else 
        {
            Console.WriteLine("XEQUEMATE!");
            Console.WriteLine("vencedor: " + partida.JogadorAtual);
        }
    }
    public static void ImprimirPecasCapturadas(PartidadeXadrez partida)
    {
        Console.WriteLine("Pecas Capturadas: ");
        Console.Write("Brancas: ");
        ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
        Console.WriteLine();
        Console.Write("Pretas: ");
        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
        Console.ForegroundColor = aux;
        Console.WriteLine();
    }
    public static void ImprimirConjunto(HashSet <Peca> conjunto)
    {
        Console.Write("[");
        foreach (Peca x in conjunto)
        {
            Console.Write(x + " ");
        }
        Console.Write("]");
    }
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
