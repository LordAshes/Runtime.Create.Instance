using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    /// <summary>
    /// Sample external library implementation of the (sample) ITime interface which displays results in MMM DDD YYYY HH:MM:SS.NNN format.
    /// </summary>
    public class ClockType2 : ITime
    {
        /// <summary>
        /// Holds the optionla location specification
        /// </summary>
        private string location = "";

        /// <summary>
        /// Holds the optional UTC offset
        /// </summary>
        private int offset = 0;

        /// <summary>
        /// Constructor with no parameters (defaults to no location specification and 0 offset)
        /// </summary>
        public ClockType2()
        {
        }

        /// <summary>
        /// Constructror allowing the loctation name and offset to be specified
        /// </summary>
        /// <param name="location">String location displayed before date/time</param>
        /// <param name="offset">Offset, in hours, from UTC</param>
        public ClockType2(string location, int offset)
        {
            this.location = location + ": ";
            this.offset = offset;
        }

        /// <summary>
        /// Method for displaying the date/time
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDateTime()
        {
            DateTime dt = DateTime.UtcNow;
            dt = dt.AddHours(this.offset);

            string[] months = { "January", "Februrary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string day = dt.Day.ToString();
            if (day.EndsWith("1")) { day = day + "st"; } else if (day.EndsWith("2")) { day = day + "nd"; } else if (day.EndsWith("3")) { day = day + "rd"; } else { day = day + "th"; }

            return this.location+months[dt.Month-1]+" "+day+" "+dt.Year.ToString("d4")+", "+ dt.Hour.ToString("d2") + ":" + dt.Minute.ToString("d2") + ":" + dt.Second.ToString("d2") + "." + dt.Millisecond.ToString("d3");
        }
    }
}
