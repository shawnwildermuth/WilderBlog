using System;
using System.Collections.Generic;

namespace WilderBlog.Commands.OldDb
{
    public partial class Categories
    {
        public Categories()
        {
            StoryCategories = new HashSet<StoryCategories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StoryCategories> StoryCategories { get; set; }
    }
}
