using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular2.Data;
using AspNetCoreAngular2.EF;
using AspNetCoreAngular2.ViewModels;

namespace AspNetCoreAngular2.Repositories
{
    public interface IProductRepository
    {
        Product GetById( int id );
        Pager<ProductViewModel> Filter( ProductFilter filter, int pageIndex, int pageCount );
        void AddProduct(ProductViewModel product);
        void UpdateProduct();
        void DeleteProduct();
    }
}
