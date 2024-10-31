using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using LapShop.Models;
using Microsoft.EntityFrameworkCore;

namespace LapShop
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// ����� ��� ��� MVC
			builder.Services.AddControllersWithViews();

			// ����� DbContext
			builder.Services.AddDbContext<LapShopContext>(options =>
				options.UseSqlServer("Server=DESKTOP-NRE4E8S; Database=LapShop; Trusted_Connection=True;"));

			// ����� ����� ������
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30); // ����� ��� ������
				options.Cookie.HttpOnly = true; // ��� ������� ��� ����� ������ �� ���� ������
				options.Cookie.IsEssential = true; // ���� ������ ����� �� ��� ��� �������� ��� ������
			});

			var app = builder.Build();

			// ����� ���������
			app.UseRouting(); // ���� �� �� ��� �� �����

			// ������� ������� ��� ������ �� ��������
			app.UseSession(); // ���� �� �� ��� ���� ��� UseAuthentication �UseAuthorization

			app.UseAuthentication(); // ���� �� ��� ���� ��� ��� ���� ���� ��
			app.UseAuthorization(); // ���� �� ��� ���� ��� ��� ���� ���� ��
			app.UseStaticFiles();

			// ����� ���� �������
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "admin",
					pattern: "{area:exists}/{controller=Home}/{action=Index}");

				endpoints.MapControllerRoute(
					name: "LandingPages",
					pattern: "{area:exists}/{controller=Home}/{action=Index}");

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "ali",
					pattern: "ali/{controller=Home}/{action=Index}/{id?}");
			});

			app.Run();
		}
	}
}
