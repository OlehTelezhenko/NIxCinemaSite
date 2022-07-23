﻿using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.GenericRepository;

namespace NixCinemaSite.DAL.Interfaces
{
    public interface IGenreRepository : IGenericRepository<GenreEntity>
    {
        public GenreEntity GetObjectWithIncludes(Guid Id);
        public List<GenreEntity> GetListAfterPagination(string searchString, string sortProperties, int currectPage, int pageSize);
    }
}