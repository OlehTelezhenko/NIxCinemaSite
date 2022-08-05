using AutoMapper;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public IEnumerable<PersonDTO> GetListPage()
        {
            var a = _personRepository.Get();
            var b = _mapper.Map<IEnumerable<PersonEntity>, IEnumerable<PersonDTO>>(a);
            return b;
        }

        public PersonPageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string? searchString)
        {
            PersonPageWithPaginationDTO pagePerson = new PersonPageWithPaginationDTO();

            if (String.IsNullOrEmpty(searchString))
            {
                pagePerson.TotalPages = (int)Math.Ceiling(decimal.Divide(_personRepository.Count(), pagePerson.PageSize));
            }

            if (currectPage != 0 && currectPage != null)
            {
                pagePerson.CurrentPage = (int)currectPage;
            }

            if (currectPage >= pagePerson.TotalPages)
            {
                pagePerson.CurrentPage = pagePerson.TotalPages;
            }

            if (!@String.IsNullOrEmpty(sortProperty) && sortProperty == "SortByName")
            {
                pagePerson.FirstNameSort = "SortByNameDesc"; 
            }
            else
            {
                pagePerson.FirstNameSort = "SortByName";
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                pagePerson.SearchString = searchString;
            }

            var personCollection = _personRepository.GetListAfterPagination(pagePerson.SearchString, pagePerson.FirstNameSort, pagePerson.CurrentPage, pagePerson.PageSize);

            if (!String.IsNullOrEmpty(searchString))
            {
                pagePerson.TotalPages = (int)Math.Ceiling(decimal.Divide(personCollection.Count(), pagePerson.PageSize));
            }

            pagePerson.Persons = _mapper.Map<IEnumerable<PersonEntity>, IEnumerable<PersonDTO>>(personCollection);

            return pagePerson;
        }

        public PersonDTO GetById(Guid id)
        {
            return _mapper.Map<PersonEntity, PersonDTO>
                (_personRepository.GetByID(id));
        }

        public void Create(PersonDTO genre)
        {
            genre.Id = Guid.NewGuid();
            _personRepository.Insert
                (_mapper.Map<PersonDTO, PersonEntity>(genre));
            _personRepository.Save();
        }
        public void Delete(Guid id)
        {
            _personRepository.Delete(id);
            _personRepository.Save();
        }
        public PersonDTO Details(Guid id)
        {
            var a = _mapper.Map<PersonEntity, PersonDTO>
                (_personRepository.GetObjectWithIncludes(id));
            return a;

        }
        public void Edit(PersonDTO genre)
        {
            _personRepository.Update
                (_mapper.Map<PersonDTO, PersonEntity>(genre));
            _personRepository.Save();
        }
        public PersonDTO Find(string input)
        {
            var SearchResult = _mapper.Map<PersonEntity, PersonDTO>
            (_personRepository.Get(c => c.FirstName == input).FirstOrDefault());
            if (SearchResult == null)
            {
                return _mapper.Map<PersonEntity, PersonDTO>
            (_personRepository.Get(c => c.LastName == input).FirstOrDefault());
            }
            return SearchResult;
        }
    }
}
