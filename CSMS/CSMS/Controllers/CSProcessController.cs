using CSMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CSProcessController : ControllerBase
    {

        [HttpPost("rate")]
        public ActionResult<CSRateResponse> ProcessRate(CSRateRequest request)
        {
            CSRateResponse response = new CSRateResponse();
            response.Overall = 0.0f;

            ChargeDetailRecord cdr = request.Cdr;
            Rate rate = request.Rate;

            //calculate overall energy consumption in kwh and add to response
            double energyAmountWh = cdr.MeterStop - cdr.MeterStart;
            double energyAmountKwh = energyAmountWh / 1000.0;
            double energyPrice = energyAmountKwh * rate.Energy;
            response.Components.Energy = (float)Math.Round(energyPrice, 3);
            response.Overall += response.Components.Energy;

            //calculate overall charge time and add to response
            TimeSpan chargeTimespan = GetChargeTime(cdr);
            double chargeTimePrice = chargeTimespan.TotalHours * rate.Time;
            response.Components.Time = (float)Math.Round(chargeTimePrice, 3);
            response.Overall += response.Components.Time;

            //add transaction fee
            response.Components.Transaction = rate.Transaction;
            response.Overall += response.Components.Transaction;

            //round overall to 2 decimals
            response.Overall = (float)Math.Round(response.Overall, 2);

            return response;
        }

        //basic error-handling, sends default error message when exception occurs
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError() => Problem();

        private TimeSpan GetChargeTime(ChargeDetailRecord cdr)
        {
            TimeSpan chargeTime = new TimeSpan();

            DateTime startTime = ParseTimestamp(cdr.TimeStampStart);
            DateTime stopTime = ParseTimestamp(cdr.TimeStampStop);

            chargeTime = stopTime - startTime;

            return chargeTime;
        }

        //TODO: add more checks to validate timestamp string
        private DateTime ParseTimestamp(string timeStamp)
        {
            if(timeStamp.Length != 20 || timeStamp[10] != 'T' || timeStamp[19] != 'Z')
            {
                throw new FormatException("timestamps not in correct format");
            }

            int year = int.Parse(timeStamp.Substring(0, 4));
            int month = int.Parse(timeStamp.Substring(5, 2));
            int day = int.Parse(timeStamp.Substring(8, 2));
            int hours = int.Parse(timeStamp.Substring(11, 2));
            int minutes = int.Parse(timeStamp.Substring(14, 2));
            int seconds = int.Parse(timeStamp.Substring(17, 2));

            DateTime dateTime = new DateTime(year, month, day, hours, minutes, seconds);

            return dateTime;
        }
    }
}
