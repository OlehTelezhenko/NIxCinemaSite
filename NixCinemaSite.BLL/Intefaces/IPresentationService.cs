namespace NixCinemaSite.BLL.Intefaces
{
    public interface IPresentationService<TModel> where TModel : class
    {
        public IEnumerable<TModel> GetListPage();
        public TModel GetById(Guid id);
        public void Create(TModel genre);
        public void Delete(Guid id);
        public TModel Details(Guid id);
        public void Edit(TModel genre);

    }
}
