using AutoMapper;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.BLL.Services
{
    public class PresentationFilmService : IPresentationFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public PresentationFilmService(IFilmRepository filmRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public IEnumerable<FilmDTO> GetListPage()
        {
            var a = _mapper.Map<IEnumerable<FilmEntity>, IEnumerable<FilmDTO>>
               (_filmRepository.Get());
            return a;
        }

        public FilmPageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string? searchString)
        {
            FilmPageWithPaginationDTO pageFilm = new FilmPageWithPaginationDTO();

            if (String.IsNullOrEmpty(searchString))
            {
                pageFilm.TotalPages = (int)Math.Ceiling(decimal.Divide(_filmRepository.Count(), pageFilm.PageSize));
            }

            if (currectPage != 0 && currectPage != null)
            {
                pageFilm.CurrentPage = (int)currectPage;
            }

            if (currectPage >= pageFilm.TotalPages)
            {
                pageFilm.CurrentPage = pageFilm.TotalPages;
            }

            if (!@String.IsNullOrEmpty(sortProperty) && sortProperty == "SortByName")
            {
                pageFilm.FilmTitleSort = "SortByNameDesc"; 
            }
            else
            {
                pageFilm.FilmTitleSort = "SortByName";
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                pageFilm.SearchString = searchString;
            }

            var filmsCollection = _filmRepository.GetListAfterPagination(pageFilm.SearchString, pageFilm.FilmTitleSort, pageFilm.CurrentPage, pageFilm.PageSize);

            if (!String.IsNullOrEmpty(searchString))
            {
                pageFilm.TotalPages = (int)Math.Ceiling(decimal.Divide(filmsCollection.Count(), pageFilm.PageSize));
            }

            pageFilm.Films = _mapper.Map<IEnumerable<FilmEntity>, IEnumerable<FilmDTO>>(filmsCollection);

            return pageFilm;
        }
        public FilmDTO GetById(Guid id)
        {

            var a = _mapper.Map<FilmEntity, FilmDTO>
            (_filmRepository.GetByID(id));
            return a;
        }

        public void Create(FilmDTO filmDTO)
        {
            filmDTO.Id = Guid.NewGuid();
            var filmEntiry = _mapper.Map<FilmDTO, FilmEntity>(filmDTO);

            if (filmDTO.GenresIds != null)
            {
                for (int i = 0; i < filmDTO.GenresIds.Length - 1; i++)
                {
                    filmEntiry.Genres.Add(
                        _genreRepository.GetByID(
                            Guid.Parse(filmDTO.GenresIds[i])));
                }
            }

            if (filmDTO.PersonsIds != null)
            {
                for (int i = 0; i < filmDTO.PersonsIds.Length - 1; i++)
                {
                    filmEntiry.FilmsToPersons.Add(new()
                    {
                        Id = Guid.NewGuid(),
                        FilmId = filmDTO.Id,
                        Role = filmDTO.RolePersons[i],
                        PersonId = Guid.Parse(filmDTO.PersonsIds[i])
                    });
                }
            }

            _filmRepository.Insert(filmEntiry);
            _filmRepository.Save();

        }
        public void Delete(Guid id)
        {
            _filmRepository.Delete(id);
            _filmRepository.Save();
        }
        public FilmDTO Details(Guid id)
        {
            return _mapper.Map<FilmEntity, FilmDTO>
                (_filmRepository.GetObjectWithIncludes(id));
        }
        public void Edit(FilmDTO film)
        {
            _filmRepository.Update
                (_mapper.Map<FilmDTO, FilmEntity>(film));
            _filmRepository.Save();
        }
        public IEnumerable<FilmDTO> Find(string input)
        {
            return _mapper.Map<IEnumerable<FilmEntity>, IEnumerable<FilmDTO>>(
                _filmRepository.Get(t => t.Title == input));
        }
    }
}
