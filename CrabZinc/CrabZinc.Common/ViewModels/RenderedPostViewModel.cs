using System;
using System.Collections.Generic;
using System.Text;

namespace CrabZinc.Common.ViewModels
{
    public class RenderedPostViewModel
    {

        public long PostId { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string RenderedContent { get; set; }

        public DateTime PublishedDate { get; set; }

    }
}
