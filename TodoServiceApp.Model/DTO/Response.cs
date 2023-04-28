namespace TodoServiceApp.Model.DTO
{
    public class Response
    {
        public int Status { get; set; }
        public string? Error { get; set; }
        public object? Data { get; set; }

    }
}
