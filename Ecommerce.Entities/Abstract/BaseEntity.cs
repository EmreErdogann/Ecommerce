using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
    }
}
