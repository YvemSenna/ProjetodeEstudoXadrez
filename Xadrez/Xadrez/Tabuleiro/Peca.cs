﻿namespace tabuleiro;

abstract class Peca
{
    public Posicao posicao { get; set; }
    public Cor cor { get; protected set; }
    public int QteMovimentos { get; protected set; }
    public Tabuleiro tab { get; protected set; }

    public Peca(Cor cor, Tabuleiro tab)
    {
        this.posicao = null;
        this.cor = cor;
        this.tab = tab;
        this.QteMovimentos = 0;
    }
    public abstract bool[,] MovimentosPossiveis();
    public Peca(Tabuleiro tab, Cor cor)
    {
        this.tab = tab;
        this.cor = cor;
    }
    public void IncrementarQteMovimentos()
    {
        QteMovimentos++;
    }
}
