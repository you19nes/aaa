using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aaa.Models
{
    [Table("AttestionDeCesseison", Schema = "dbo")]
    public class AttestionDeCesseison
    {
        [Key]
        
        public int AttestionDeCesseisonId { get; set; }
        [ForeignKey("Dossier")]
        public int DossierId { get; set; }
        public virtual Dossier Dossier { get; private set; }
        [Display(Name = "Nom ET Prenom")]
        [Required(ErrorMessage = "Enter Nom ET Prenom")]
        [StringLength(150)]
        public string Nom_ET_Prenom { get; set; }
        [Display(Name = "Raison Sociale")]
        [Required(ErrorMessage = "Enter Raison Sociale")]
        public string RaisonSociale { get; set; }
        public string Adresse { get; set; }
        [Display(Name = "Numero Dassurance")]
        [Required(ErrorMessage = "Enter Numero Dassurance courecte")]
        [Column(TypeName = "numeric(12)")]
        public short NDassurance { get; set; }
        [Display(Name = "Dete Naissance")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Dete Naissance")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime Date { get; set; }
    }
}
