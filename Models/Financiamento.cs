using System;
using System.Globalization;

namespace ProjetoTCC.Models
{
    public class Financiamento
    {
        public double ValorImovel;
        public double ValorEntrada;
        public double TaxaJuros;
        public int PrazoFinanciamento;

        public double CalcularValorFinanciado()
        {
            return ValorImovel - ValorEntrada;
        }
        public double ConverterTaxa()
        {
            return TaxaJuros / 100;
        }
        public double CalcularParcela()
        {
            double taxaMensal = ConverterTaxa();
            double valorFinanciado = CalcularValorFinanciado();
            double fatorJurosCompostos = Math.Pow(1 + taxaMensal, PrazoFinanciamento);
            return valorFinanciado * (taxaMensal * fatorJurosCompostos / (fatorJurosCompostos - 1));
        }
        public double CalcularTotalPago()
        {
            double parcela = CalcularParcela();
            return parcela * PrazoFinanciamento;
        }
        public double CalcularJuros()
        {
            double totalPago = CalcularTotalPago();
            double valorFinanciado = CalcularValorFinanciado();
            return totalPago - valorFinanciado;
        }
        public override string ToString()
        {
            return "\nValor do Imóvel: " + ValorImovel.ToString("C", new CultureInfo("pt-BR"))
                + "  |  Entrada: " + ValorEntrada.ToString("C", new CultureInfo("pt-BR"))
                + "\nSaldo Devedor: " + CalcularValorFinanciado().ToString("C", new CultureInfo("pt-BR"))
                + "  |  Total pago (com juros): " + CalcularTotalPago().ToString("C", new CultureInfo("pt-BR"))
                + "\nJuros Pagos: " + CalcularJuros().ToString("C", new CultureInfo("pt-BR"))
                + "  |  Taxa de juros: " + TaxaJuros + "% (ao mês)"
                + "\nPrazo/Periodo: " + PrazoFinanciamento;
        }
    }
}
