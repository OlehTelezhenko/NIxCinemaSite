using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.GenericRepository;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.DAL.Repositories
{
    public class PersonRepository : GenericRepository<PersonEntity>, IPersonRepository
    {
        private readonly CinemaDbContext _context;
        public PersonRepository(CinemaDbContext context) : base(context)
        {
            _context = context;
        }

        public PersonEntity GetObjectWithIncludes(Guid Id)
        {
            PersonEntity? person = _context.Persons
                .Where(c => c.Id == Id)
                .Include(c => c.FilmsToPersons)
                .ThenInclude(c => c.Film)
                .FirstOrDefault();
            return person!;
        }

        public List<PersonEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize)
        {

            IQueryable<PersonEntity> personIQuery = _context.Persons;

            if (!String.IsNullOrEmpty(searchString))
            {
                var splitSearchString = searchString.Split(' ', '	');
                foreach (var item in splitSearchString)
                {
                    personIQuery = personIQuery.Where(
                    l => l.FirstName.Contains(item) ||
                    l.LastName.Contains(item));
                }
            }

            switch (sortProperties)
            {
                case "SortByName":
                    personIQuery = personIQuery.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    personIQuery = personIQuery.OrderBy(s => s.FirstName);
                    break;
            }

            if (currectPage > 1)
            {
                personIQuery = personIQuery.Skip((currectPage - 1) * pageSize).Take(pageSize);
            }
            else
            {
                personIQuery = personIQuery.Take(pageSize);
            }

            return personIQuery.AsNoTracking().ToList();
        }

    }
}