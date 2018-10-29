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
            if (!System.IO.File.Exists("Data1.csv"))
            {
                Console.WriteLine("Data1 not found");
            }
            else
            {
                var s = System.IO.File.ReadAllText("Data1.csv");

                Console.WriteLine();
                Console.WriteLine("Input data: ");

                Console.Write(s);

                var lines = System.IO.File.ReadAllLines("Data1.csv");

                Console.WriteLine();
                Console.WriteLine("Pay data: ");

                foreach (var line in lines)
                {
                    var cells = line.Split(',');
                    var name = cells[0];
                    var hours = cells[1];
                    var pay = 0;
                    double hourz = 0;
                    Console.Write(name.PadRight(15));
                    Console.Write(hours.PadLeft(10));
                    if(double.TryParse(hours, out hourz))
                    {
                        var normaltime = hourz;
                        var overtime = hourz - 7.5;
                        if(overtime > 0)
                        {
                            Console.Write(hourz.ToString("0.0").PadLeft(10));
                            hourz = 7.5;
                            Console.Write((hourz * 17.55).ToString("C").PadLeft(10));
                            Console.Write((overtime * 17.55 + 1.5).ToString("C").PadLeft(10));
                        }
                        else
                        {
                            Console.Write((hourz * 17.55).ToString("C").PadLeft(10));
                        }
                    }
                    Console.WriteLine();
                }

                var timesheetDays = new List<TimesheetDay>();
                foreach (var line in lines)
                {
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
                        timesheetDays.Add(td);
                    }
                }
                timesheetDays.ForEach(tday =>
                    Console.WriteLine(
                        String.Format("{0} {1} {2} {3}",
                        tday.Name,
                        tday.Hours,
                        tday.NormalPay,
                        tday.Overtime)
                    )
                );

                Console.WriteLine(
                    string.Format("Staff: {0}, Hours {1}, Pay {2}",
                        timesheetDays.Count(),
                        timesheetDays.Sum(t => t.Hours),
                        timesheetDays.Sum(t => (t.NormalPay + t.Overtime))
                    )
                );

                Console.WriteLine("People in order of hours worked, descending");

                timesheetDays
                    .OrderByDescending(t=> (t.Hours))
                    .ToList()
                    .ForEach(tday =>
                    Console.WriteLine(
                        String.Format("{0} {1}",
                        tday.Name,
                        tday.Hours)
                    )
                );

            }

            Console.ReadLine();
        }
    }
}
