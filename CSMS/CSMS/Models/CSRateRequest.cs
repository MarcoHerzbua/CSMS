using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMS.Models
{
    public class CSRateRequest
    {
        public Rate Rate { get; set; }
        public ChargeDetailRecord ChargeDetailRecord { get; set; }
    }
}
