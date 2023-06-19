namespace TMS.Utility
{
    public class ServiceResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public string? Error { get; set; }

        public ServiceResponse()
        {
            Message = "No Records";
            StatusCode = 404;
        }

        public void SetSuccess()
        {
            StatusCode = 200;
            Message = "Success";
        }
        public void SetSuccess(T data)
        {
            StatusCode = 200;
            Message = "Success";
            Data = data;
        }

        public void SetFailure(string failureMessage)
        {
            StatusCode = 417;
            Message = failureMessage;
        }
        public void SetError(T errorMessage)
        {
            StatusCode = 400;
            Message = "Bad Request";
            Data = errorMessage;
        }
    }
}
