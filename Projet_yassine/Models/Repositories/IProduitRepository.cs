namespace Projet_yassine.Models.Repositories
{
    public interface IProduitRepository
    {
        IList<Produit> GetAll();
        Produit GetById(int id);
        void Add(Produit p);
        void Edit(Produit p);
        void Delete(Produit p);
        IList<Produit> GetProduitByCategorieProduitID(int? categorieProduitID);
        IList<Produit> GetProduitByFournisseurID(int? fournisseurID);
        IList<Produit> FindByName(string name);
    }
}
