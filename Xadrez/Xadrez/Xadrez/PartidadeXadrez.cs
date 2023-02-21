using System;
using tabuleiro;
using Xadrez;

namespace Xadrez;

class PartidadeXadrez
{
    public Tabuleiro tab { get; private set; }
    public int turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public bool terminada { get; private set; }

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
        terminada = false;
        tab.InserirPeca(p, destino);
    }
    public void RealizaJogada(Posicao origem, Posicao destino)
    {
        ExecutaMovimento(origem, destino);
        turno++;
        MudaJogador();
    }
    public void ValidarPosicaoDeOrigem(Posicao pos)
    {
        if (tab.peca(pos) == null)
        {
            throw new TabuleiroException("Não Existe Peça na Posição de Origem Escolhida!");
        }
        if (JogadorAtual != tab.peca(pos).cor)
        {
            throw new TabuleiroException("A peca de origem Escilhoda não é sua!");
        }
        if (!tab.peca(pos).ExisteMovimentosPossiveis())
        {
            throw new TabuleiroException("Não há Movimentos Possíveis para a peça de origem!");
        }
    }
    public void ValidarPosicaodestino(Posicao origem, Posicao destino)
    {
        if (!tab.peca(origem).PodeMoverPara(destino)) 
        {
            throw new TabuleiroException("Posição de destino Inválida");
        }
    }
    public void MudaJogador()
    {
        if (JogadorAtual == Cor.Branca)
        {
            JogadorAtual = Cor.Preta;
        }
        else
        {
            JogadorAtual = Cor.Branca;
        }
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

