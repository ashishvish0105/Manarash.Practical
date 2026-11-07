namespace DocManagementSystem.Comman
{
    public class ReturnResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
        public string Error { get; set; }

        public ReturnResponse(int statusCode, string message, object payload = null, string error = null)
        {
            StatusCode = statusCode;
            Message = message;
            Payload = payload;
            Error = error;
        }
        public ReturnResponse(int statusCode, string error = null)
        {
            StatusCode = statusCode;
            Message = string.Empty;
            Payload = null;
            Error = error;
        }
    }
}
