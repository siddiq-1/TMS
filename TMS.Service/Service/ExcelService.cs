using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.ModelDTO;
using TMS.Service.Interface;

namespace TMS.Service.Service
{
    public class ExcelService : IExcelService
    {
        public async Task<byte[]> GetExcelDatabytes(List<WorkSheetInfo> workSheetInfos)
        {
            using (var excelPackage = new ExcelPackage())
            {
                int workSheetNo = 1;
                foreach (var item in workSheetInfos)
                {
                    excelPackage.Workbook.Worksheets.Add(item.WorkSheetName);
                    var workSheet = excelPackage.Workbook.Worksheets[workSheetNo];
                    workSheet.Name = item.WorkSheetName;
                    workSheet.Cells.Style.Font.Size = 11;
                    workSheet.Cells.Style.Font.Name = "Calibri";
                    workSheet.Cells[1, 1].Value = item.ReportHeading;
                    workSheet.Cells[1, 1, 1, item.DataTable.Columns.Count].Merge = true;
                    workSheet.Cells[1, 1, 1, item.DataTable.Columns.Count].Style.Font.Bold = true;
                    workSheet.Cells[1, 1, 1, item.DataTable.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    //int rowIndex = 2;
                    workSheet.Cells.AutoFitColumns(10, 30);
                    workSheetNo++;
                }
                return await excelPackage.GetAsByteArrayAsync();
            }
        }
    }
}
