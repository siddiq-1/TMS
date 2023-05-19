using AutoMapper;
using System.Linq.Expressions;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class ReportTypeService : IReportTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ReportTypeMaster> AddAsync(ReportTypeMasterDto model)
        {
            var reportType = _mapper.Map<ReportTypeMasterDto, ReportTypeMaster>(model);
            await _unitOfWork.ReportTypeRepository.AddAsync(reportType);
            await _unitOfWork.CommitAsync();
            return reportType;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var reportType = await _unitOfWork.ReportTypeRepository.GetByIdAsync(id);
            _unitOfWork.ReportTypeRepository.Delete(reportType);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<ReportTypeMasterDto>> GetAllAsync(Expression<Func<ReportTypeMaster, bool>>? filter = null,
                Func<IQueryable<ReportTypeMaster>, IOrderedQueryable<ReportTypeMaster>>? orderBy = null,
                int page = 0,
                int take = 10)
        {
            var result = await _unitOfWork.ReportTypeRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<ReportTypeMaster>, PageResult<ReportTypeMasterDto>>(result);
        }

        public async Task<ReportTypeMasterDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.ReportTypeRepository.GetByIdAsync(id);
            return _mapper.Map<ReportTypeMaster, ReportTypeMasterDto>(result);
        }

        public async Task<ReportTypeMasterDto> GetFirtOrDefaultAsync(Expression<Func<ReportTypeMaster, bool>> predicate)
        {
            var result = await _unitOfWork.ReportTypeRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<ReportTypeMaster, ReportTypeMasterDto>(result);
        }

        public async Task<ReportTypeMaster> UpdateAsync(int userId, int reportTypeId, ReportTypeMasterDto model)
        {
            var reportType = await _unitOfWork.ReportTypeRepository.GetByIdAsync(reportTypeId);
            reportType.Name = model.Name;
            reportType.ModifiedDate = DateTime.UtcNow;
            reportType.ModifiedBy = userId;
            _unitOfWork.ReportTypeRepository.Update(reportType);
            await _unitOfWork.CommitAsync();
            return reportType;
        }
    }
}
