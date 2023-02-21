using tabuleiro;

namespace Xadrez;

class Torre : Peca
{
    public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
    {

    }
    public override string ToString()
    {
        return "T";
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

        //Acimna
        pos.DefinirValores(pos.linha -1, pos.coluna);
        while(tab.Posicaovalida(pos) && PodeMover(pos)) 
        {
            mat[pos.linha, pos.coluna] = true;
            if(tab.peca(pos) != null && tab.peca(pos).cor != cor)
            {
                break;
            }
            pos.linha = pos.linha -1;
        }

        //Abaixo
        pos.DefinirValores(pos.linha + 1, pos.coluna);
        while (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
            if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
            {
                break;
            }
            pos.linha = pos.linha + 1;
        }

        //Direita
        pos.DefinirValores(pos.linha, pos.coluna +1);
        while (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
            if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
            {
                break;
            }
            pos.coluna = pos.coluna + 1;
        }

        //Esquerda
        pos.DefinirValores(pos.linha, pos.coluna - 1);
        while (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
            if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
            {
                break;
            }
            pos.coluna = pos.coluna - 1;
        }
        return mat;
    }
}
