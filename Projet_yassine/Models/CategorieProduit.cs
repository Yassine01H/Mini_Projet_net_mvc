namespace Projet_yassine.Models
{
    public class CategorieProduit
    {
        public int CategorieProduitID { get; set; }
        public string CategorieProduitName { get; set; }
        public ICollection<Produit> Produits { get; set; }
    }
}
