using ShortLink.IoC;

var builder = WebApplication.CreateBuilder(args);

#region services

builder.Services.AddControllersWithViews();






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





