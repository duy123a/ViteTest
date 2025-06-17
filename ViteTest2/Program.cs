using Microsoft.Extensions.FileProviders;
using Vite.AspNetCore;

namespace ViteTest2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddViteServices(options =>
            {
                options.Server.Port = 5173; // default is 5173 if not declared
                options.Server.AutoRun = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            if (!app.Environment.IsDevelopment())
            {
                var webRoot = Path.Combine(builder.Environment.ContentRootPath, "wwwroot");
                var dist = Path.Combine(webRoot, "dist");

                var composite = new CompositeFileProvider(
                    new PhysicalFileProvider(webRoot),
                    new PhysicalFileProvider(dist)
                );

                app.Environment.WebRootPath = dist;
                app.Environment.WebRootFileProvider = composite;
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            if (app.Environment.IsDevelopment())
            {
                app.UseViteDevelopmentServer(true);
            }

            app.Run();
        }
    }
}
