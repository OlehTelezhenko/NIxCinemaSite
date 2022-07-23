using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NixCinemaSite.BLL.AutoMapper;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.Services;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.GenericRepository;
using NixCinemaSite.DAL.IdentityEntities;
using NixCinemaSite.DAL.Interfaces;
using NixCinemaSite.DAL.Repositories;
//using NixCinemaSite.DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<CinemaDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICertificateRepository, CertificateRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IFilmRepository, FilmRepository>();
builder.Services.AddTransient<IFilmToPersonRepository, FilmToPersonRepository>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IMediaRepository, MediaRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();

builder.Services.AddTransient<IPresentationCertificateService, PresentationCertificateService>();
builder.Services.AddTransient<IPresentationCountryService, PresentationCountryService>();
builder.Services.AddTransient<IPresentationFilmService, PresentationFilmService>();
builder.Services.AddTransient<IPresentationGenreService, PresentationGenreService>();
builder.Services.AddTransient<IPresentationMediaService, PresentationMediaService>();
builder.Services.AddTransient<IPresentationPersonService, PresentationPersonService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
