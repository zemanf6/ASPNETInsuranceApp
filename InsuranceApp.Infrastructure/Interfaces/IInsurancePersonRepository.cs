using InsuranceApp.Domain.Entities;

namespace InsuranceApp.Infrastructure.Interfaces
{
    public interface IInsuredPersonRepository : IRepository<InsuredPerson>
    {
        Task<InsuredPerson?> GetWithInsurancesAsync(int id);
    }
}
