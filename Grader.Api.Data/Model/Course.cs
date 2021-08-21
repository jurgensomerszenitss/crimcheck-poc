using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace Grader.Api.Data.Model
{
    public class Course
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
        public NpgsqlTsVector SearchText { get; set; }

        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
