using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Utilities
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
