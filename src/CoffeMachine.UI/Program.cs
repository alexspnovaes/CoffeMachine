using CoffeMachine.UI.Models.Response;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeMachine.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var listCoffes = await GetCoffes();
            decimal[] validCoins = { 0.10M, 0.25M, 0.50M, 1 };

            WriteMenu(listCoffes);

            Console.WriteLine("Insira moedas para continuar. As moedas aceitas são:");
            foreach (var validCoin in validCoins)
            {
                Console.WriteLine($"R${validCoin}");
            }

            decimal n;
            while (!decimal.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Entre com um novo valor");
            }
            if (n >= 1)
                Console.ReadKey();
        }

        private static void WriteMenu(List<CoffeResponse> coffes)
        {
            Console.WriteLine("As opções de cafés são: ");
            foreach (var coffe in coffes)
            {
                Console.WriteLine($"{coffe.Name} - R$ {coffe.Value}");
            }
            Console.WriteLine();
        }

        private static async Task<List<CoffeResponse>> GetCoffes()
        {
            var url = "https://localhost:44343/api/v1/Coffe";
            return await url.GetJsonAsync<List<CoffeResponse>>();
        }
    }
}
