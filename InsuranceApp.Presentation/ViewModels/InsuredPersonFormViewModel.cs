using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Presentation.ViewModels
{
    public class InsuredPersonFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Jméno je povinné.")]
        [MaxLength(100, ErrorMessage = "Byla překročena maximální délka")]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Příjmení je povinné.")]
        [MaxLength(100, ErrorMessage = "Byla překročena maximální délka")]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email je povinný.")]
        [EmailAddress(ErrorMessage = "Zadejte platný email.")]
        [MaxLength(320, ErrorMessage = "Byla překročena maximální délka")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon je povinný.")]
        [MaxLength(30, ErrorMessage = "Byla překročena maximální délka")]
        [Display(Name = "Telefon")]
        [RegularExpression(@"^((\+|00)?\d{1,4}|\(?\d{3,4}\)?)?[-.\s]?\d{3}[-.\s]?\d{3,4}$",
        ErrorMessage = "Zadejte platné telefonní číslo.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ulice je povinná.")]
        [MaxLength(200, ErrorMessage = "Byla překročena maximální délka")]
        [Display(Name = "Ulice")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "Město je povinné.")]
        [MaxLength(100, ErrorMessage = "Byla překročena maximální délka")]
        [Display(Name = "Město")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "PSČ je povinné.")]
        [MaxLength(20, ErrorMessage = "Byla překročena maximální délka")]
        [Display(Name = "PSČ")]
        public string PostalCode { get; set; } = string.Empty;
    }
}
