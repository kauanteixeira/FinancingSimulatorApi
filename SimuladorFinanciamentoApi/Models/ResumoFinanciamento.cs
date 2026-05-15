using System;
using System.Globalization;

namespace SimuladorFinanciamentoApi.Models
{
    public class ResumoFinanciamento
    {
        public double TotalPago { get; set; }
        public double TotalJuros { get; set; }
        public double TotalAmortizado { get; set; }
    }
}
