using Microsoft.EntityFrameworkCore;

namespace Projet_yassine.Models.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        readonly AppDbContext context;
        public ProduitRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Produit> GetAll()
        {
            return context.Produits.OrderBy(x => x.ProduitName).Include(x => x.CategorieProduit).ToList();
        }
        public Produit GetById(int id)
        {
            return context.Produits.Where(x => x.ProduitID == id).Include(x => x.CategorieProduit).SingleOrDefault();
        }
        public void Add(Produit P)
        {
            context.Produits.Add(P);
            context.SaveChanges();
        }
        public void Edit(Produit P)
        {
            Produit P1 = context.Produits.Find(P.ProduitID);
            if (P1 != null)
            {
                P1.ProduitName = P.ProduitName;
                P1.ProduitDesignation = P.ProduitDesignation;
                P1.ProduitColeur = P.ProduitColeur;
                P1.ProduitPoids = P.ProduitPoids;
                P1.ProduitPrix = P.ProduitPrix;
                P1.ProduitQteStock = P.ProduitQteStock;
                P1.ProduitTaille = P.ProduitTaille;
                P1.FournisseurID = P.FournisseurID;
                P1.CategorieProduitID = P.CategorieProduitID;
                context.SaveChanges();
            }
        }
        public void Delete(Produit P)
        {
            Produit P1 = context.Produits.Find(P.ProduitID);
            if (P1 != null)
            {
                context.Produits.Remove(P1);
                context.SaveChanges();
            }
        }

        public  IList<Produit> GetProduitByCategorieProduitID(int? categorieProduitID) 
        {
            return context.Produits.Where(f =>
           f.CategorieProduitID.Equals(categorieProduitID)).OrderBy(f => f.ProduitName)
           .Include(std => std.CategorieProduit).ToList();
        }
        public IList<Produit> GetProduitByFournisseurID(int? fournisseurID)
        {
            return context.Produits.Where(f =>
            f.FournisseurID.Equals(fournisseurID)).OrderBy(f => f.ProduitName)
            .Include(std => std.Fournisseur).ToList();
        }

        public IList<Produit> FindByName(string name)
        {
            return context.Produits.Where(catP =>
            catP.ProduitName.Contains(name)).Include(P => P.CategorieProduit).ToList();
        }

    

    }
}
