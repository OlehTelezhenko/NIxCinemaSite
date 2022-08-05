using NixCinemaSite.BLL.AutoMapper;
using NixCinemaSite.BLL.Helpers;

//Для заполнения ролями/юзерами
//using Microsoft.AspNetCore.Identity;
//using NixCinemaSite.DAL.Entities.Identity;
//using NixCinemaSite.DAL.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// TODO Методы расширения https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
// https://stackoverflow.com/questions/70472624/dotnet-6-how-to-create-class-library-for-service-extensions
builder.Services.RegisterBL(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//Заполнение юзер/роль для идентити

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var userManager = services.GetRequiredService<UserManager<User>>();
//    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//    await RoleInitializer.InitializeAsync(userManager, rolesManager);
//}

app.MapControllerRoute(
    name: "AreaRoute",
    pattern: "{area:exists}/{controller}/{action}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
