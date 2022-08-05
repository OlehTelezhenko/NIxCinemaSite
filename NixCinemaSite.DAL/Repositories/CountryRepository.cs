using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.DAL.Repositories
{
    public class CountryRepository : GenericRepository<CountryEntity>, ICountryRepository
    {
        private readonly CinemaDbContext _context;
        public CountryRepository(CinemaDbContext context) : base(context)
        {
            _context = context;
        }

        public CountryEntity GetObjectWithIncludes(Guid Id)
        {
            CountryEntity? country = _context.Countries
                .Where(c => c.Id == Id)
                .Include(c => c.Films)
                .FirstOrDefault();
            return country!;
        }
        public List<CountryEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize)
        {
            IQueryable<CountryEntity> countryIQuery = _context.Countries;

            if (!String.IsNullOrEmpty(searchString))
            {
                countryIQuery = countryIQuery.Where(c => c.Name.Contains(searchString));
            }

            switch (sortProperties)
            {
                case "SortByName":
                    countryIQuery = countryIQuery.OrderByDescending(s => s.Name);
                    break;
                default:
                    countryIQuery = countryIQuery.OrderBy(s => s.Name);
                    break;
            }

            if (currectPage > 1)
            {
                countryIQuery = countryIQuery.Skip((currectPage - 1) * pageSize).Take(pageSize);
            }
            else
            {
                countryIQuery = countryIQuery.Take(pageSize);
            }

            var a = countryIQuery.AsNoTracking().ToList();
            return a;
        }

    }
}