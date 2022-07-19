namespace Hospital.Api
{
    public class BaseResponse
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
        where T : class
    {
        public T Data { get; set; }
    }
}