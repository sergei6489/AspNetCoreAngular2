using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAngular2.EF;
using AspNetCoreAngular2.ViewModels;
using AutoMapper;

namespace AspNetCoreAngular2
{
    public static class AutoMapper
    {
        public static MapperConfiguration configuration;
        public static IMapper Mapper;
        public static void RegisterMapper()
        {
            configuration = new MapperConfiguration( ( conf ) =>
            {
                conf.CreateMap<User, UserViewModel>();
                conf.CreateMap<Product, ProductViewModel>();
            } );
            Mapper = configuration.CreateMapper();
        }
    }
}
