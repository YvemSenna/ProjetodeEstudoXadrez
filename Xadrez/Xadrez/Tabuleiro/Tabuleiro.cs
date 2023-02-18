namespace tabuleiro;

class Tabuleiro
{
    public int linhas { get; set; }
    public int colunas { get; set; }

    private Peca[,] pecas;

    public Tabuleiro(int linhas, int colunas)
    {
        this.linhas = linhas;
        this.colunas = colunas;
        pecas = new Peca[linhas, colunas];
    }
    public Tabuleiro()
    {

    }
    public Peca peca(int linha, int coluna)
    {
        return pecas[linha, coluna];
    }
    public Peca peca(Posicao pos)
    {
        return pecas[pos.linha, pos.coluna];
    }
    public bool ExistePeca(Posicao pos)
    {
        ValidarPosicao(pos);
        return peca(pos) != null;
    }
    public void InserirPeca(Peca p, Posicao pos)
    {
        if (ExistePeca(pos)) 
        {
            throw new TabuleiroException("Já existe peça nesta posição");
        }
        pecas[pos.linha, pos.coluna] = p;
        p.posicao = pos;
    }
    public Peca RetirarPeca(Posicao pos)
    {
        if (peca(pos) == null)
        {
            return null;
        }
        Peca aux = peca(pos);
        aux.posicao = null;
        pecas[pos.linha, pos.coluna] = null;
        return aux;
    }
    public bool Posicaovalida(Posicao pos) 
    { 
        if(pos.linha < 0 || pos.linha >= linhas || pos.coluna <0 || pos.coluna >= colunas) 
        {
            return false;
        }
        return true;    
    }
    public void ValidarPosicao(Posicao pos) 
    {
        if(!Posicaovalida(pos))
        {
            throw new TabuleiroException("Posição Invalida!");
        }
    }
}