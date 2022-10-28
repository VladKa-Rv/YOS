namespace YOS.API.Response
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public object Data { get; set; }
    }
}
