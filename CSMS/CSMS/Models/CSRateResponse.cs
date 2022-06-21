using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMS.Models
{
    public class CSRateResponse
    {
        public CSRateResponse()
        {
            Overall = 0.0f;
            Components = new Rate();
        }
        public float Overall { get; set; }
        public Rate Components { get; set; }
    }
}
