﻿using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.GenericRepository;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface IFilmRepository : IGenericRepository<FilmEntity>
    {
        public FilmEntity GetObjectWithIncludes(Guid Id);
        public List<FilmEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize);
    }
}