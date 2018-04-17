using Dto.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services.Amadeus
{
    public class AmadeusErorrCodes
    {
        public static string IATACodeError { get; internal set; } = "The origin should be a three letter IATA location code".ToLower();
        public static string NothingFound { get; set; } = "No result found.".ToLower();
        public static string PastDateNotAllowed { get; set; } = "Past date/time not allowed.".ToLower();
        public static void ThrowRightException(string msg)
        {
            if (msg.ToLower().Trim().StartsWith(IATACodeError) || msg.ToLower().Trim().StartsWith(NothingFound) || msg.ToLower().Trim().StartsWith(PastDateNotAllowed))
            {
                throw new BusinessException(msg);
            }
        }
    }
}
