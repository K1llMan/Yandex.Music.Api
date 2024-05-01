namespace Yandex.Music.Api.Models.Common
{
    public class YButton: YStyle
    {
        public string Text { get; set; }
        public string Url { get; set; }
        #warning Дублирование?
        public string Uri { get; set; }
        public string Color { get; set; }
        public bool ViewBrowser { get; set; }
    }
}
