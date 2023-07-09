using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Fit.Core
{
    public class Tipo
    {
        public Tipo() { Name = ""; }
        public Tipo(string name) { Name = name; }
        #region vars
        virtual public int ID { get; set; }
        virtual public string Name { get; set; }
        #endregion
    }
}
