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
using TMS.Utility;
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
        public async Task<bool> DeleteAsync(int id)
        {
            var recurringJob = await _unitOfWork.RecurringJobRepository.GetByIdAsync(id);
            _unitOfWork.RecurringJobRepository.Delete(recurringJob);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<RecurringJobDto>> GetAllAsync(Expression<Func<RecurringJob, bool>>? filter = null,
                Func<IQueryable<RecurringJob>, IOrderedQueryable<RecurringJob>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.RecurringJobRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<RecurringJob>, PageResult<RecurringJobDto>>(result);
        }

        public async Task<RecurringJobDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.RecurringJobRepository.GetByIdAsync(id);
            return _mapper.Map<RecurringJob, RecurringJobDto>(result);
        }

        public async Task<RecurringJobDto> GetFirtOrDefaultAsync(Expression<Func<RecurringJob, bool>> predicate)
        {
            var result = await _unitOfWork.RecurringJobRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<RecurringJob, RecurringJobDto>(result);
        }

        public async Task<RecurringJob> UpdateAsync(int userId, int recurringJobId, RecurringJobDto model)
        {
            var recurringJob = await _unitOfWork.RecurringJobRepository.GetByIdAsync(recurringJobId);
            recurringJob.Name = model.Name;
            recurringJob.ModifiedDate = DateTime.UtcNow;
            recurringJob.ModifiedBy = userId;
            _unitOfWork.RecurringJobRepository.Update(recurringJob);
            await _unitOfWork.CommitAsync();
            return recurringJob;
        }
    }
}
