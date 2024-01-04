namespace QLPT_API.Handles.Response
{
    public class ResponseObject<T>
    {
        public int Status { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
    }
}
