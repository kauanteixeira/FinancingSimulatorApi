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
        public string TipoFinanciamento = "";

        public double CalcularValorFinanciado()
        {
            return ValorImovel - ValorEntrada;
        }
        public double ConverterTaxa()
        {
            return TaxaJuros / 100;
        }
        public class Parcela
        {
            public int Numero;
            public double Valor;
            public double Juros;
            public double Amortizacao;
            public double SaldoDevedor;
        }
        public List<Parcela> GerarParcelas()
        {

            if (TipoFinanciamento.ToUpper() == "SAC")
            {
                List<Parcela> parcelas = new List<Parcela>();
                double saldoDevedor = CalcularValorFinanciado();
                double amortizacao = saldoDevedor / PrazoFinanciamento;

                for (int mes = 1; mes <= PrazoFinanciamento; mes++)
                {
                    Parcela parcela = new Parcela();
                    parcela.Numero = mes;
                    parcela.SaldoDevedor = saldoDevedor;
                    parcela.Juros = saldoDevedor * ConverterTaxa();
                    parcela.Amortizacao = amortizacao;
                    parcela.Valor = amortizacao + parcela.Juros;

                    parcelas.Add(parcela);

                    saldoDevedor -= amortizacao;

                }
                return parcelas;
            }
            else
            {
                double taxaMensal = ConverterTaxa();
                double saldoDevedor = CalcularValorFinanciado();
                double fatorJurosCompostos = Math.Pow(1 + taxaMensal, PrazoFinanciamento);
                double parcelaFixa = saldoDevedor * (taxaMensal * fatorJurosCompostos / (fatorJurosCompostos - 1));
                List<Parcela> parcelas = new List<Parcela>();

                for (int mes = 1; mes <= PrazoFinanciamento; mes++)
                {
                    double juros = saldoDevedor * taxaMensal;
                    double amortizacao = parcelaFixa - juros;

                    Parcela parcela = new Parcela();
                    parcela.Numero = mes;
                    parcela.SaldoDevedor = saldoDevedor;
                    parcela.Juros = juros;
                    parcela.Amortizacao = amortizacao;
                    parcela.Valor = parcelaFixa;

                    parcelas.Add(parcela);

                    saldoDevedor -= amortizacao;

                }
                return parcelas;
            }
        }
    }
}
