using System.ComponentModel.DataAnnotations;

namespace Projet_yassine.Models
{
    public class Produit
    {
        public int ProduitID { get; set; }
        [Required]
        public string ProduitName { get; set; }
        public string ProduitDesignation { get; set; }
        public string ProduitColeur { get; set; }
        public double ProduitPrix { get; set; }
        public int ProduitQteStock { get; set; }
        public double ProduitPoids { get; set; }
        public double ProduitTaille { get; set; }
        public int CategorieProduitID { get; set; }
        public CategorieProduit CategorieProduit { get; set; }
        public int FournisseurID { get; set; }
        public Fournisseur Fournisseur { get; set; }
    }
}
