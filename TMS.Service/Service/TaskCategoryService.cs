using AutoMapper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TaskCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaskCategory> AddAsync(TaskCategoryDto model)
        {
            var taskCategory = _mapper.Map<TaskCategoryDto, TaskCategory>(model);
            await _unitOfWork.TaskCategoryRepository.AddAsync(taskCategory);
            await _unitOfWork.CommitAsync();
            return taskCategory;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var taskCategory = await _unitOfWork.TaskCategoryRepository.GetByIdAsync(id);
            _unitOfWork.TaskCategoryRepository.Delete(taskCategory);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskCategoryDto>> GetAllAsync(Expression<Func<TaskCategory, bool>>? filter = null,
                Func<IQueryable<TaskCategory>, IOrderedQueryable<TaskCategory>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.TaskCategoryRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<TaskCategory>, PageResult<TaskCategoryDto>>(result);
        }
        public async Task<TaskCategoryDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskCategoryRepository.GetByIdAsync(id);
            return _mapper.Map<TaskCategory, TaskCategoryDto>(result);
        }

        public async Task<TaskCategoryDto> GetFirtOrDefaultAsync(Expression<Func<TaskCategory, bool>> predicate)
        {
            var result = await _unitOfWork.TaskCategoryRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<TaskCategory, TaskCategoryDto>(result);
        }
        public async Task<TaskCategory> UpdateAsync(int userId, int TaskCategoryId, TaskCategoryDto model)
        {
            var taskCategory = await _unitOfWork.TaskCategoryRepository.GetByIdAsync(TaskCategoryId);
            taskCategory.Name = model.Name;
            taskCategory.ModifiedDate = DateTime.UtcNow;
            taskCategory.ModifiedBy = userId;
            taskCategory.IsActive = model.IsActive;
            _unitOfWork.TaskCategoryRepository.Update(taskCategory);
            await _unitOfWork.CommitAsync();
            return taskCategory;
        }

        public async Task<bool> BulkUploadTaskCategory(int userId, BulkUploadDto bulkUploadDto)
        {
            var fileBytes = Convert.FromBase64String(bulkUploadDto.FileData);
            using (var stream = new MemoryStream(fileBytes))
            {
                using (var excelPackage = new ExcelPackage(stream))
                {
                    var workSheets = excelPackage.Workbook.Worksheets[0];

                    var taskCategoryList = new List<TaskCategory>();
                    if (workSheets == null) { return false; }

                    for (int row = 2; row < workSheets.Dimension.Rows; row++)
                    {
                        string cellValue = workSheets.Cells[row, 3].Value?.ToString()?.ToLower()!;
                        if (!string.IsNullOrEmpty(workSheets.Cells[row, 2].Value.ToString()) || !string.IsNullOrEmpty(cellValue))
                        {
                            var taskCategory = new TaskCategory()
                            {
                                Name = workSheets.Cells[row, 2].Value.ToString()!,
                                IsActive = (cellValue == "true" || cellValue == "yes") ? true : false,
                                CreatedBy = userId,
                                ModifiedBy = userId
                            };
                            taskCategoryList.Add(taskCategory);
                        }
                    }
                    if (taskCategoryList != null) { return false; }

                    await _unitOfWork.TaskCategoryRepository.AddRangeAsync(taskCategoryList!);
                    return HelperMethod.Commit(await _unitOfWork.CommitAsync());
                }
            }
        }
    }
}
