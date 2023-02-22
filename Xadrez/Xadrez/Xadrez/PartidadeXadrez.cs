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
    public bool xeque { get; private set; }

    private HashSet<Peca> pecas;
    private HashSet<Peca> capturadas;
    public PartidadeXadrez()
    {
        tab = new Tabuleiro(8, 8);
        turno = 1;
        JogadorAtual = Cor.Branca;
        terminada = false;
        xeque = false;
        pecas = new HashSet<Peca>();
        capturadas = new HashSet<Peca>();
        InserirPecas();
    }
    public Peca ExecutaMovimento(Posicao origem, Posicao destino)
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
        return PecaCapturada;
    }
    public void DesfazMovimento(Posicao origem, Posicao destino, Peca PecaCapturada)
    {
        Peca p = tab.RetirarPeca(destino);
        p.DecrementarQteMovimentos();
        if (PecaCapturada != null)
        {
            tab.InserirPeca(PecaCapturada, destino);
            capturadas.Remove(PecaCapturada);
        }
        tab.InserirPeca(p, origem);
    }
    public void RealizaJogada(Posicao origem, Posicao destino)
    {
        Peca PecaCapturada = ExecutaMovimento(origem, destino);

        if (EstaEmXeque(JogadorAtual))
        {
            DesfazMovimento(origem, destino, PecaCapturada);
            throw new TabuleiroException("Você não pode se colocar em xeqwue!");
        }
        if (EstaEmXeque(Adversaria(JogadorAtual)))
        {
            xeque = true;
        }
        else
        {
            xeque = false;
        }
        if (TesteXequeMate(Adversaria(JogadorAtual)))
        {
            terminada= true;    
        }
        else
        {
            turno++;
            MudaJogador();
        }
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
        if (!tab.peca(origem).MovimentoPossivel(destino)) 
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
    private Cor Adversaria (Cor cor)
    {
        if (cor == Cor.Branca)
        {
            return Cor.Preta;
        }
        else
        {
            return Cor.Branca;
        }
    }
    private Peca rei(Cor cor )
    {
        foreach(Peca x in PecasEmJogo(cor)) 
        {
            if (x is Rei)
            {
                return x;
            }
        }
        return null;
    }
    public bool EstaEmXeque(Cor cor)
    {
        Peca R = rei(cor);
        if (R == null)
        {
            throw new TabuleiroException("Não tem Rei da cor " + cor + "no tabuleiro!");
        }
        foreach (Peca x in PecasEmJogo(Adversaria(cor))) 
        {
            bool[,] mat = x.MovimentosPossiveis();
            if (mat[R.posicao.linha, R.posicao.coluna])
            {
                return true;
            }
        }
        return false;
    }
    public bool TesteXequeMate(Cor cor)
    {
        if (!EstaEmXeque(cor))
        {
            return false;
        }
        foreach (Peca x in PecasEmJogo(cor)) 
        {
            bool[,] mat = x.MovimentosPossiveis();

            for (int i = 0; i < tab.linhas; i++) 
            {
                for (int j = 0; j < tab.colunas; j ++)
                {
                    if (mat[i, j])
                    {
                        Posicao origem = x.posicao;
                        Posicao destino = new Posicao(i, j);
                        Peca PecaCapturada = ExecutaMovimento(origem, destino);
                        bool TesteXeque = EstaEmXeque(cor);
                        DesfazMovimento(origem, destino, PecaCapturada);
                        if (!TesteXeque) 
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
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

