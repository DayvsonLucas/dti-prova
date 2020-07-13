using DTI.Domain.Entities;
using DTI.Infra.Data.Interface.Base;

namespace DTI.Infra.Data.Interface
{
   public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
