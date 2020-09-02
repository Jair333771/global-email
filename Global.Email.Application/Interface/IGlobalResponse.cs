namespace Global.Email.Application.Interface
{
    public interface IGlobalResponse
    {
        object Data { get; set; }
        int Status { get; set; }
    }
}
