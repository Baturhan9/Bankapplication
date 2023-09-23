using MyOwnBank.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{ 
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation(); // compilation razor in realtime
    string connection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<MyDbContext>(options => 
        options.UseMySql(connection,ServerVersion.AutoDetect(connection)));
}

var app = builder.Build();
{
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
        pattern: "{controller=Bank}/{action=Index}/{id?}");

    app.Run();

}
