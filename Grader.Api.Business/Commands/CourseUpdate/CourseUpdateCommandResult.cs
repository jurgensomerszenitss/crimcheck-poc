using Grader.Api.Business.Enums;
using Newtonsoft.Json;
using System;

namespace Grader.Api.Business.Commands.CourseUpdate
{
    public class CourseUpdateCommandResult
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

        [JsonIgnore]
        public UpdateCommandResult Result { get; set; }
    }
}
