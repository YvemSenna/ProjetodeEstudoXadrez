using System;
using tabuleiro;
using Xadrez;

namespace Xadrez;
class program
{
    static void Main(string[] args)
    {
        try
        { 
            PartidadeXadrez partida = new PartidadeXadrez();

            while (!partida.terminada)
            {
                Console.Clear();
                Tela.ImprimirTabuleiro(partida.tab);

                Console.WriteLine();
                Console.Write("Origem: ");
                Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                bool[,] PosicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();

                Console.Clear();
                Tela.ImprimirTabuleiro(partida.tab, PosicoesPossiveis);

                Console.WriteLine();
                Console.Write("Destino: ");
                Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                partida.ExecutaMovimento(origem, destino);
            }
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
    }
}

    

