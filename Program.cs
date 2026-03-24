using System;
using System.Globalization;
using ProjetoTCC.Models;
using ProjetoTCC.Services;

namespace MyTCC
{
    public class Program
    {
        static void Main(string[] args)
        {
            var simulador = new SimuladorService();
            simulador.Executar();
        }
    }
}