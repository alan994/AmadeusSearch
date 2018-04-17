using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Exceptions
{
    public class BusinessException: Exception
    {
        public BusinessException(string msg) : base(msg)
        {

        }
    }
}
