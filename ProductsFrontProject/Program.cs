using Stripe;

namespace ProductsFrontProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<ProductService>();
            
            //add services dependency Injection
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
/*            app.UseEndpoints(enpoints =>
            {
                enpoints.Map("/babyShane", async context =>
                {
                    await context.Response.WriteAsync(app.Configuration["MyKey"]);
                    await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey"));
                });


            });*/
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=PersonFront}/{action=GetAllPerson}/{id?}");
            app.UseAuthentication();
            

            app.Run();
        }
    }
}
