using AutoMapper;
using InsuranceApp.Application.DTOs;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Domain.Entities;
using InsuranceApp.Infrastructure.Interfaces;

namespace InsuranceApp.Application.Managers
{
    public class InsuredPersonManager : Manager<InsuredPerson, InsuredPersonDto>, IInsuredPersonManager
    {
        private readonly IInsuredPersonRepository _repository;

        public InsuredPersonManager(IInsuredPersonRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<InsuredPersonDto?> GetWithInsurancesAsync(int id)
        {
            var entity = await _repository.GetWithInsurancesAsync(id);
            return entity is null ? null : _mapper.Map<InsuredPersonDto>(entity);
        }
    }
}
