using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular2.Data;
using AspNetCoreAngular2.EF;
using AspNetCoreAngular2.ViewModels;

namespace AspNetCoreAngular2.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private MainDBContext context;

        public ProductRepository(MainDBContext context)
        {
            this.context = context;
        }

        public Product GetById(int id)
        {
          return this.context.Products.FirstOrDefault( n => n.Id == id );
        }

        public Pager<ProductViewModel> Filter( ProductFilter filter,int pageIndex, int pageCount)
        {
            var products = this.context.Products.Select( n => new ProductViewModel() {
                Id = n.Id,
                Category = n.Category,
                Date = n.Date,
                Description = n.Description,
                Image = n.Image,
                Name = n.Name,
                Price = n.Price
            } );
            if (!String.IsNullOrEmpty(filter.Category))
            {
                products = products.Where( n => n.Category == filter.Category );
            }
            if (filter.MaxPrice.HasValue)
            {
                products = products.Where( n => n.Price < filter.MaxPrice.Value );
            }
            if (filter.MinimalPrice.HasValue)
            {
                products = products.Where( n => n.Price > filter.MinimalPrice.Value );
            }
            if(!String.IsNullOrEmpty(filter.Name))
            {
                products = products.Where( n => n.Name.Contains( filter.Name ) );
            }
            var data = products.Skip(pageIndex * pageCount).Take(pageCount).ToList();
            return new Pager<ProductViewModel>()
            {
                Count = data.Count,
                List = data,
                PageCount = pageCount,
                TotalCount = products.Count()
            };
        }

        public void AddProduct(ProductViewModel product)
        {
            var data = new ProductViewModel()
            {
                Category=product.
            }
            this.context.Products.Add( product );
        }

        public void UpdateProduct(ProductViewModel product)
        {
            var data = this.context.Products.FirstOrDefault( n => n.Id == product.Id );
            if (data!=null)
            {
                data.Category = product.Category;
                data.Date = product.Date;
                data.Description = product.Description;
                data.Image = product.Image;
                data.Name = product.Name;
                data.Price = product.Price;
            }
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }
    }
}
