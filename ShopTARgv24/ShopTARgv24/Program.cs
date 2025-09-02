using ShopTARgv24.Controllers;
using Microsoft.EntityFrameworkCore;


namespace ShopTARgv24
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Подключение контроллеров и представлений
            builder.Services.AddControllersWithViews();

            // Подключение DbContext с SQL Server
            builder.Services.AddDbContext<ShopTARgv24Context>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Обработка ошибок и HTTPS
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Не забудь для CSS, JS и т.д.

            app.UseRouting();

            app.UseAuthorization();

            // Настройка маршрутов
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
