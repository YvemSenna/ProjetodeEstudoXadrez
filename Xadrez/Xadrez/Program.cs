using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Tabuleiro;

namespace Xadrez;
class program
{
    static void Main(string[] args)
    {
        Posicao P;
        P = new Posicao(3, 4);

        Console.WriteLine("Posicao: " + P);
        Console.ReadLine();
    }
}

