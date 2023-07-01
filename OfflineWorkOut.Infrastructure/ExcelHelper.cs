using ClosedXML.Excel;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;
using OfflineWorkOut.Application.Extensions;

namespace OfflineWorkOut.Infrastructure
{
    public static class ExcelHelper
    {
        public static async Task<List<DataTable>> GetDataTableFromExcel(IBrowserFile file)
        {
            List<DataTable> dtTable = new();

            using (MemoryStream memStream = new MemoryStream())
            {
                await file.OpenReadStream(file.Size).CopyToAsync(memStream);
                using XLWorkbook workBook = new(memStream);
                foreach (var sheet in workBook.Worksheets)
                { 
                    dtTable.Add(await ReadSheet(sheet));    
                }

                ////Loop through the Worksheet rows.
                //bool firstRow = true;
                //foreach (IXLRow row in workSheet.Rows())
                //{
                //    //Use the first row to add columns to DataTable.
                //    if (firstRow)
                //    {
                //        foreach (IXLCell cell in row.Cells())
                //        {
                //            dtTable.Columns.Add(cell.Value.ToString());
                //        }
                //        firstRow = false;
                //    }
                //    else
                //    {
                //        //Add rows to DataTable.
                //        dtTable.Rows.Add();
                //        int i = 0;

                //        foreach (IXLCell cell in row.Cells(row.FirstCellUsed().Address.ColumnNumber, row.LastCellUsed().Address.ColumnNumber))
                //        {
                //            dtTable.Rows[dtTable.Rows.Count - 1][i] = cell.Value.ToString();
                //            i++;
                //        }
                //    }
                //}
            }
            return dtTable;
        }

        private static async Task<DataTable> ReadSheet(IXLWorksheet workSheet)
        {
            var type = workSheet.Name.GetSheetType();
            if (type == Application.Enums.SheetType.Workout)
                return await ReadSheetWorkout(workSheet);
            return new DataTable();
        }

        private static async Task<DataTable> ReadSheetWorkout(IXLWorksheet workSheet)
        {
            return new DataTable();
        }
    }
}