using AutoMapper;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Infrastructure.Interfaces;

namespace InsuranceApp.Application.Managers
{
    public class Manager<TEntity, TDto> : IManager<TDto>
        where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public Manager(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? default : _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var added = await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<TDto>(added);
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var updated = _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<TDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (deleted)
                await _repository.SaveChangesAsync();

            return deleted;
        }
    }
}
