using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WepAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Autofac Container configuration
			builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                });


			// These configurations are now done in AutofacBusinessModule (Oguz)

			// Add services to the container.
			//#region Car
			//builder.Services.AddSingleton<ICarService, CarManager>();
			//builder.Services.AddSingleton<ICarDal, EfCarDal>();
			//#endregion

			//#region Brand
			//builder.Services.AddSingleton<IBrandService, BrandManager>();
			//builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
			//#endregion

			//#region Color
			//builder.Services.AddSingleton<IColorService, ColorManager>();
			//builder.Services.AddSingleton<IColorDal,EfColorDal>();
			//#endregion

			//#region User
			//builder.Services.AddSingleton<IUserService, UserManager>();
			//builder.Services.AddSingleton<IUserDal, EfUserDal>();
			//#endregion

			//#region Customer
			//builder.Services.AddSingleton<ICustomerService, CustomerManager>();
			//builder.Services.AddSingleton<ICustomerDal,EfCustomerDal>();
			//#endregion

			//#region Rental
			//builder.Services.AddSingleton<IRentalService, RentalManager>();
			//builder.Services.AddSingleton<IRentalDal, EfRentalDal>();
			//#endregion

			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}