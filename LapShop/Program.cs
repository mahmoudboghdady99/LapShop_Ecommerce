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

			// ≈÷«›… œ⁄„ «·‹ MVC
			builder.Services.AddControllersWithViews();

			// ≈÷«›… DbContext
			builder.Services.AddDbContext<LapShopContext>(options =>
				options.UseSqlServer("Server=DESKTOP-NRE4E8S; Database=LapShop; Trusted_Connection=True;"));

			// ≈÷«›… Œœ„«  «·Ã·”…
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30); //  ⁄ÌÌ‰ „œ… «·Ã·”…
				options.Cookie.HttpOnly = true; // Ã⁄· «·ﬂÊﬂÌ“ €Ì— ﬁ«»·… ··Ê’Ê· „‰ Ã«›« ”ﬂ—Ì» 
				options.Cookie.IsEssential = true; // ·Ã⁄· «·Ã·”… „ «Õ… ›Ì Õ«· ﬂ«‰ «·„” Œœ„ €Ì— „ ›«⁄·
			});

			var app = builder.Build();

			// ≈⁄œ«œ «· ÊÃÌÂ« 
			app.UseRouting(); //  √ﬂœ „‰ √‰ Â–« ÂÊ «·√Ê·

			// «” Œœ«„ «·Ã·”«  ﬁ»· «· Õﬁﬁ „‰ «·„’«œﬁ…
			app.UseSession(); //  √ﬂœ „‰ √‰ Â–« Ì√ Ì ﬁ»· UseAuthentication ÊUseAuthorization

			app.UseAuthentication(); //  √ﬂœ „‰ √‰Â Ì⁄„· ≈–« ﬂ«‰ Â‰«ﬂ Õ«Ã… ·Â
			app.UseAuthorization(); //  √ﬂœ „‰ √‰Â Ì⁄„· ≈–« ﬂ«‰ Â‰«ﬂ Õ«Ã… ·Â
			app.UseStaticFiles();

			// ≈⁄œ«œ ‰ﬁ«ÿ «·‰Â«Ì…
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
