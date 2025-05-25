namespace InsuranceApp.Application.DTOs
{
    public class InsuranceDto
    {
        public int Id { get; set; }
        public int InsuredPersonId { get; set; }
        public string InsuranceType { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string InsuredPersonFullName { get; set; } = string.Empty;
    }
}
