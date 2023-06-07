using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.ModelDTO;

namespace TMS.Service.Interface
{
    public interface IExcelService
    {
        Task<byte[]> GetExcelDatabytes(List<WorkSheetInfo> workSheetInfos);
    }
}
