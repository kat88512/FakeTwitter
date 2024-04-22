namespace api.RequestModels
{
    public class AddPostRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
