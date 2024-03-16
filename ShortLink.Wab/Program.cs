using Microsoft.EntityFrameworkCore;
using ShortLink.Infra.Data.Context;
using ShortLink.IoC;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

#region services

builder.Services.AddControllersWithViews();

#region dbcontext

builder.Services.AddDbContext<ShortLinkDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShortLinkSqlConnection"));
});

#endregion


#region Encode

builder.Services.AddSingleton<HtmlEncoder>(
    HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

#endregion

#region registerdependencies

DependencyContainer.RegisterService(builder.Services);

#endregion

#endregion


#region middlevares

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

#endregion





