using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Lab_Fit.Core
{
    public class AlteracaoFisica
    {
        public AlteracaoFisica(float value) {
            Registo ??= new();
            Registo.Unidade = value;
        }

        public AlteracaoFisica() {
            Registo ??= new();
            Registo.Unidade = 0;
        }
        public AlteracaoFisica(float value,string NomeTipo) {
            Registo ??= new();
            Registo.Unidade = value;
            tipo = NomeTipo;
            Date = DateTime.Now;
        }
        #region vars
        public TipoRegistoFisico Registo { get; set; }
        //public float Value { get; set; }
        public DateTime Date { get; set; }
        public string tipo { get; set; }
        #endregion
    }
}