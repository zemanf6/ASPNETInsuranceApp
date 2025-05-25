using InsuranceApp.Domain.Entities;
using InsuranceApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Infrastructure.Repositories
{
    public class InsuredPersonRepository : Repository<InsuredPerson>, IInsuredPersonRepository
    {
        public InsuredPersonRepository(ApplicationDbContext context) : base(context) { }

        public async Task<InsuredPerson?> GetWithInsurancesAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Insurances)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
