//using NixCinemaSite.DAL.DbContexts;
//using NixCinemaSite.DAL.Repositories;

//namespace NixCinemaSite.DAL.UnitOfWork
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private CinemaDbContext context = new CinemaDbContext();

//        private CertificateRepository _certificateRepository;
//        private CountryRepository _countryRepository;
//        private FilmRepository _filmRepository;
//        private GenreRepository _genreRepository;
//        private MediaRepository _mediaRepository;
//        private PersonRepository _personRepository;
//        private FilmToPersonRepository _filmToPersonRepository;

//        public CertificateRepository CertificateRepository
//        {
//            get
//            {

//                if (this._certificateRepository == null)
//                {
//                    this._certificateRepository = new CertificateRepository(context);
//                }
//                return _certificateRepository;
//            }
//        }
//        public CountryRepository CountryRepository
//        {
//            get
//            {

//                if (this._countryRepository == null)
//                {
//                    this._countryRepository = new CountryRepository(context);
//                }
//                return _countryRepository;
//            }
//        }
//        public FilmRepository FilmRepository
//        {
//            get
//            {

//                if (this._filmRepository == null)
//                {
//                    this._filmRepository = new FilmRepository(context);
//                }
//                return _filmRepository;
//            }
//        }
//        public GenreRepository GenreRepository
//        {
//            get
//            {

//                if (this._genreRepository == null)
//                {
//                    this._genreRepository = new GenreRepository(context);
//                }
//                return _genreRepository;
//            }
//        }
//        public MediaRepository MediaRepository
//        {
//            get
//            {

//                if (this._mediaRepository == null)
//                {
//                    this._mediaRepository = new MediaRepository(context);
//                }
//                return _mediaRepository;
//            }
//        }
//        public PersonRepository PersonRepository
//        {
//            get
//            {

//                if (this._personRepository == null)
//                {
//                    this._personRepository = new PersonRepository(context);
//                }
//                return _personRepository;
//            }
//        }
//        public FilmToPersonRepository FilmToPersonRepository
//        {
//            get
//            {

//                if (this._filmToPersonRepository == null)
//                {
//                    this._filmToPersonRepository = new FilmToPersonRepository(context);
//                }
//                return _filmToPersonRepository;
//            }
//        }




//        public void Save()
//        {
//            context.SaveChanges();
//        }

//        private bool disposed = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    context.Dispose();
//                }
//            }
//            this.disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
//}
