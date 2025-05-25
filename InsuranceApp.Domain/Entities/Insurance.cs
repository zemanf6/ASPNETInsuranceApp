using InsuranceApp.Domain.Entities.Enums;

namespace InsuranceApp.Domain.Entities
{
    public class Insurance
    {
        public int Id { get; set; }
        public int InsuredPersonId { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public decimal Amount { get; set; }
        public string Subject { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public InsuredPerson InsuredPerson { get; set; } = null!;
    }
}
