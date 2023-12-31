using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tp5_LINQ.Models
{
    public class Voiture
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Marque")]
        [StringLength(20,MinimumLength =3)]
        [Required] 
        public string Marque { get; set; }

        [DisplayName("Model")]
        [StringLength(20, MinimumLength = 4)]
        [Required]
        public string? Model { get; set;}

        [DisplayName("Type")]
        [Required]
        public string Type { get; set;}

        [DisplayName("Annee d'immatriculation")]
        [Required]
        public DateTime AnneeImmatriculation { get; set;}

        [DisplayName("Kilometrage")]
        [Required]
        public int Kilometrage { get; set;}
}
}
