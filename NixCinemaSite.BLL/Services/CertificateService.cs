using AutoMapper;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.BLL.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;
        public CertificateService(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public IEnumerable<CertificateDTO> GetListPage()
        {
            return _mapper.Map<IEnumerable<CertificateEntity>, IEnumerable<CertificateDTO>>
                (_certificateRepository.Get());
        }

        public CertificatePageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string searchString)
        {
            CertificatePageWithPaginationDTO pageCertificate = new CertificatePageWithPaginationDTO();

            if (String.IsNullOrEmpty(searchString)) { }
            pageCertificate.TotalPages = (int)Math.Ceiling(decimal.Divide(_certificateRepository.Count(), pageCertificate.PageSize));

            if (currectPage != 0 && currectPage != null)
            {
                pageCertificate.CurrentPage = (int)currectPage;
            }

            if (currectPage >= pageCertificate.TotalPages)
            {
                pageCertificate.CurrentPage = pageCertificate.TotalPages;
            }


            if (!@String.IsNullOrEmpty(sortProperty) && sortProperty == "SortByName")
            {
                pageCertificate.NameSort = "SortByNameDesc";
            }
            else
            {
                pageCertificate.NameSort = "SortByName";
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                pageCertificate.SearchString = searchString;
            }

            var certficateCollection = _certificateRepository.GetListAfterPagination(pageCertificate.SearchString, pageCertificate.NameSort, pageCertificate.CurrentPage, pageCertificate.PageSize);

            if (!String.IsNullOrEmpty(searchString))
            {
                pageCertificate.TotalPages = (int)Math.Ceiling(decimal.Divide(certficateCollection.Count(), pageCertificate.PageSize));
            }

            pageCertificate.Certificates = _mapper.Map<IEnumerable<CertificateEntity>, IEnumerable<CertificateDTO>>(certficateCollection);

            return pageCertificate;
        }
        public CertificateDTO GetById(Guid id)
        {
            return _mapper.Map<CertificateEntity, CertificateDTO>
                (_certificateRepository.GetByID(id));
        }

        public void Create(CertificateDTO certificate)
        {
            certificate.Id = Guid.NewGuid();
            _certificateRepository.Insert
                (_mapper.Map<CertificateDTO, CertificateEntity>(certificate));
            _certificateRepository.Save();
        }
        public void Delete(Guid id)
        {
            _certificateRepository.Delete(id);
            _certificateRepository.Save();
        }
        public CertificateDTO Details(Guid id)
        {
            return _mapper.Map<CertificateEntity, CertificateDTO>
                (_certificateRepository.GetObjectWithIncludes(id));
        }
        public void Edit(CertificateDTO certificate)
        {
            _certificateRepository.Update
                (_mapper.Map<CertificateDTO, CertificateEntity>(certificate));
            _certificateRepository.Save();
        }
        public CertificateDTO Find(string input)
        {
            return _mapper.Map<CertificateEntity, CertificateDTO>
            (_certificateRepository.Get(c => c.Name == input).FirstOrDefault());
        }
    }
}
