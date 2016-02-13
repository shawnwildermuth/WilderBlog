using System;
using System.Collections.Generic;

namespace WilderBlog.Commands.OldDb
{
    public partial class StoryCategories
    {
        public int Category_Id { get; set; }
        public int Story_Id { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Stories Story { get; set; }
    }
}
