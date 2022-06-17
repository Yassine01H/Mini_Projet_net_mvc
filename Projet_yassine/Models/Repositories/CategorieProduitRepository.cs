namespace Projet_yassine.Models.Repositories
{
    public class CategorieProduitRepository : ICategorieProduitRepository
    {
        readonly AppDbContext context;
        public CategorieProduitRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<CategorieProduit> GetAll()
        {
            return context.CategorieProduits.OrderBy(catP => catP.CategorieProduitName).ToList();
        }
        public CategorieProduit GetById(int id)
        {
            return context.CategorieProduits.Find(id);
        }
        public void Add(CategorieProduit catP)
        {
            context.CategorieProduits.Add(catP);
            context.SaveChanges();
        }
        public void Edit(CategorieProduit catP)
        {
            CategorieProduit catP1 = context.CategorieProduits.Find(catP.CategorieProduitID);
            if (catP1 != null)
            {
                catP1.CategorieProduitName = catP.CategorieProduitName;
                context.SaveChanges();
            }
        }
        public void Delete(CategorieProduit catP)
        {
            CategorieProduit catP1 = context.CategorieProduits.Find(catP.CategorieProduitID);
            if (catP1 != null)
            {
                context.CategorieProduits.Remove(catP1);
                context.SaveChanges();
            }
        }

        public int ProduitCount(int categorieProduitID)
        {
            return context.Produits.Where(s => s.CategorieProduitID ==
            categorieProduitID).Count();
        }
    }
}
