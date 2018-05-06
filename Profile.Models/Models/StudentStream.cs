namespace Profile.Model.Models
{
    public class StudentStream
    {
        public int StreamId { get; set; }
        public virtual Stream Stream { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

    }
}
