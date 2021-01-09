using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Utilities
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = ResultStatus;
            Data = data;
        }

        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = ResultStatus;
            Message = message;
            Data = data;
        }

        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = ResultStatus;
            Message = message;
            Data = data;
            Exception = exception;
        }

        public ResultStatus ResultStatus { get; }
        public T Data { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
