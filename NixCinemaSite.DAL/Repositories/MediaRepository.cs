using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.DbContexts;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.DAL.Repositories
{
    public class MediaRepository : GenericRepository<MediaEntity>, IMediaRepository
    {
        private readonly CinemaDbContext _context;
        public MediaRepository(CinemaDbContext context) : base(context)
        {
            _context = context;
        }
        public MediaEntity GetObjectWithIncludes(Guid Id)
        {
            MediaEntity? media = _context.Medias
                .Where(c => c.Id == Id)
                .FirstOrDefault();
            return media!;
        }

        public List<MediaEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize)
        {
            IQueryable<MediaEntity> mediaIQuery = _context.Medias;

            if (!String.IsNullOrEmpty(searchString))
                mediaIQuery = mediaIQuery.Where(c => c.FilmTitle.Contains(searchString));

            switch (sortProperties)
            {
                case "SortByName":
                    mediaIQuery = mediaIQuery.OrderByDescending(s => s.MediaTitle);
                    break;
                default:
                    mediaIQuery = mediaIQuery.OrderBy(s => s.MediaTitle);
                    break;
            }

            if (currectPage > 1)
            {
                mediaIQuery = mediaIQuery.Skip((currectPage - 1) * pageSize).Take(pageSize);
            }
            else
            {
                mediaIQuery = mediaIQuery.Take(pageSize);
            }

            return mediaIQuery.AsNoTracking().ToList();

        }

    }
}