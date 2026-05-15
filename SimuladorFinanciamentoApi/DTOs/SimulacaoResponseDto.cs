using SimuladorFinanciamentoApi.Models;

namespace SimuladorFinanciamentoApi.DTOs
{
    public class SimulacaoResponseDto
    {
        public double TotalPago { get; set; }
        public double TotalJuros { get; set; }
        public double TotalAmortizado { get; set; }
        public List<Parcela> Parcelas { get; set; } = new List<Parcela>();
    }
}