namespace ChatApi.DatabaseStuff.Models
{
    public class Message : BaseModel
    {
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime {  get; set; }
    }
}
