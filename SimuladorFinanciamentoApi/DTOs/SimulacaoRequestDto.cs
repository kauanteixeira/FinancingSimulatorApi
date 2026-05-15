using System;
using System.ComponentModel.DataAnnotations;

namespace SimuladorFinanciamentoApi.DTOs
{
    public class SimulacaoRequestDto
    {
        [Required(ErrorMessage = "O valor do imóvel é obrigatório.")]
        [Range(1, double.MaxValue, ErrorMessage = "O valor do imóvel deve ser maior que zero.")]
        public double ValorImovel { get; set; }
        [Required(ErrorMessage = "O valor de entrada é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor de entrada deve ser um número positivo.")]
        public double ValorEntrada { get; set; }
        [Required(ErrorMessage = "A taxa de juros é obrigatória.")]
        [Range(0.01, 15, ErrorMessage = "A taxa de juros deve ser um número positivo.")]
        public double TaxaJuros { get; set; }
        [Required(ErrorMessage = "O prazo do financiamento é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O prazo do financiamento deve ser um número positivo.")]
        public int PrazoFinanciamento { get; set; }
        [Required(ErrorMessage = "O tipo de financiamento é obrigatório.")]
        public string TipoFinanciamento { get; set; } = string.Empty;
    }
}