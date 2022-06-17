namespace Projet_yassine.Models.Repositories
{
    public class FournisseurRepository : IFournisseurRepository
    {
        readonly AppDbContext context;
        public FournisseurRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Fournisseur> GetAll()
        {
            return context.Fournisseurs.OrderBy(f => f.FournisseurName).ToList();
        }
        public Fournisseur GetById(int id)
        {
            return context.Fournisseurs.Find(id);
        }
        public void Add(Fournisseur f)
        {
            context.Fournisseurs.Add(f);
            context.SaveChanges();
        }
        public void Edit(Fournisseur f)
        {
            Fournisseur f1 = context.Fournisseurs.Find(f.FournisseurID);
            if (f1 != null)
            {
                f1.FournisseurName = f.FournisseurName;
                f1.FournisseurTel = f.FournisseurTel;
                f1.Fournisseurmail = f.Fournisseurmail;
                f1.FournisseurAddress = f.FournisseurAddress;
                context.SaveChanges();
            }
        }
        public void Delete(Fournisseur f)
        {
            Fournisseur f1 = context.Fournisseurs.Find(f.FournisseurID);
            if (f1 != null)
            {
                context.Fournisseurs.Remove(f1);
                context.SaveChanges();
            }
        }
        public int ProduitCount(int fournisseurID)
        {
            return context.Fournisseurs.Where(f => f.FournisseurID == fournisseurID).Count();
        }
    }
}
