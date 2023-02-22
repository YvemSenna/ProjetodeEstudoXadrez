using tabuleiro;

namespace Xadrez;

class Peao : Peca
{
    private PartidadeXadrez partida;
    public Peao ( Tabuleiro tab, Cor cor, PartidadeXadrez partida) : base (tab, cor)
    {
        this.partida = partida;
    }
    public override string ToString()
    {
        return "P";
    }
    private bool ExisteInimigo(Posicao pos)
    {
        Peca p = tab.peca(pos);
        return p == null || p.cor != cor;
    }
    private bool livre(Posicao pos)
    {
        return tab.peca(pos) == null;
    }

    public override bool[,] MovimentosPossiveis()
    {
        bool[,] mat = new bool[tab.linhas, tab.colunas];

        Posicao pos = new Posicao(0, 0);

        if (cor == Cor.Branca) 
        {
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if (tab.Posicaovalida(pos) && livre(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha - 2, posicao.coluna);
            if (tab.Posicaovalida(pos) && livre(pos) && QteMovimentos == 0)
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.Posicaovalida(pos) && ExisteInimigo(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.Posicaovalida(pos) && ExisteInimigo(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //#JogadaEspecial EnPassant
            if (posicao.linha == 3) 
            {
                Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                if(tab.Posicaovalida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.VulneravelEnPassant)
                {
                    mat[esquerda.linha - 1, esquerda.coluna] = true;
                }

                Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                if (tab.Posicaovalida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.VulneravelEnPassant)
                {
                    mat[direita.linha - 1, direita.coluna] = true;
                }
            }
        }
        else
        {
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            if (tab.Posicaovalida(pos) && livre(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 2, posicao.coluna);
            if (tab.Posicaovalida(pos) && livre(pos) && QteMovimentos == 0)
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.Posicaovalida(pos) && ExisteInimigo(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.Posicaovalida(pos) && ExisteInimigo(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //#JogadaEspecial EnPassant
            if (posicao.linha == 4)
            {
                Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                if (tab.Posicaovalida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.VulneravelEnPassant)
                {
                    mat[esquerda.linha + 1, esquerda.coluna] = true;
                }

                Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                if (tab.Posicaovalida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.VulneravelEnPassant)
                {
                    mat[direita.linha + 1, direita.coluna] = true;
                }
            }
        }
        return mat;
    }
}
