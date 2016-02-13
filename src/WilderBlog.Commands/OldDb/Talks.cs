using System;
using System.Collections.Generic;

namespace WilderBlog.Commands.OldDb
{
    public partial class Talks
    {
        public int Id { get; set; }
        public string CodeLink { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLink { get; set; }
        public string PdfLink { get; set; }
        public string SlideLink { get; set; }
        public string Title { get; set; }
    }
}
