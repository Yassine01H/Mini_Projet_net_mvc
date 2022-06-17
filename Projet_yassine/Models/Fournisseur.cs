namespace Projet_yassine.Models
{
    public class Fournisseur
    {
        public int FournisseurID { get; set; }
        public string FournisseurName { get; set; }
        public string FournisseurAddress { get; set; }
        public int FournisseurTel { get; set; }
        public string Fournisseurmail { get; set; }
        public ICollection<Produit> Produits { get; set; }
    }
}
