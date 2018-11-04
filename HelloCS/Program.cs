using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCS
{
    class Program
    {
        static void Main(string[] args)
        {

            var files = args.Where(s => System.IO.File.Exists(s)).Select(s => s);

            if (!files.Any())
            {
                Console.WriteLine("No files");
            }
            else
            {
                foreach (var file in files)
                {
                    var wally = ReadFile(file).FirstOrDefault(td => td.Name == "Wally");
                    Console.WriteLine("{0} worked {1} hours", wally.Name, wally.Hours);
                }
                //got all timesheet days

            }

            Console.ReadLine();
        }
        private static IEnumerable<TimesheetDay> ReadFile(string fn)
        {
            var lines = System.IO.File.ReadAllLines(fn);
            var timesheetDays = new List<TimesheetDay>();
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                var cells = line.Split(',');
                var name = cells[0];
                var hours = cells[1];
                var pay = 0;
                double hourz = 0;
                if (double.TryParse(hours, out hourz))
                {
                    var normaltime = hourz;
                    var overtime = hourz - 7.5;
                    if (overtime > 0)
                    {
                        hourz = 7.5;
                    }
                    else
                    {
                        overtime = 0;
                    }
                    var td = new TimesheetDay
                    {
                        Name = name,
                        Hours = hourz,
                        //OvertimeHours = overtime,
                        NormalPay = (decimal)(hourz * 17.55),
                        Overtime = (decimal)(overtime * 17.55 + 1.5)
                    };
                    //timesheetDays.Add(td);
                    yield return td;
                }
            }
            //return timesheetDays;
        }
    }
}
