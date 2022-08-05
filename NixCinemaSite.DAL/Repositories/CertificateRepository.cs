using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.DAL.Repositories
{

    public class CertificateRepository : GenericRepository<CertificateEntity>, ICertificateRepository
    {
        private readonly CinemaDbContext _context;
        public CertificateRepository(CinemaDbContext context) : base(context)
        {
            _context = context;
        }

        public CertificateEntity GetObjectWithIncludes(Guid Id)
        {
            CertificateEntity? certificate = _context.Certificates
                .Where(c => c.Id == Id)
                .Include(c => c.Films)
                .FirstOrDefault();
            return certificate!;
        }

        public List<CertificateEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize)
        {
            IQueryable<CertificateEntity> certificateIQuery = _context.Certificates;

            if (!String.IsNullOrEmpty(searchString))
            {
                certificateIQuery = certificateIQuery.Where(c => c.Name.Contains(searchString));
            }
            // TODO снова сортировка
            switch (sortProperties)
            {
                case "SortByName":
                    certificateIQuery = certificateIQuery.OrderByDescending(s => s.Name);
                    break;
                default:
                    certificateIQuery = certificateIQuery.OrderBy(s => s.Name);
                    break;
            }

            if (currectPage > 1)
            {
                certificateIQuery = certificateIQuery.Skip((currectPage - 1) * pageSize).Take(pageSize);
            }
            else
            {
                certificateIQuery = certificateIQuery.Take(pageSize);
            }

            var a = certificateIQuery.AsNoTracking().ToList();
            return a;
        }
    }
}