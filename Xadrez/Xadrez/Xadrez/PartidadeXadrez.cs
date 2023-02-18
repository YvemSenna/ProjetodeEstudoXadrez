using System;
using tabuleiro;
using Xadrez;

namespace Xadrez;

class PartidadeXadrez
{
    public Tabuleiro tab { get; private set; }
    private int turno;
    private Cor JogadorAtual;

    public PartidadeXadrez()
    {
        tab = new Tabuleiro(8, 8);
        turno = 1;
        InserirPecas();
    }
    public void ExecutaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = tab.RetirarPeca(origem);
        p.IncrementarQteMovimentos();
        Peca PecaCapturada = tab.RetirarPeca(destino);
        tab.InserirPeca(p, destino);
    }
    private void InserirPecas()
    {
        tab.InserirPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
        tab.InserirPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
        tab.InserirPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
        tab.InserirPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
        tab.InserirPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
        tab.InserirPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());

        tab.InserirPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
        tab.InserirPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
        tab.InserirPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
        tab.InserirPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
        tab.InserirPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
        tab.InserirPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
    }
}

