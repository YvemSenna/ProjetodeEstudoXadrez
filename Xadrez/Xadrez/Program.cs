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
            Tela.ImprimirTabuleiro(partida.tab);
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
    }
}

    

