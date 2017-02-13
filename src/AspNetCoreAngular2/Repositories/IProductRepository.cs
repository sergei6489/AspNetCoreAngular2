using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular2.EF;
using AspNetCoreAngular2.ViewModel;
using AspNetCoreAngular2.ViewModels;

namespace AspNetCoreAngular2.Repositories
{
    public interface IProductRepository
    {
        Product GetById( int id );
        Pager<ProductViewModel> Filter( ProductFilter filter );
        void AddProduct(ProductViewModel product);
        void UpdateProduct(ProductViewModel product);
        void DeleteProduct(int id);
    }
}
