using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMS.Models
{
    public class CSRateRequest
    {
        public CSRateRequest()
        {
            Rate = new Rate();
            Cdr = new ChargeDetailRecord();
        }
        public Rate Rate { get; set; }
        public ChargeDetailRecord Cdr { get; set; }
    }
}
