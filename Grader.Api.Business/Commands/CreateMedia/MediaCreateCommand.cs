namespace Grader.Api.Business.Commands.MediaCreate
{
    public class MediaCreateCommand
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }
    }
}
