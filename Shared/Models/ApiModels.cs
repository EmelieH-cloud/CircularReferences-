namespace Shared.Models
{
    public class TicketAPIModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string SubmittedBy { get; set; } = null!;
        public bool IsResolved { get; set; }
        public string? Image { get; set; }

        public List<TicketTagModel> TicketTags { get; set; } = new();
        public List<ResponseModel> Responses { get; set; } = new();
    }


    public class TagModelAPIModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ResponseAPIModel
    {
        public int Id { get; set; }
        public string Response { get; set; } = null!;
        public string SubmittedBy { get; set; } = null!;
    }
}