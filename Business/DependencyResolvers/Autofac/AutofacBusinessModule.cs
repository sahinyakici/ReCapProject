using Autofac;
using Business.Abstract;
using Business.Concretes;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
        builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
        builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
        builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
        builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
        builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
        builder.RegisterType<CustomerManager>().As<ICustomersService>().SingleInstance();
        builder.RegisterType<EfCustomersDal>().As<ICustomersDal>().SingleInstance();
        builder.RegisterType<UserManager>().As<IUsersService>().SingleInstance();
        builder.RegisterType<EfUsersDal>().As<IUsersDal>().SingleInstance();
        builder.RegisterType<RentalsManager>().As<IRentalsService>().SingleInstance();
        builder.RegisterType<EfRentalsDal>().As<IRentalsDal>().SingleInstance();
    }
}