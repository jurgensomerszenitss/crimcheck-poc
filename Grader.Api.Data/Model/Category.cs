using NpgsqlTypes;
using System.Collections.Generic;

namespace Grader.Api.Data.Model
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public NpgsqlTsVector SearchText { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
