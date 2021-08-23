using System;

namespace Grader.Api.Business.Queries.CourseGet
{
    public class CourseGetQueryResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public DateTime RegistrationFrom { get; set; }
        public DateTime RegistrationTo { get; set; }
        public int MaxParticipants { get; set; }
        public int MinParticipants { get; set; }
        public long CategoryId { get; set; }
    }
}
