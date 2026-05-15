using System;
using System.Globalization;
using System.Collections.Generic;

namespace SimuladorFinanciamentoApi.Models
{
    public class Financiamento
    {
        public double ValorImovel { get; set; }
        public double ValorEntrada { get; set; }
        public double TaxaJuros { get; set; }
        public int PrazoFinanciamento { get; set; }
        public string TipoFinanciamento { get; set; } = string.Empty;

        public double CalcularValorFinanciado()
        {
            return ValorImovel - ValorEntrada;
        }
        public double ConverterTaxa()
        {
            return TaxaJuros / 100;
        }
        public ResumoFinanciamento CalcularTotais(List<Parcela> parcelas)
        {
            var resumo = new ResumoFinanciamento();

            foreach(var p in parcelas)
            {
                resumo.TotalPago += p.Valor;
                resumo.TotalJuros += p.Juros;
                resumo.TotalAmortizado += p.Amortizacao;
            }

            return resumo;
        }
    }
}
