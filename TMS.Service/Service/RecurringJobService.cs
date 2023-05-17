using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO;
using TMS.Service.Interface;
using Task = TMS.Model.Task;

namespace TMS.Service.Service
{
    public class RecurringJobService : IRecurringJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RecurringJobService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RecurringJob> AddAsync(RecurringJobDto model)
        {
            var recurringJob = _mapper.Map<RecurringJobDto, RecurringJob>(model);
            await _unitOfWork.RecurringJobRepository.AddAsync(recurringJob);
            await _unitOfWork.CommitAsync();
            return recurringJob;
        }
        public async Task<bool> DeleteAsync(RecurringJobDto model)
        {
            var recurringJob = _mapper.Map<RecurringJobDto, RecurringJob>(model);
             _unitOfWork.RecurringJobRepository.DeleteAsync(recurringJob);
            return  await _unitOfWork.CommitAsync();
        }
        public Task<IEnumerable<RecurringJobDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RecurringJobDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RecurringJobDto> GetFirtOrDefaultAsync(Expression<Func<RecurringJobDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<RecurringJob> UpdateAsync(RecurringJobDto model)
        {
            throw new NotImplementedException();
        }
    }
}
