namespace Projet_yassine.Models.Repositories
{
    public interface ICategorieProduitRepository
    {
        IList<CategorieProduit> GetAll();
        CategorieProduit GetById(int id);
        void Add(CategorieProduit catP);
        void Edit(CategorieProduit catP);
        void Delete(CategorieProduit catP);
        int ProduitCount(int categorieProduitID);
    }
}
