using System;
using System.Collections.Generic;
using System.Text;

namespace System {
    static class DateTimeExtensions {

        public static string ElapsedTime(this DateTime referenceToThis) {
            TimeSpan duration = DateTime.Now.Subtract(referenceToThis);
            return duration.TotalHours > 24 ? duration.TotalDays.ToString("F2") + " dias" : duration.TotalHours.ToString("F2") + " horas";
        }

    }
}
