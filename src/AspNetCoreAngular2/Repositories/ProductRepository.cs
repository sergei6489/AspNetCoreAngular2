using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular2.Data;
using AspNetCoreAngular2.EF;

namespace AspNetCoreAngular2.Repositories
{
    public class ProductRepository
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

        public Pager<Product> Filter( ProductFilter filter,int pageIndex, int pageCount)
        {
            var products = this.context.Products.Select( n => n );
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
            var data = products.ToList();
            return new Pager<Product>()
            {
                Count = data.Count,
                List = data,
                PageCount = pageCount
            };
        }
    }
}
