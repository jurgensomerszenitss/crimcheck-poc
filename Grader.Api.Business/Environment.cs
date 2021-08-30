namespace Grader.Api.Business
{
    public static class Environment
    {
        public static string URI { get; private set; } = string.Empty;

        public static void SetUri(string uri)
        {
            lock (URI)
            {
                URI = uri;
            }
        }
    }
}
