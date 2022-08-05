using AutoMapper;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public IEnumerable<GenreDTO> GetListPage()
        {
            return _mapper.Map<IEnumerable<GenreEntity>, IEnumerable<GenreDTO>>
               (_genreRepository.Get());
        }

        public GenrePageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string searchString)
        {
            GenrePageWithPaginationDTO pageGenre = new GenrePageWithPaginationDTO();

            if (String.IsNullOrEmpty(searchString)) { }
            pageGenre.TotalPages = (int)Math.Ceiling(decimal.Divide(_genreRepository.Count(), pageGenre.PageSize));

            if (currectPage != 0 && currectPage != null)
            {
                pageGenre.CurrentPage = (int)currectPage;
            }

            if (currectPage >= pageGenre.TotalPages)
            {
                pageGenre.CurrentPage = pageGenre.TotalPages;
            }


            if (!@String.IsNullOrEmpty(sortProperty) && sortProperty == "SortByName")
            {
                pageGenre.NameSort = "SortByNameDesc"; 
            }
            else
            {
                pageGenre.NameSort = "SortByName";
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                pageGenre.SearchString = searchString;
            }

            var genreCollection = _genreRepository.GetListAfterPagination(pageGenre.SearchString, pageGenre.NameSort, pageGenre.CurrentPage, pageGenre.PageSize);

            if (!String.IsNullOrEmpty(searchString))
            {
                pageGenre.TotalPages = (int)Math.Ceiling(decimal.Divide(genreCollection.Count(), pageGenre.PageSize));
            }

            pageGenre.Genres = _mapper.Map<IEnumerable<GenreEntity>, IEnumerable<GenreDTO>>(genreCollection);

            return pageGenre;
        }

        public GenreDTO GetById(Guid id)
        {
            return _mapper.Map<GenreEntity, GenreDTO>
                (_genreRepository.GetByID(id));
        }

        public void Create(GenreDTO genre)
        {
            genre.Id = Guid.NewGuid();
            _genreRepository.Insert
                (_mapper.Map<GenreDTO, GenreEntity>(genre));
            _genreRepository.Save();
        }
        public void Delete(Guid id)
        {
            _genreRepository.Delete(id);
            _genreRepository.Save();
        }
        public GenreDTO Details(Guid id)
        {
            return _mapper.Map<GenreEntity, GenreDTO>
                (_genreRepository.GetObjectWithIncludes(id));
        }
        public void Edit(GenreDTO genre)
        {
            _genreRepository.Update
                (_mapper.Map<GenreDTO, GenreEntity>(genre));
            _genreRepository.Save();
        }
        public GenreDTO Find(string input)
        {
            return _mapper.Map<GenreEntity, GenreDTO>
            (_genreRepository.Get(c => c.Name == input).FirstOrDefault());
        }
    }
}
