using SimuladorFinanciamentoApi.Models;

namespace SimuladorFinanciamentoApi.Services
{
    public class SacService
    {
        public List<Parcela> CalcularParcelas(
            double valorFinanciado,
            double taxaMensal,
            int prazoFinanciamento)
        {
            List<Parcela> parcelas = new List<Parcela>();
            double saldoDevedor = valorFinanciado;
            double amortizacao = saldoDevedor / prazoFinanciamento;

            for (int mes = 1; mes <= prazoFinanciamento; mes++)
            {
                double juros = saldoDevedor * taxaMensal;
                double valorParcela = amortizacao + juros;

                Parcela parcela = new Parcela();
                parcela.Numero = mes;
                parcela.SaldoDevedor = saldoDevedor;
                parcela.Juros = juros;
                parcela.Amortizacao = amortizacao;
                parcela.Valor = valorParcela;

                parcelas.Add(parcela);
                saldoDevedor -= amortizacao;
            }
            return parcelas;
        }
    }
}