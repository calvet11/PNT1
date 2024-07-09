using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;

namespace ProyectoFinal
{
    public class Program // conectamos con los del json
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AutoServicioDatabaseContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString:AutoServicioDBConnection"]));


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default", //ruta por omision
                pattern: "{controller=Home}/{action=Index}/{id?}");// la view por defecto 

            app.Run();
        }
    }
}