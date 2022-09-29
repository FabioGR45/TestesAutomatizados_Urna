using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Eleicao
{
    public class Candidato
    {

        public string Nome { get; set; }
        public int Votos { get; set; }

        public const int votosCand1 = 3;

        public Candidato(string name)
        {
            Nome = name;
            Votos = 0;
        }

        public void AdicionarVoto() => Votos += 1;

        public int RetornarVotos()
        {
            return Votos;
        }

    }
}
