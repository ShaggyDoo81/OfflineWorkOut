using ClosedXML.Excel;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;
using OfflineWorkOut.Application.Extensions;
using SqliteWasmHelper;
using OfflineWorkOut.Infrastructure.DbContexts;
using OfflineWorkOut.Application.Models.DTOs;
using OfflineWorkOut.Domain.Enums;
using System.Text.RegularExpressions;

namespace OfflineWorkOut.Infrastructure.Services
{
    public class ExcelService
    {
        private readonly ISqliteWasmDbContextFactory<OfflineWorkoutDbContext> _dbContext;

        private const int PosTitle = 1;
        private const int PosExercise = 1;
        private const int PosW1 = 2;
        private const int PosW2 = 3;
        private const int PosW3 = 4;
        private const int PosW4 = 5;
        private const int PosSystem = 6;
        private const int PosRestTime = 7;

        private const string FirstWeek = "SEMANA 1";

        private const string Aislado = "AISLADO";
        private const string Biserie = "BISERIE";

        private const string min12 = "1-2MIN";
        private const string min21 = "1MIN-2";

        public ExcelService(ISqliteWasmDbContextFactory<OfflineWorkoutDbContext> dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<WorkoutPlanDto>> GetDataTableFromExcel(IBrowserFile file)
        {
            List<WorkoutPlanDto> wop = new();

            using (MemoryStream memStream = new MemoryStream())
            {
                await file.OpenReadStream(file.Size).CopyToAsync(memStream);
                using XLWorkbook workBook = new(memStream);
                foreach (var sheet in workBook.Worksheets)
                {
                    wop.AddRange(await ReadSheet(sheet));
                }
            }
            return wop;
        }

        private async Task<List<WorkoutPlanDto>> ReadSheet(IXLWorksheet workSheet)
        {
            var type = workSheet.Name.GetSheetType();
            if (type == Application.Enums.SheetType.Workout)
                return await ReadSheetWorkout(workSheet);
            return new List<WorkoutPlanDto>();
        }

        private async Task<List<WorkoutPlanDto>> ReadSheetWorkout(IXLWorksheet workSheet)
        {
            var wops = new List<WorkoutPlanDto>();
            List<WorkoutPlanDto>? currentWPs = null;
            var workoutPlanNames = new List<string>();
            Dictionary<string, WorkoutPlanDto>? workoutPlans = null;
            foreach (IXLRow row in workSheet.Rows())
            {
                var headerFound = (row.Cell(2)?.Value.ToString() ?? string.Empty) == FirstWeek;
                if (headerFound)
                {
                    if (currentWPs is not null)
                        wops.AddRange(currentWPs);

                    workoutPlanNames = GetWorkoutPlanNames(row.Cells());
                    if (workoutPlanNames.Any())
                    {
                        currentWPs = new();
                        workoutPlans = new();
                        foreach (var plan in workoutPlanNames)
                        {
                            var wop = new WorkoutPlanDto
                            {
                                Name = plan
                            };
                            workoutPlans.Add(plan, wop);
                            currentWPs.Add(wop);
                        }
                    }
                }
                else //get the data
                {
                    var exerciseName = row.Cell(PosExercise).Value.ToString();
                    var w1 = row.Cell(PosW1).Value.ToString();
                    var w2 = row.Cell(PosW2).Value.ToString();
                    var w3 = row.Cell(PosW1).Value.ToString();
                    var w4 = row.Cell(PosW1).Value.ToString();
                    var system = row.Cell(PosSystem).Value.ToString();
                    var rest = row.Cell(PosRestTime).Value.ToString();	
                    //Regex regex = new Regex("[0 - 9]X*[0 - 9]\\s*[^[0 - 9]X]*");
                    //string[] substrings = regex.Split(w1);
                    //foreach (string match in substrings)
                    //{
                    //    Console.WriteLine("'{0}'", match);
                    //}
                    foreach (var wop in currentWPs)
                    {
                        wop.ExerciseSets.Add(new ExerciseSetDto { 
                            Name = exerciseName,
                            Exercise = new ExerciseDto { Name = exerciseName },
                            ExerciseType = system.Equals(Biserie, StringComparison.CurrentCultureIgnoreCase) ? 
                                        ExerciseType.Biseries : ExerciseType.Isolated,
                            Note = w1,
                            RestTime = rest.Equals(min12, StringComparison.CurrentCultureIgnoreCase) ||
                                       rest.Equals(min21, StringComparison.CurrentCultureIgnoreCase) ? 120 : 60,
                        });
                    }
                }
            }

            if (currentWPs is not null)
                wops.AddRange(currentWPs);

            return wops;
        }

        private static List<string> GetWorkoutPlanNames(IXLCells cells)
        {
            var vblesPos = new int[] { PosW1, PosW2, PosW3, PosW4 };
            var wopNames = new List<string>();
            foreach (var pos in vblesPos) 
            {
                wopNames.Add($"{cells.First().Value} {cells.Skip(pos - 1).First().Value}");
            }
            return wopNames;
        }
    }
}