namespace ChangHeWebSite.Areas.Admin.Models.Dto
{
    public class PageResponse : ResponseTemplate
    {
        public int CurrentPage { get; set; }
        public int Total { get; set; }
    }
}