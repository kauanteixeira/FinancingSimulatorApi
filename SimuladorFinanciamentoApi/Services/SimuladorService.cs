using SimuladorFinanciamentoApi.DTOs;
using SimuladorFinanciamentoApi.Models;

namespace SimuladorFinanciamentoApi.Services
{
    public class SimuladorService
    {
        private readonly SacService _sacService;
        private readonly PriceService _priceService;
        public SimuladorService(SacService sacService, PriceService priceService)
        {
            _sacService = sacService;
            _priceService = priceService;
        }

       public SimulacaoResponseDto SimularFinanciamento(SimulacaoRequestDto request)
        {
            var financiamento = new Financiamento();

            financiamento.ValorImovel =  request.ValorImovel;
            financiamento.ValorEntrada = request.ValorEntrada;
            financiamento.TaxaJuros = request.TaxaJuros;
            financiamento.PrazoFinanciamento = request.PrazoFinanciamento;
            financiamento.TipoFinanciamento = request.TipoFinanciamento.Trim().ToUpper();

            double valorFinanciado = financiamento.CalcularValorFinanciado();
            double taxaMensal = financiamento.ConverterTaxa();
            
            List<Parcela> parcelas;
            if (financiamento.TipoFinanciamento == "SAC")
            {
                parcelas = _sacService.CalcularParcelas(valorFinanciado, taxaMensal, financiamento.PrazoFinanciamento);
            }
            else if (financiamento.TipoFinanciamento == "PRICE")
            {
                parcelas = _priceService.CalcularParcelas(valorFinanciado, taxaMensal, financiamento.PrazoFinanciamento);
            }
            else
            {
                throw new ArgumentException("Tipo de financiamento não suportado");
            }

            var resumo = financiamento.CalcularTotais(parcelas);

            var response = new SimulacaoResponseDto
            {
                TotalPago = resumo.TotalPago,
                TotalJuros = resumo.TotalJuros,
                TotalAmortizado = resumo.TotalAmortizado,
                Parcelas = parcelas
            };

            return response;
        }
    }
}
