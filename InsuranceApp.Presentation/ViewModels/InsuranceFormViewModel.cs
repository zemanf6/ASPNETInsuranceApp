using InsuranceApp.Presentation.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Presentation.ViewModels
{
    public class InsuranceFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Typ pojištění je povinný.")]
        [Display(Name = "Typ pojištění")]
        public string InsuranceType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Předmět je povinný.")]
        [MaxLength(200, ErrorMessage = "Byla překročena maximální délka")]
        [Display(Name = "Předmět")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Částka je povinná.")]
        [Range(0, 100_000_000_000, ErrorMessage = "Částka musí být mezi 1 a 100 000 000 000 Kč.")]
        [Display(Name = "Částka")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Platnost od je povinná.")]
        [DataType(DataType.Date)]
        [Display(Name = "Platnost od")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Platnost do je povinná.")]
        [DataType(DataType.Date)]
        [Display(Name = "Platnost do")]
        [DateRange("ValidFrom")]
        public DateTime ValidTo { get; set; }

        [Required]
        public int InsuredPersonId { get; set; }
        public IEnumerable<SelectListItem>? InsuranceTypeOptions { get; set; }
    }
}
