using AutoMapper;
using InsuranceApp.Application.DTOs;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Domain.Entities;
using InsuranceApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Application.Managers
{
    public class InsuranceManager : Manager<Insurance, InsuranceDto>, IInsuranceManager
    {
        private readonly IInsuranceRepository _repository;
        public InsuranceManager(IInsuranceRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
        }

        public override async Task<InsuranceDto?> GetByIdAsync(int id)
        {
            var entity = await _repository
                .Query()
                .Include(i => i.InsuredPerson)
                .FirstOrDefaultAsync(i => i.Id == id);

            return entity == null ? null : _mapper.Map<InsuranceDto>(entity);
        }

        public override async Task<IEnumerable<InsuranceDto>> GetAllAsync()
        {
            var entities = await _repository
                .Query()
                .Include(i => i.InsuredPerson)
                .ToListAsync();

            return _mapper.Map<IEnumerable<InsuranceDto>>(entities);
        }

    }
}
