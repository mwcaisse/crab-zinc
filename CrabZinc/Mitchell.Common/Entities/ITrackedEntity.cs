using System;
using System.Collections.Generic;
using System.Text;

namespace Mitchell.Common.Entities
{
    public interface ITrackedEntity
    {
        DateTime CreateDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
