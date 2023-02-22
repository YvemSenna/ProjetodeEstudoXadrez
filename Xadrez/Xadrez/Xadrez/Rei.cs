using tabuleiro;

namespace Xadrez;

class Rei : Peca
{
    private PartidadeXadrez partida;
    public Rei(Tabuleiro tab, Cor cor, PartidadeXadrez partida) : base (tab, cor)
    {
        this.partida = partida;
    }
    public override string ToString()
    {
        return "R";
    }
    private bool PodeMover(Posicao pos)
    {
        Peca p = tab.peca(pos);
        return p == null || p.cor != cor;
    }
    private bool TesteTorreParaRoque(Posicao pos)
    {
        Peca p = tab.peca(pos);
        return p != null && p is Torre && p.cor == cor && p.QteMovimentos == 0;
    }
    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[tab.linhas, tab.colunas];

        Posicao pos = new Posicao(0, 0);

        //Acimna
        pos.DefinirValores(posicao.linha - 1, posicao.coluna);
        if (tab.Posicaovalida(pos) && PodeMover(pos)) 
        {
            mat[pos.linha, pos.coluna] = true;
        }

        //Nordeste
        pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
        if (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        //Direita
        pos.DefinirValores(posicao.linha, posicao.coluna + 1);
        if (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        //Sudeste
        pos.DefinirValores(posicao.linha +1, posicao.coluna + 1);
        if (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        //Abaixo
        pos.DefinirValores(posicao.linha + 1, posicao.coluna);
        if (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        //Sudoeste
        pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
        if (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        //Esquerda
        pos.DefinirValores(posicao.linha, posicao.coluna - 1);
        if (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        //Noroeste
        pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
        if (tab.Posicaovalida(pos) && PodeMover(pos))
        {
            mat[pos.linha, pos.coluna] = true;
        }

        //#JogadaEspecial RoquePequeno 
        if (QteMovimentos == 0 && !partida.xeque)
        {
            Posicao PosT1 = new Posicao(posicao.linha, posicao.coluna + 3);
            if (TesteTorreParaRoque(PosT1)) 
            {
                Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                if (tab.peca(p1) == null && tab.peca(p2) == null)
                {
                    mat[posicao.linha, posicao.coluna + 2] = true; 
                }
            }
        }

        //#JogadaEspecial RoqueGrande
        if (QteMovimentos == 0 && !partida.xeque)
        {
            Posicao PosT2 = new Posicao(posicao.linha, posicao.coluna + 3);
            if (TesteTorreParaRoque(PosT2))
            {
                Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                {
                    mat[posicao.linha, posicao.coluna - 2] = true;
                }
            }
        }
        return mat;
    }
}
