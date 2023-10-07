using TMS.Data.Infrastructure;
using Task = TMS.Model.Task;

namespace TMS.Data.Repositories.Interface
{
    public interface ITaskRepository : IRepository<Task>
    {
        //Task<PageResult<Task>> GetTasks(TaskRequestDto taskRequestDto);
    }
}
