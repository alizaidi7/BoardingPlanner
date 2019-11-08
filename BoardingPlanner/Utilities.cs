using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardingPlanner
{
    public static class Utilities
    {
        public static IEnumerable<PlannerDTO> GetExcelData(string filePath)
        {

            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                IXLWorksheet worksheet = workbook.Worksheet(1);
                var count = 0;
                foreach (IXLRow row in worksheet.RowsUsed())
                {
                    count++;
                    if (count == 1) continue;
                    var dto = new PlannerDTO();

                    dto.SerialNumber = Convert.ToInt32(row.Cell(1).Value);
                    dto.HKID = Convert.ToInt32(row.Cell(2).Value);
                    dto.Name = Convert.ToString(row.Cell(3).Value);
                    dto.Rank = Convert.ToString(row.Cell(4).Value);
                    dto.Vessel = Convert.ToString(row.Cell(5).Value);
                    dto.TechnicalGroup = Convert.ToString(row.Cell(6).Value);
                    DateTime coc;
                    double cocNumberdate;
                    DateTime cocDate;
                    if (row.Cell(7).TryGetValue<DateTime>(out coc))
                    {
                        dto.COC = coc;
                    }
                    else if (row.Cell(7).TryGetValue<double>(out cocNumberdate))
                    {
                        dto.COC = DateTime.FromOADate(cocNumberdate);
                    }
                    else if (DateTime.TryParseExact(Convert.ToString(row.Cell(7).Value), Constants.DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out cocDate))
                    {
                        dto.COC = cocDate;
                    }
                    dto.Replacement = Convert.ToString(row.Cell(8).Value);
                    dto.Remarks = Convert.ToString(row.Cell(9).Value);

                    yield return dto;
                }
            }
        }
    }
}
