using CoffeMachine.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeMachine.Domain.Interfaces.Services
{
    public interface ICoffeService
    {
        Task<List<Coffe>> Get();
    }
}
