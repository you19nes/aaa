using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aaa.Models
{
    
    public class AttestionDeSalaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttestionDeSalaireId { get; set; }
        [ForeignKey("Dossier")]
        public int DossierId { get; set; }
        public virtual Dossier Employee { get; private set; }
        [Required(ErrorMessage = "Enter Attestion De Salaire Annee")]
        [Range(1950, 2050, ErrorMessage = "Erreur,les annee aunte 1950 et 2050")]
        [DisplayName("Salaire Annee")]
        public int AttestionDeSalaireAnnee { get; set; }
        [Display(Name = "De")]
        [Required(ErrorMessage = "Enter Périondes")]
        public string PériondesD { get; set; }
        [Display(Name = "Au")]
        [Required(ErrorMessage = "Enter Périondes")]
        public string PériondesA { get; set; }
        [Display(Name = "Durée Du Travail")]
        [Required(ErrorMessage = "Enter Durée Du Travail")]
        public string DuréeDuTravail { get; set; }
        [Display(Name = "Salaire Soumis Retenue")]
        [Required(ErrorMessage = "Enter Salaire Soumis Retenue")]

        public decimal SalaireSoumisRetenue { get; set; }
        [Display(Name = "Désignation De Lemploi")]
        [Required(ErrorMessage = "Enter Désignation De Lemploi")]
        public string DésignationDeLemploi { get; set; }
        [Display(Name = "Desiguation De La Classe Dallocation")]
        [Required(ErrorMessage = "Enter Desiguation De La Classe Dallocation")]
        public string DesiguationDeLaClasseDallocation { get; set; }
        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
