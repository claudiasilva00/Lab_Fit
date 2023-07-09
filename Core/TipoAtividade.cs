using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Fit.Core
{
    public class TipoAtividade : Tipo
    {
        public TipoAtividade() { Atividade = ""; }
        public string Atividade { get; set; }
    }
}
