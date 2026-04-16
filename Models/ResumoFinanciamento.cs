using System;
using System.Globalization;

namespace ProjetoTCC.Models
{
    public class ResumoFinanciamento()
    {
        public double TotalPago { get; set; }
        public double TotalJuros { get; set; }
        public double TotalAmortizado { get; set; }
    }
}
