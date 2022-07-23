﻿using NixCinemaSite.BLL.ModelsDTO;

namespace NixCinemaSite.BLL.Intefaces
{
    public interface IPresentationFilmService : IPresentationService<FilmDTO>
    {
        public IEnumerable<FilmDTO> Find(string input);
        public FilmPageWithPaginationDTO GetPageAfterPagination(string? sortProperty, int? currectPage, string? searchMedias);
    }
}
