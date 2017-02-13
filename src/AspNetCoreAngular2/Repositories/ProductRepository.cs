using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular2.EF;
using AspNetCoreAngular2.ViewModel;
using AspNetCoreAngular2.ViewModels;
using AutoMapper;

namespace AspNetCoreAngular2.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private MainDBContext context;
        private IMapper mapper;

        public ProductRepository(MainDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Product GetById(int id)
        {
          return this.context.Products.FirstOrDefault( n => n.Id == id );
        }

        public Pager<ProductViewModel> Filter( ProductFilter filter)
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
            var data = products.Skip((filter.PageIndex -1) * filter.PageItemsCount).Take( filter.PageItemsCount ).ToList();
            return new Pager<ProductViewModel>()
            {
                Count = data.Count,
                List = data,
                PageCount = products.Count() / filter.PageItemsCount,
                TotalCount = products.Count()
            };
        }

        public void AddProduct(ProductViewModel product)
        {
            var data = mapper.Map<Product>( product );
            this.context.Products.Add( data );
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

        public void DeleteProduct(int id)
        {
            var product = this.context.Products.FirstOrDefault( n => n.Id == id );
            if (product!=null)
            {
                this.context.Remove( product );
            }
        }
    }
}
