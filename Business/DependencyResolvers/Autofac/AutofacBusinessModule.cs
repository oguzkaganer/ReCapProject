﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			#region Car
			builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
			builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
			#endregion

			#region Brand
			builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
			builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
			#endregion

			#region Color
			builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
			builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
			#endregion

			#region User
			builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
			builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
			#endregion

			#region Customer
			builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
			builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
			#endregion

			#region Rental
			builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
			builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
			#endregion

			#region CarImage
			builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
			builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
			#endregion

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();
		}
	}
}
