using Forum.Data;
using Forum.Services;
using Forum.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForumApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ForumAppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IPostService, PostService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}