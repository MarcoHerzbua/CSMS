using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMS.Models
{
    public class Rate
    {
        public Rate()
        {
            Energy = Time = Transaction = 0.0f;
        }
        public float Energy { get; set; }
        public float Time { get; set; }
        public float Transaction { get; set; }
    }
}
