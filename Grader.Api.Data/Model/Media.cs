namespace Grader.Api.Data.Model
{
    public class Media
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }
    }
}
