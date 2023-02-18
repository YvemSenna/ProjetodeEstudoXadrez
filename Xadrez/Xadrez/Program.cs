using System;
using tabuleiro;
using Xadrez;

namespace Xadrez;
class program
{
    static void Main(string[] args)
    {
        PosicaoXadrez pos = new PosicaoXadrez('a', 1);
        Console.WriteLine(pos);
        Console.WriteLine(pos.toPosicao()); 
    }
}

    

