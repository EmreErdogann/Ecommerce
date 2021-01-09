using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Utilities
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}
