using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMS.Models
{
    public class ChargeDetailRecord
    {
        public ChargeDetailRecord()
        {
            MeterStart = MeterStart = 0;
            TimeStampStart = string.Empty;
            TimeStampStop = string.Empty;
        }
        public int MeterStart { get; set; }
        public string TimeStampStart { get; set; }
        public int MeterStop { get; set; }
        public string TimeStampStop { get; set; }
    }
}
