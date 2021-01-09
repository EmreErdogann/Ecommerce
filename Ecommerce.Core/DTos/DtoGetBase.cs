
using Ecommerce.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTos
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
