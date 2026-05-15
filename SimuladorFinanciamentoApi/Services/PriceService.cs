using SimuladorFinanciamentoApi.Models;

namespace SimuladorFinanciamentoApi.Services
{
    public class PriceService
    {
        public List<Parcela> CalcularParcelas(
            double valorFinanciado,
            double taxaMensal,
            int prazoFinanciamento)
        {
            List<Parcela> parcelas = new List<Parcela>();

            double fatorJurosCompostos = Math.Pow(1 + taxaMensal, prazoFinanciamento);
            double parcelaFixa = valorFinanciado * (taxaMensal * fatorJurosCompostos / (fatorJurosCompostos - 1));
            
            for (int mes = 1; mes <= prazoFinanciamento; mes++)
            {
                double juros = valorFinanciado * taxaMensal;
                double amortizacao = parcelaFixa - juros;

                Parcela parcela = new Parcela();
                parcela.Numero = mes;
                parcela.SaldoDevedor = valorFinanciado;
                parcela.Juros = juros;
                parcela.Amortizacao = amortizacao;
                parcela.Valor = parcelaFixa;

                parcelas.Add(parcela);
                valorFinanciado -= amortizacao;
            }
            return parcelas;
        }
    }
}