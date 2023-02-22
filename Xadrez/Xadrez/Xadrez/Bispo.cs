using tabuleiro;

namespace Xadrez;

class Bispo : Peca
{
    public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
    {
      
    }
    public override string ToString()
    {
        return "B";
    }
    private bool PodeMover(Posicao pos) 
    {
        Peca p = tab.peca(pos);
        return p == null || p.cor != cor;
    }
    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[tab.linhas, tab.colunas];

        Posicao pos = new Posicao(0, 0);

        //Noroeste
        pos.DefinirValores(pos.linha - 1, pos.coluna - 1);
        while (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
            if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.linha - 1, pos.linha - 1);
        }
        //Nordeste
        pos.DefinirValores(pos.linha - 1, pos.coluna + 1);
        while (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
            if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.linha - 1, pos.linha + 1);
        }
        //Sudeste
        pos.DefinirValores(pos.linha + 1, pos.coluna + 1);
        while (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
            if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.linha + 1, pos.linha + 1);
        }
        //Sudoeste
        pos.DefinirValores(pos.linha + 1, pos.coluna - 1);
        while (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
            if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
            {
                break;
            }
            pos.DefinirValores(pos.linha + 1, pos.linha - 1);
        }
        return mat;
    }
}
