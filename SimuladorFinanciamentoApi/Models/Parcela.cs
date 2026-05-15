using System;
using System.Globalization;
using System.Collections.Generic;

namespace SimuladorFinanciamentoApi.Models
{
    public class Parcela
    {
        public int Numero { get; set; }
        public double Valor { get; set; }
        public double Juros { get; set; }
        public double Amortizacao { get; set; }
        public double SaldoDevedor { get; set; }
    }
}