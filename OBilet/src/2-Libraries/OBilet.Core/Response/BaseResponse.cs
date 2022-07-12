namespace OBilet.Core.Response
{
    public class BaseResponse<T> where T : class
    {
        public BaseResponse() { }
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
        public BaseResponse(T data, string message = null)
        {
            Success = true;
            Message = message;
            Result = data;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public string Errors { get; set; }
        public string Info { get; set; }
    }
}
