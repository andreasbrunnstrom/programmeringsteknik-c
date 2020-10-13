﻿using System.Collections.Generic;
using System.Linq;
using TimeSheet.Common.Models;

namespace TimeSheet.Common
{
    public class TimeSheetProcessor
    {
        public static int CalculateTimeForCustomer(List<TimeSheetEntryModel> entries, string customerName)
        {
            //entries.Where(e => e.WorkDone.ToLower().Contains(customerName))
            //         .Sum(e => e.HoursWorked);

            int sum = 0;
            foreach(var entry in entries)
            {
                int customerIndex = entry.WorkDone.IndexOf(customerName, System.StringComparison.OrdinalIgnoreCase);
                if (customerIndex >= 0)
                {
                    sum += entry.HoursWorked;
                }                              
            }
            return sum;
        }

        public static int CalculateTimeWorked(List<TimeSheetEntryModel> entries)
        {
            return entries.Sum(x => x.HoursWorked);
        }

        public static int CalculateTimeAsLambda(List<TimeSheetEntryModel> e, string c) =>
            e.Where(x => x.WorkDone.ToLower().Contains(c))
            .Sum(x => x.HoursWorked);
    }
}
