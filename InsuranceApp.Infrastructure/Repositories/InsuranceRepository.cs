using InsuranceApp.Domain.Entities;
using InsuranceApp.Infrastructure.Interfaces;

namespace InsuranceApp.Infrastructure.Repositories
{
    public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(ApplicationDbContext context) : base(context) { }
    }
}
