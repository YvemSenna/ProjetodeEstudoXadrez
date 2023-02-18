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
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.InserirPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.InserirPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
            tab.InserirPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));
            tab.InserirPeca(new Torre(tab, Cor.Branca), new Posicao(3, 5));

            Tela.ImprimirTabuleiro(tab);
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.Message);
        }
    }
}

    

