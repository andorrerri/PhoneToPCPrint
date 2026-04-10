public class AuthRequest
{
    public string ClientId { get; set; }
    public string Token { get; set; }
}

public class PrintRequest : AuthRequest
{
    public string FileName { get; set; }
    public byte[] FileData { get; set; }
}

public class FileRequest : AuthRequest
{
    public string FileName { get; set; }
}