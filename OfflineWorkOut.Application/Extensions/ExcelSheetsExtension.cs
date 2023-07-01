using OfflineWorkOut.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Application.Extensions
{
    public static class ExcelSheetsExtension
    {
        private const string Diet = "DIETA";
        private const string Workout = "ENTRENO";


        public static SheetType GetSheetType(this string name)
        {
            if (name.StartsWith(Diet))
                return SheetType.Diet;
            else if (name.StartsWith(Workout))
                return SheetType.Workout;
            else
                return SheetType.Unkown;
        }
    }
}
