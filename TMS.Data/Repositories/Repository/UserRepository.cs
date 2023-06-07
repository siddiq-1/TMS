using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Utility;

namespace TMS.Data.Repositories.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly TaskManagementSystemContext _tmsContext;

        public UserRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {
            _tmsContext = tmsContext;
        }

        public async Task<PageResult<User>> GetUsers(UserRequestDto userRequestDto)
        {
            int totalRecords = 0;
            var fromParameter = DataProvider.GetIntSqlParameter("@From", userRequestDto.From);
            var toParameter = DataProvider.GetIntSqlParameter("@To", userRequestDto.To);
            var searchParameter = DataProvider.GetStringSqlParameter("@Search", userRequestDto.Search);
            var sortColumnParameter = DataProvider.GetStringSqlParameter("@SortColumn", userRequestDto.SortColumn);
            var sortOrderParameter = DataProvider.GetStringSqlParameter("@SortOrder", userRequestDto.SortOrder);
            var totalRecordsParameter = DataProvider.GetIntSqlParameter("@TotalRecords", totalRecords, true);
            var parameters = new List<SqlParameter>()
            {
                fromParameter,
                toParameter,
                searchParameter,
                sortColumnParameter,
                sortOrderParameter,
                totalRecordsParameter
            };
            var result = await SQLHelper.ExecuteStoredProcedureAsync<User>("USP_AllUsers", parameters);
            totalRecords = Convert.IsDBNull(totalRecordsParameter.Value) ? 0 : Convert.ToInt32(totalRecordsParameter.Value);
            return new PageResult<User>(totalRecords, result);
        }

        public async Task<List<User>> GetUsersByIds(List<int> userIds)
        {
            return await _tmsContext.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();
        }
    }
}
