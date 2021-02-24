using CoffeMachine.UI.Models.Response;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeMachine.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var listCoffes = await GetCoffes();
            decimal[] validCoins = { 0.10M, 0.25M, 0.50M, 1 };
            decimal inputValue = 0M;
            decimal sumValue = 0M;
           
            ConsoleKeyInfo input;

            WriteMenu(listCoffes);
            WriteValidCoins(validCoins);

            do
            {
                Console.WriteLine("Pressione qualquer tecla para continuar ou esc para cancelar");
                input = Console.ReadKey();

                if (input.Key != ConsoleKey.Escape)
                {

                    Console.WriteLine("Insira uma moeda");

                    inputValue = CheckValueIsDecimal();

                    inputValue = CheckValidCoins(validCoins, inputValue);

                    sumValue += inputValue;

                    Console.WriteLine($"Saldo: {sumValue}");

                    if (OrderAvailablesCoffes(listCoffes, sumValue))
                        break;
                }
            } while (input.Key != ConsoleKey.Escape);
        }

        private static bool OrderAvailablesCoffes(List<CoffeResponse> listCoffes, decimal sumValue)
        {
            int selectedCoffe = 0;
            var coffesAvailable = listCoffes.Where(w => w.Value <= sumValue).ToList();
            if (coffesAvailable.Any())
            {
                Console.WriteLine("Com esse valor é possível comprar as seguintes opções: ");
                coffesAvailable.ForEach(x => Console.WriteLine($"{x.Id} - {x.Name} - R$ {x.Value}"));
                Console.WriteLine("Caso deseje um desses valores, insira o número ou pressione qualquer tecla para continuar");
                if (int.TryParse(Console.ReadLine(), out selectedCoffe) && coffesAvailable.Any(w => w.Id == selectedCoffe))
                {
                    //essa parte poderia chamar a API e fazer o order do café
                    Console.WriteLine($"Entregando  {coffesAvailable.FirstOrDefault(w => w.Id == selectedCoffe).Name}");
                    Console.WriteLine($"Troco: R$ {(sumValue - coffesAvailable.FirstOrDefault(w => w.Id == selectedCoffe).Value)}");
                    Console.ReadKey();
                    return true;
                }
            }
            return false;
        }

        private static decimal CheckValidCoins(decimal[] validCoins, decimal inputValue)
        {
            while (!validCoins.Contains(inputValue))
            {
                Console.WriteLine("Moeda não aceita");
                Console.WriteLine("Entre com um novo valor");
                inputValue = CheckValueIsDecimal();
            }

            return inputValue;
        }

        private static decimal CheckValueIsDecimal()
        {
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Entre com um novo valor");
            }

            return value;
        }

        private static void WriteValidCoins(decimal[] validCoins)
        {
            Console.WriteLine("As moedas aceitas são:");
            foreach (var validCoin in validCoins)
            {
                Console.WriteLine($"R${validCoin}");
            }
        }

        private static void WriteMenu(List<CoffeResponse> coffes)
        {
            Console.WriteLine("As opções de cafés são: ");
            foreach (var coffe in coffes)
            {
                Console.WriteLine($"{coffe.Id} - {coffe.Name} - R$ {coffe.Value}");
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
