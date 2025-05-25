using InsuranceApp.Application.DTOs;

namespace InsuranceApp.Application.Interfaces
{
    public interface IInsuredPersonManager : IManager<InsuredPersonDto>
    {
        Task<InsuredPersonDto?> GetWithInsurancesAsync(int id);
    }
}
