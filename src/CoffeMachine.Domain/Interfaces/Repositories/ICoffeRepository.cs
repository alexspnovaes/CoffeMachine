using CoffeMachine.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeMachine.Domain.Interfaces.Repositories
{
    public interface ICoffeRepository
    {
        Task<List<Coffe>> Get();
    }
}
