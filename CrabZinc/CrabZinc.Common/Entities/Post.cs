using System;
using System.Collections.Generic;
using System.Text;
using OwlTin.Common.Entities;

namespace CrabZinc.Common.Entities
{
    public class Post : ITrackedEntity, IActiveEntity
    {
        public long PostId { get; set; }

        public Guid PostUuid { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public bool Visible { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
