using System;
using tabuleiro;
using Xadrez;

namespace Xadrez;
class program
{
    static void Main(string[] args)
    {
        Tabuleiro tab = new Tabuleiro(8, 8);

        tab.InserirPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
        tab.InserirPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
        tab.InserirPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

        Tela.ImprimirTabuleiro(tab);
    }
}

    

