using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aaa.Models
{


    public class Dossier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DossierId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter Le Name")]
        [StringLength(150)]
        public string EmployeeName { get; set; }
        [Display(Name = "Prenom")]
        [Required(ErrorMessage = "Enter Le Prenom")]
        [StringLength(150)]
        public string EmployeePrenom { get; set; }
        [Display(Name = "Dete Naissance")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter La Dete Naissance")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime DeteNaissance { get; set; }
        [Display(Name = "Adresse de naissence")]
        [Required(ErrorMessage = "Enter La Adresse de naissence")]
        public string Adressedenaissence { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter La Address")]
        public string Address { get; set; }
        [Display(Name = "Wilaya de Naissance")]
        [Required(ErrorMessage = "Enter Le Wilaya de Naissance")]
        public string NaissanceWilaya { get; set; }

        [Display(Name = "Titre de civilite")]
        [Required(ErrorMessage = "Enter Le Titre de civilite")]
        public string Titredecivilite { get; set; }

        [Display(Name = "L'employeur soussigné")]
        [Required(ErrorMessage = "Enter L'employeur soussigné")]
        public string Lemployeursoussigné { get; set; }

        [Display(Name = "N°S S EMPLOYEUR")]
        [Required(ErrorMessage = "Enter Le N°S S EMPLOYEUR")]
        public string NSSEMPLOYEUR { get; set; }

        [Display(Name = "N°A S ASSURE")]
        [Required(ErrorMessage = "Enter Le N°A S ASSURE")]
        public string NASASSURE { get; set; }
        [Display(Name = "Qualite")]
        [Required(ErrorMessage = "Enter LA Qualite")]
        public string Qualite { get; set; }
        [Display(Name = "Numero Allocation Familailes")]
        [Required(ErrorMessage = "Enter Le Numero Allocation Familailes")]
        [Column(TypeName = "varchar(12)")]
        [MaxLength(12)]
        public string NumeroAllocationFamilailes { get; set; }
        [Display(Name = "Numero Allocation Assure")]
        [Required(ErrorMessage = "Enter Le Numero Allocation Assur")]
        [Column(TypeName = "varchar(12)")]
        [MaxLength(12)]
        public string NumeroAllocationAssure { get; set; }
        [Display(Name = "Numero Sociales Assure")]
        [Required(ErrorMessage = "Enter Le Numero Sociales Assuree")]
        [Column(TypeName = "varchar(12)")]
        [MaxLength(12)]
        public string NumeroSocialesFamilailes { get; set; }
        [Display(Name = "Numero Sociales Familailes")]
        [Required(ErrorMessage = "Enter Le Numero Sociales Familailes")]
        [Column(TypeName = "varchar(12)")]
        [MaxLength(12)]
        public string NumeroSocialesAssure { get; set; }
        [Display(Name = "Dubut Travail")]
        [Required(ErrorMessage = "Enter La Dubut Travail")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime DubutTravail { get; set; }
        [Display(Name = "Fin Travail")]
        [Required(ErrorMessage = "Enter La Fin Travail")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime FinTravail { get; set; }

        [Display(Name = "الإسم")]
        [Required(ErrorMessage = "Enter الإسم")]
        public string nom { get; set; }
        [Display(Name = "اللقب")]
        [Required(ErrorMessage = "Enter اللقب")]
        public string pre { get; set; }
        [Display(Name = "الإسم الكامل للاب")]
        
        public string ParronPere { get; set; }
        [Display(Name = "الإسم الكامل للام")]
        
        public string Parronmere { get; set; }
        [Display(Name = "مكان الميلاد")]
        [Required(ErrorMessage = "Enter مكان الميلاد")]
        public string makan { get; set; }
        [Display(Name = "ولاية الميلاد")]
        [Required(ErrorMessage = "Enter ولاية الميلاد")]
        public string wilaia { get; set; }

        [Display(Name = "المهنة")]
        [Required(ErrorMessage = "Enter المهنة")]
        public string mihna { get; set; }
        
        [Display(Name = "العنوان")]
        [Required(ErrorMessage = "Enter العنوان")]
        public string onwan { get; set; }
        
        [Display(Name = "الصفة")]
        [Required(ErrorMessage = "Enter الصفة")]
        public string safha { get; set; }
        
        public string Etat { get; set; }
        public virtual List<AttestionTravail> AttestionTravails { get; set; } = new List<AttestionTravail>();
        public virtual List<AttestionDeSalaire> AttestionDeSalaires { get; set; } = new List<AttestionDeSalaire>();
        public virtual List<AttestionDeCesseison> AttestionDeCesseisons { get; set; } = new List<AttestionDeCesseison>();
        }
   
}

