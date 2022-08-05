using System.ComponentModel;

namespace NixCinemaSite.BLL.ModelsDTO
{
    public class CertificatePageWithPaginationDTO : BasePaginationDTO
    {
        public string NameSort { get; set; }
        [DisplayName("Сертіфікат")]
        public IEnumerable<CertificateDTO> Certificates { get; set; }
    }
}
