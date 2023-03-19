﻿using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.File;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework;
using Module = Autofac.Module;

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
        builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
        builder.RegisterType<EfCarImagesDal>().As<ICarImagesDal>().SingleInstance();
        builder.RegisterType<FileManager>().As<IFileService>().SingleInstance();

        var assembly = Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}