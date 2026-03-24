using System;
using System.Globalization;
using ProjetoTCC.Models;

namespace ProjetoTCC.Services
{
    public class SimuladorService
    {
        public void Executar()
        {
            var simulacao = new Financiamento();

            simulacao.ValorImovel = ValidarEntrada("Valor do imóvel: ", x => x > 0, "O valor do imóvel deve ser maior do que 0");

            simulacao.ValorEntrada = ValidarEntrada("Valor de entrada: ", x => x >= 0 && x < simulacao.ValorImovel, "A entrada não pode ser igual e nem maior que o valor do imóvel");

            simulacao.TaxaJuros = ValidarEntrada("Taxa mensal de juros: ", x => x > 0 && x <= 15, "A taxa de juros mensais deve ficar entre 0% e 15%");

            simulacao.PrazoFinanciamento = ValidarPrazo("Prazo em meses: ", x => x > 0, "O prazo precisa ser maior do que 0");

            Console.WriteLine($"\n========== SIMULAÇÃO ==========");
            Console.WriteLine(simulacao);
        }

        public double ValidarEntrada(string mensagem, Func<double, bool> regra, string mensagemErro)
        {
            double numero = 0;
            bool valorValido = false;

            while (!valorValido)
            {
                Console.Write(mensagem);
                string entrada = Console.ReadLine();

                bool ehNumero = double.TryParse(entrada, out numero);

                if (!ehNumero)
                {
                    Console.WriteLine("Valor inválido!");
                }
                else if (!regra(numero))
                {
                    Console.WriteLine(mensagemErro);
                }
                else
                {
                    valorValido = true;
                }
            }
            return numero;
        }

        public int ValidarPrazo(string mensagem, Func<int, bool> regra, string mensagemErro)
        {
            int intNumero = 0;
            bool intValido = false;

            while(!intValido)
            {
                Console.Write(mensagem);
                string intEntrada = Console.ReadLine();

                bool ehInt = int.TryParse(intEntrada, out intNumero);

                if (!ehInt)
                {
                    Console.WriteLine("Prazo inválido!");
                }
                else if (!regra(intNumero))
                {
                    Console.WriteLine(mensagemErro);
                }
                else
                {
                    intValido = true;
                }
            }
            return intNumero;
        }
    }
}
