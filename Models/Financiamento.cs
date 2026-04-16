using System;
using System.Globalization;
using System.Collections.Generic;

namespace ProjetoTCC.Models
{
    public class Financiamento
    {
        public double ValorImovel { get; set; }
        public double ValorEntrada { get; set; }
        public double TaxaJuros { get; set; }
        public int PrazoFinanciamento { get; set; }
        public string TipoFinanciamento { get; set; }

        public double CalcularValorFinanciado()
        {
            return ValorImovel - ValorEntrada;
        }
        public double ConverterTaxa()
        {
            return TaxaJuros / 100;
        }
        public List<Parcela> GerarParcelas()
        {

            if (TipoFinanciamento == "SAC")
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
        public ResumoFinanciamento CalcularTotais()
        {
            var resumo = new ResumoFinanciamento();

            var parcelas = GerarParcelas();
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
