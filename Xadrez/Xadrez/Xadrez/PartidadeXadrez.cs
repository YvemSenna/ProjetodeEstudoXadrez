using System;
using System.Collections.Generic;
using tabuleiro;
using Xadrez;

namespace Xadrez;

class PartidadeXadrez
{
    public Tabuleiro tab { get; private set; }
    public int turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
    public bool terminada { get; private set; }

    private HashSet<Peca> pecas;
    private HashSet<Peca> capturadas;
    public PartidadeXadrez()
    {
        tab = new Tabuleiro(8, 8);
        turno = 1;
        JogadorAtual = Cor.Branca;
        terminada = false;
        pecas = new HashSet<Peca>();
        capturadas = new HashSet<Peca>();
        InserirPecas();
    }
    public void ExecutaMovimento(Posicao origem, Posicao destino)
    {
        Peca p = tab.RetirarPeca(origem);
        p.IncrementarQteMovimentos();
        Peca PecaCapturada = tab.RetirarPeca(destino);
        terminada = false;
        tab.InserirPeca(p, destino);
        if (PecaCapturada!= null) 
        {
            capturadas.Add(PecaCapturada);
        }
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
    public HashSet <Peca> PecasCapturadas( Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca x in capturadas) 
        {
            if (x.cor == cor) 
            {
                aux.Add(x);
            }
        }
        return aux;
    }
    public HashSet<Peca> PecasEmJogo(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca x in pecas)
        {
            if (x.cor == cor)
            {
                aux.Add(x);
            }
        }
        aux.ExceptWith(PecasCapturadas(cor));
        return aux;
    }
    public void ColocarNovaPeca(char coluna, int linha, Peca peca)
    {
        tab.InserirPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
        pecas.Add(peca);
    }
    private void InserirPecas()
    {
        ColocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
        ColocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
        ColocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
        ColocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
        ColocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
        ColocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

        ColocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
        ColocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
        ColocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
        ColocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
        ColocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
        ColocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
    }
}

