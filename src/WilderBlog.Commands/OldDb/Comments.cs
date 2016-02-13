using System;
using System.Collections.Generic;

namespace WilderBlog.Commands.OldDb
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsApproved { get; set; }
        public string PosterEmail { get; set; }
        public string PosterName { get; set; }
        public int? Story_Id { get; set; }

        public virtual Stories Story { get; set; }
    }
}
