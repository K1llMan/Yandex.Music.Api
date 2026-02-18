namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonError
    {
        public YYnisonErrorDetails Details { get; set; }
        public int GrpcCode { get; set; }
        public int HttpCode { get; set; }
        public string HttpStatus { get; set; }
        public string Message { get; set; }
    }
}
