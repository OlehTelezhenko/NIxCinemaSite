using AutoMapper;
using NixCinemaSite.BLL.Intefaces;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Interfaces;

namespace NixCinemaSite.BLL.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;
        public MediaService(IMediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        public IEnumerable<MediaDTO> GetListPage()
        {
            var mediaList = _mediaRepository.Get();
            return _mapper.Map<IEnumerable<MediaEntity>, IEnumerable<MediaDTO>>(mediaList);
        }

        public MediaPageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string? searchString)
        {
            MediaPageWithPaginationDTO pageMedia = new MediaPageWithPaginationDTO();

            if (String.IsNullOrEmpty(searchString))
            {
                pageMedia.TotalPages = (int)Math.Ceiling(decimal.Divide(_mediaRepository.Count(), pageMedia.PageSize));
            }

            if (currectPage != 0 && currectPage != null)
            {
                pageMedia.CurrentPage = (int)currectPage;
            }

            if (currectPage >= pageMedia.TotalPages)
            {
                pageMedia.CurrentPage = pageMedia.TotalPages;
            }


            if (!@String.IsNullOrEmpty(sortProperty) && sortProperty == "SortByName")
            {
                pageMedia.NameSort = "SortByNameDesc"; 
            }
            else
            {
                pageMedia.NameSort = "SortByName";
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                pageMedia.SearchString = searchString;
            }

            var mediaCollection = _mediaRepository.GetListAfterPagination(pageMedia.SearchString, pageMedia.NameSort, pageMedia.CurrentPage, pageMedia.PageSize);

            if (!String.IsNullOrEmpty(searchString))
            {
                pageMedia.TotalPages = (int)Math.Ceiling(decimal.Divide(mediaCollection.Count(), pageMedia.PageSize));
            }
            pageMedia.Medias = _mapper.Map<IEnumerable<MediaEntity>, IEnumerable<MediaDTO>>(mediaCollection);

            return pageMedia;
        }

        public MediaDTO GetById(Guid id)
        {
            return _mapper.Map<MediaEntity, MediaDTO>
                (_mediaRepository.GetByID(id));
        }

        public void Create(MediaDTO media)
        {
            media.Id = Guid.NewGuid();
            var a = _mapper.Map<MediaDTO, MediaEntity>(media);
            _mediaRepository.Insert(a);
            _mediaRepository.Save();
        }
        public void Delete(Guid id)
        {
            _mediaRepository.Delete(id);
            _mediaRepository.Save();
        }
        public MediaDTO Details(Guid id)
        {
            return _mapper.Map<MediaEntity, MediaDTO>
                (_mediaRepository.GetObjectWithIncludes(id));
        }
        public void Edit(MediaDTO media)
        {
            _mediaRepository.Update
                (_mapper.Map<MediaDTO, MediaEntity>(media));
            _mediaRepository.Save();
        }


    }
}
