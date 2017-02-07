using AspNetCoreAngular2.EF;
using AspNetCoreAngular2.Repositories;
using Autofac;

namespace AspNetCoreAngular2
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainDBContext>().AsSelf();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
           // builder.RegisterType<ShipmentRepository>().As<IShipmentRepository>();
           // builder.RegisterType<HttpContextHelper>().AsSelf();
        }
    }
}