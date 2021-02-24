using CoffeMachine.Domain.Entities;
using CoffeMachine.Domain.Interfaces.Repositories;
using CoffeMachine.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeMachine.Infra.Repositories
{
    public class CoffeRepository : ICoffeRepository
    {
        private readonly CoffeMachineDataContext _context;
        public CoffeRepository(CoffeMachineDataContext context)
        {
            _context = context;
        }

        public async Task<List<Coffe>> Get()
        {
            return await _context.Coffes.ToListAsync();
        }

    }
}
