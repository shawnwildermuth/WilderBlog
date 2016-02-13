using System;
using System.Collections.Generic;

namespace WilderBlog.Commands.OldDb
{
    public partial class Stories
    {
        public Stories()
        {
            Comments = new HashSet<Comments>();
            StoryCategories = new HashSet<StoryCategories>();
        }

        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsPublished { get; set; }
        public string Permalink { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<StoryCategories> StoryCategories { get; set; }
    }
}
