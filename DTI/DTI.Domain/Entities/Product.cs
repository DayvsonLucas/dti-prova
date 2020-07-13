using DTI.Domain.Core.Models;

namespace DTI.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}
