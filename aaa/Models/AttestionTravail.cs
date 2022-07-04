using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aaa.Models
{
   
    public class AttestionTravail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttestionTravailId { get; set; }
        [ForeignKey("Dossier")]
        public int DossierId { get; set; }
        public virtual Dossier Dossier { get; private set; }
        [Display(Name = "Periode Reference")]
        [Required(ErrorMessage = "Enter La Periode Reference")]
        public string PeriodeReference { get; set; }
        [Display(Name = "Salaire Soumis Cotisation")]
        [Required(ErrorMessage = "Enter Salaire Soumis Cotisation")]
        public decimal SalaireSoumisCotisation { get; set; }
        [NotMapped]
        public bool IsDeleted { get; set; } = false;

    }
}
