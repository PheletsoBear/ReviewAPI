namespace ReviewWebAPI.Models.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Reviewer Reviewer { get; set; }
        public Pokemon Pokemon { get; set; }

    }
}
