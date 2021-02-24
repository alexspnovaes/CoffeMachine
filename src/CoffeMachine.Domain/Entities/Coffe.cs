using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMachine.Domain.Entities
{
    public class Coffe : BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
