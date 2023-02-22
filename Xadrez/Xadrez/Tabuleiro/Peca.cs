namespace tabuleiro;

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
    public Peca(Tabuleiro tab, Cor cor)
    {
        this.tab = tab;
        this.cor = cor;
    }
    public void IncrementarQteMovimentos()
    {
        QteMovimentos++;
    }
    public void DecrementarQteMovimentos()
    {
        QteMovimentos--;
    }
    public bool ExisteMovimentosPossiveis()
    {
        bool[,] mat = MovimentosPossiveis();

        for (int i=0; i<tab.linhas; i++)
        {
            for (int j=0; j<tab.colunas; j++)
            {
                if (mat[i, j])
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool MovimentoPossivel(Posicao pos)
    {
        return MovimentosPossiveis()[pos.linha, pos.coluna];
    }
    public abstract bool[,] MovimentosPossiveis();
}
