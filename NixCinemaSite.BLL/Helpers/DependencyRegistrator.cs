using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.Services;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Entities.Identity;
using NixCinemaSite.DAL.Interfaces;
using NixCinemaSite.DAL.Repositories;

namespace NixCinemaSite.BLL.Helpers
{
    public static class DependencyRegistrator
    {
        public static void RegisterBL(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CinemaDBConnectionString");
            services.AddDbContext<CinemaDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<CinemaDbContext>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ICertificateRepository, CertificateRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmToPersonRepository, FilmToPersonRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
