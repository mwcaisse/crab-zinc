using System;
using System.Collections.Generic;
using System.Text;
using Mitchell.Common.Entities;

namespace CrabZinc.Common.Entities
{
    public class BlogPost : ITrackedEntity
    {

        public String Title { get; set; }

        public String Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public bool Visible { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
