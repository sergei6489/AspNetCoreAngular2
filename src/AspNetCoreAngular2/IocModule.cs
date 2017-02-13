using AspNetCoreAngular2.EF;
using AspNetCoreAngular2.Repositories;
using Autofac;
using AutoMapper;

namespace AspNetCoreAngular2
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainDBContext>().AsSelf();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.Register<IMapper>( c => AutoMapper.Mapper );
        }
    }
}