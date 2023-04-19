using Microsoft.EntityFrameworkCore;

namespace HTM.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<DAL.DataContext>(options =>
            {
                options.UseNpgsql("Server=localhost;Port=5432;Database=hockey_db;User Id=postgres;Password=w1w2w3w4");
            });

            var app = builder.Build();

            using (var scope = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IServiceScopeFactory>()?.CreateScope())
            {
                if (scope != null)
                {
                    var context = scope.ServiceProvider.GetRequiredService<DAL.DataContext>();
                    context.Database.Migrate();
                }
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}