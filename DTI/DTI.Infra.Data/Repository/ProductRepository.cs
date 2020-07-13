using DTI.Domain.Entities;
using DTI.Infra.Data.Context;
using DTI.Infra.Data.Interface;
using DTI.Infra.Data.Repository.Base;

namespace DTI.Infra.Data.Repository
{
    public class ProductRepository : AsyncRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context) { }
    }
}
