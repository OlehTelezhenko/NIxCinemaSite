using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.BLL.Intefaces
{
    public interface ICertificateService : IPresentationService<CertificateDTO>
    {
        public CertificateDTO Find(string input);
        public CertificatePageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string searchString);
    }
}
