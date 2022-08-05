using AutoMapper;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.BLL.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CountryDTO> GetListPage()
        {
            return _mapper.Map<IEnumerable<CountryEntity>, IEnumerable<CountryDTO>>
                (_countryRepository.Get());
        }

        public CountryPageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string searchString)
        {
            CountryPageWithPaginationDTO pageCountry = new CountryPageWithPaginationDTO();

            if (String.IsNullOrEmpty(searchString)) { }
            pageCountry.TotalPages = (int)Math.Ceiling(decimal.Divide(_countryRepository.Count(), pageCountry.PageSize));

            if (currectPage != 0 && currectPage != null)
            {
                pageCountry.CurrentPage = (int)currectPage;
            }

            if (currectPage >= pageCountry.TotalPages)
            {
                pageCountry.CurrentPage = pageCountry.TotalPages;
            }


            if (!@String.IsNullOrEmpty(sortProperty) && sortProperty == "SortByName")
            {
                pageCountry.NameSort = "SortByNameDesc";
            }
            else
            {
                pageCountry.NameSort = "SortByName";
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                pageCountry.SearchString = searchString;
            }

            var CountryCollection = _countryRepository.GetListAfterPagination(pageCountry.SearchString, pageCountry.NameSort, pageCountry.CurrentPage, pageCountry.PageSize);

            if (!String.IsNullOrEmpty(searchString))
            {
                pageCountry.TotalPages = (int)Math.Ceiling(decimal.Divide(CountryCollection.Count(), pageCountry.PageSize));
            }

            pageCountry.Countries = _mapper.Map<IEnumerable<CountryEntity>, IEnumerable<CountryDTO>>(CountryCollection);

            return pageCountry;
        }

        public CountryDTO GetById(Guid id)
        {
            return _mapper.Map<CountryEntity, CountryDTO>
                (_countryRepository.GetByID(id));
        }

        public void Create(CountryDTO country)
        {
            country.Id = Guid.NewGuid();
            _countryRepository.Insert
                (_mapper.Map<CountryDTO, CountryEntity>(country));
            _countryRepository.Save();
        }

        public void Delete(Guid id)
        {
            _countryRepository.Delete(id);
            _countryRepository.Save();
        }

        public CountryDTO Details(Guid id)
        {
            return _mapper.Map<CountryEntity, CountryDTO>
                (_countryRepository.GetObjectWithIncludes(id));
        }

        public void Edit(CountryDTO country)
        {
            _countryRepository.Update
                (_mapper.Map<CountryDTO, CountryEntity>(country));
            _countryRepository.Save();
        }

        public CountryDTO Find(string input)
        {
            var a = _mapper.Map<CountryEntity, CountryDTO>
           (_countryRepository.Get(c => c.Name == input).FirstOrDefault());
            return a;
        }
    }
}
