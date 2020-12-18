using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    /// <summary>
    /// Sample external library implementation of the (sample) ITime interface which displays results in YYYY-MM-DD HH:MM:SS.NNN format.
    /// </summary>
    public class ClockType1 : ITime
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
        public ClockType1()
        {
        }

        /// <summary>
        /// Constructror allowing the loctation name and offset to be specified
        /// </summary>
        /// <param name="location">String location displayed before date/time</param>
        /// <param name="offset">Offset, in hours, from UTC</param>
        public ClockType1(string location, int offset)
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
            return this.location+dt.Year.ToString("d4") + "-" + dt.Month.ToString("d2") + "-" + dt.Day.ToString("d2") + " " + dt.Hour.ToString("d2") + ":" + dt.Minute.ToString("d2") + ":" + dt.Second.ToString("d2") + "." + dt.Millisecond.ToString("d3");
        }
    }
}
