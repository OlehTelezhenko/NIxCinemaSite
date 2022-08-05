using AutoMapper;
using NixCinemaSite.BLL.ModelsDTO;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Entities.Identity;

namespace NixCinemaSite.BLL.AutoMapper
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateBLLMapping();
        }

        private void CreateBLLMapping()
        {
            CreateMap<CertificateDTO, CertificateEntity>().ReverseMap();
            CreateMap<CountryDTO, CountryEntity>().ReverseMap();
            CreateMap<GenreDTO, GenreEntity>().ReverseMap();
            CreateMap<MediaDTO, MediaEntity>().ReverseMap();
            CreateMap<PersonDTO, PersonEntity>().ReverseMap();
            CreateMap<FilmToPersonEntity, FilmToPersonDTO>().ReverseMap();
            CreateMap<FilmEntity, FilmDTO>().
                ForMember(p => p.PersonsIds, opt => opt.Ignore()).
                ForMember(r => r.RolePersons, opt => opt.Ignore()).
                ForMember(g => g.GenresIds, opt => opt.Ignore()).
                ForMember(u => u.UploadFiles, opt => opt.Ignore()).
                ReverseMap();

            CreateMap<User, UserWithRolesDTO>().
                ForMember(p => p.Id, opt => opt.Ignore()).
                ForMember(p => p.UserRoles, opt => opt.Ignore()).
                ForMember(p => p.AllRoles, opt => opt.Ignore()).
                ForMember(p => p.Password, opt => opt.Ignore()).
                ForMember(p => p.PasswordConfirmed, opt => opt.Ignore()).
                ReverseMap();

        }
    }
}
