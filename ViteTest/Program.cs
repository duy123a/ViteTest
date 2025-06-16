using Microsoft.Extensions.FileProviders;
using Vite.AspNetCore;

namespace ViteTest
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
                var webRootProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot"));
                var distProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "dist"));
                var compositeProvider = new CompositeFileProvider(webRootProvider, distProvider);
                app.Environment.WebRootFileProvider = compositeProvider;
                app.Environment.WebRootPath = distProvider.Root;
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
