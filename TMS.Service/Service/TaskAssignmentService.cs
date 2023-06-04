using AutoMapper;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using TMS.Utility;
using Task = System.Threading.Tasks.Task;

namespace TMS.Service.Service
{
    public class TaskAssignmentService : ITaskAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly ISendEmailService _sendEmailService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public TaskAssignmentService(IUnitOfWork unitOfWork,
            IMapper mapper, IEmailTemplateService emailTemplateService,
            ISendEmailService sendEmailService,
            IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailTemplateService = emailTemplateService;
            _sendEmailService = sendEmailService;
            _userService = userService;
        }
        public async Task<bool> AddAsync(int userId, TaskInfoData model)
        {
            var task = new Model.Task()
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                CreatedBy = userId,
                ModifiedBy = userId,
                IsActive = true,
                Priority = model.PriorityId,
            };
            await _unitOfWork.TaskRepository.AddAsync(task);
            await _unitOfWork.CommitAsync();
            if (!string.IsNullOrEmpty(model.UserIds))
            {
                var userIdList = HelperMethod.SplitString(model.UserIds);
                var taskAssignList = new List<TaskAssignment>();
                foreach (var item in userIdList)
                {
                    var taskAssign = new TaskAssignment()
                    {
                        CreatedDate = DateTime.UtcNow,
                        CategoryId = model.CategoryId,
                        CreatedBy = userId,
                        ModifiedBy = userId,
                        ModifiedDate = DateTime.UtcNow,
                        AssignedBy = userId,
                        AssignedTo = item,
                        StatusId = model.StatusId,
                        IsActive = true,
                        TaskId = task.Id,
                    };
                    taskAssignList.Add(taskAssign);
                }
                await _unitOfWork.TaskAssignmentRepository.AddRangeAsync(taskAssignList);
                var check = await _unitOfWork.CommitAsync();
                var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
                if (user != null && !string.IsNullOrEmpty(user.Email) && check >= 1)
                {
                    return await SendTaskAssignedMail(user, model, taskAssignList, null);
                }
                return check >= 1;
            }
            else
            {
                var taskAssign = new TaskAssignment()
                {
                    CreatedDate = DateTime.UtcNow,
                    CategoryId = model.CategoryId,
                    CreatedBy = userId,
                    ModifiedBy = userId,
                    ModifiedDate = DateTime.UtcNow,
                    AssignedBy = userId,
                    AssignedTo = userId,
                    StatusId = model.StatusId,
                    IsActive = true,
                    TaskId = task.Id,
                };
                await _unitOfWork.TaskAssignmentRepository.AddAsync(taskAssign);
                var check = await _unitOfWork.CommitAsync();
                var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
                if (user != null && !string.IsNullOrEmpty(user.Email) && check >= 1)
                {
                    return await SendTaskAssignedMail(user, model, null, taskAssign);
                }
                return check >= 1;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var taskAssignment = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
            _unitOfWork.TaskAssignmentRepository.Delete(taskAssignment);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskInfoView>> GetTaskListAsync(TaskInfoViewDto taskInfoViewDto)
        {
            return await _unitOfWork.TaskAssignmentRepository.GetTaskListAsync(taskInfoViewDto);
        }
        public async Task<TaskAssignmentDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
            return _mapper.Map<TaskAssignment, TaskAssignmentDto>(result);
        }
        public async Task<bool> UpdateTaskStatus(int userId, int taskId, int statusId)
        {
            var taskAssign = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(taskId);
            taskAssign.StatusId = statusId;
            _unitOfWork.TaskAssignmentRepository.Update(taskAssign);
            var check = await _unitOfWork.CommitAsync();
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            if (user != null && !string.IsNullOrEmpty(user.Email) && check > 1)
            {
                return await SendTaskStatusUpdateMail(user.Email);
            }
            return check >= 1;
        }
        public async Task<bool> UpdateAsync(int userId, TaskInfoData model)
        {
            var task = new Model.Task()
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                CreatedBy = userId,
                ModifiedBy = userId,
                IsActive = true,
                Priority = model.PriorityId,
            };
            _unitOfWork.TaskRepository.Update(task);
            await _unitOfWork.CommitAsync();
            if (!string.IsNullOrEmpty(model.UserIds))
            {
                var userIdList = HelperMethod.SplitString(model.UserIds);
                var taskAssignList = new List<TaskAssignment>();
                foreach (var item in userIdList)
                {
                    var taskAssign = new TaskAssignment()
                    {
                        CreatedDate = DateTime.UtcNow,
                        CategoryId = model.CategoryId,
                        CreatedBy = userId,
                        ModifiedBy = userId,
                        ModifiedDate = DateTime.UtcNow,
                        AssignedBy = userId,
                        AssignedTo = item,
                        StatusId = 1,
                        IsActive = true,
                        TaskId = task.Id,
                    };
                    taskAssignList.Add(taskAssign);
                }
                await _unitOfWork.TaskAssignmentRepository.UpdateRangeAsync(taskAssignList);
                return HelperMethod.Commit(await _unitOfWork.CommitAsync());
            }
            else
            {
                var taskAssign = new TaskAssignment()
                {
                    CreatedDate = DateTime.UtcNow,
                    CategoryId = model.CategoryId,
                    CreatedBy = userId,
                    ModifiedBy = userId,
                    ModifiedDate = DateTime.UtcNow,
                    AssignedBy = userId,
                    AssignedTo = userId,
                    StatusId = model.StatusId,
                    IsActive = true,
                    TaskId = task.Id,
                };
                _unitOfWork.TaskAssignmentRepository.Update(taskAssign);
                var check = await _unitOfWork.CommitAsync();
                var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
                if (user != null && !string.IsNullOrEmpty(user.Email) && check >= 1)
                {
                    return await SendTaskUpdateMail(user,model,null,taskAssign);
                }
                return check >= 1;
            }
        }

        public async Task<List<TaskCoverageDto>> TaskCoverage(int taskId)
        {
            return await _unitOfWork.TaskAssignmentRepository.GetTaskStatusAsync(taskId);
        }
        private async Task<bool> SendTaskAssignedMail(User user, TaskInfoData task, List<TaskAssignment>? taskAssignList, TaskAssignment? taskAssign)
        {
            var priority = await _unitOfWork.TaskPriorityRepository.GetByIdAsync(task.PriorityId);
            var emailData = new EmailData();
            var mailBody = new StringBuilder();

            var emailTemplates = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.TASK_ASSIGNED.ToString());
            mailBody.Append(emailTemplates);
            mailBody.Replace("#DemoId#", taskAssign.Id.ToString());
            mailBody.Replace("#demo#", task.Title);
            mailBody.Replace("#demoDescription#", task.Description);
            mailBody.Replace("#demoAssigned#", user.FirstName);
            mailBody.Replace("#demoDueDate#", task.DueDate.ToString());
            mailBody.Replace("#demoPriority#", priority.Type);
            emailData.FilePath = "";
            emailData.MailBody = mailBody.ToString();
            emailData.MailSubject = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.TASK_ASSIGNED_SUBJECT.ToString());
            if (taskAssign != null)
            {
                emailData.MailBcc = "";
                emailData.Mailcc = "";
                emailData.MailTo = user.Email!;
            }
            else if (taskAssignList != null)
            {
                var emailIds = await _userService.GetEmailIdsByUserIds(HelperMethod.SplitString(task.UserIds));
                emailData.MailBcc = "";
                emailData.Mailcc = "";
                emailData.MailTo = HelperMethod.CommaSeperatedString(emailIds);
            }
            return await Task.Run(() => _sendEmailService.SendEmail(emailData));
        }
        private async Task<bool> SendTaskUpdateMail(User user, TaskInfoData task, List<TaskAssignment>? taskAssignList, TaskAssignment? taskAssign)
        {
            var priority = await _unitOfWork.TaskPriorityRepository.GetByIdAsync(task.PriorityId);
            var emailData = new EmailData();
            var mailBody = new StringBuilder();

            var emailTemplates = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.TASK_UPDATE.ToString());
            mailBody.Append(emailTemplates);
            mailBody.Replace("#DemoId#", taskAssign.Id.ToString());
            mailBody.Replace("#demo#", task.Title);
            mailBody.Replace("#demoDescription#", task.Description);
            mailBody.Replace("#demoAssigned#", user.FirstName);
            mailBody.Replace("#demoDueDate#", task.DueDate.ToString());
            mailBody.Replace("#demoPriority#", priority.Type);
            emailData.FilePath = "";
            emailData.MailBody = mailBody.ToString();
            emailData.MailSubject = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.TASK_UPDATE_SUBJECT.ToString());
            if (taskAssign != null)
            {
                emailData.MailBcc = "";
                emailData.Mailcc = "";
                emailData.MailTo = user.Email!;
            }
            else if (taskAssignList != null)
            {
                var emailIds = await _userService.GetEmailIdsByUserIds(HelperMethod.SplitString(task.UserIds));
                emailData.MailBcc = "";
                emailData.Mailcc = "";
                emailData.MailTo = HelperMethod.CommaSeperatedString(emailIds);
            }
            return await Task.Run(() => _sendEmailService.SendEmail(emailData));
        }
        private async Task<bool> SendTaskStatusUpdateMail(string userEmail)
        {
            var emailData = new EmailData();
            var mailBody = new StringBuilder();

            var emailTemplates = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.TASK_STATUS_UPDATE.ToString());
            mailBody.Append(emailTemplates);
            emailData.FilePath = "";
            emailData.MailBody = mailBody.ToString();
            emailData.MailSubject = await _emailTemplateService.GetEmailTemplateValueByName(TemplateIdentifier.TASK_STATUS_UPDATE_SUBJECT.ToString());
            emailData.MailBcc = "";
            emailData.Mailcc = "";
            emailData.MailTo = userEmail;

            return await Task.Run(() => _sendEmailService.SendEmail(emailData));
        }
    }
}
