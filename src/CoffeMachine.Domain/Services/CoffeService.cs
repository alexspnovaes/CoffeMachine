using CoffeMachine.Domain.Entities;
using CoffeMachine.Domain.Interfaces.Repositories;
using CoffeMachine.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachine.Domain.Services
{
    public class CoffeService : ICoffeService
    {
        private readonly ICoffeRepository _coffeRepository;

        public CoffeService(ICoffeRepository coffeRepository)
        {
            _coffeRepository = coffeRepository;
        }

        public async Task<List<Coffe>> Get() => await _coffeRepository.Get();
    }
}
