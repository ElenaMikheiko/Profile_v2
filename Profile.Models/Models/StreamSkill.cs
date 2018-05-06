namespace Profile.Model.Models
{
    public class StreamSkill
    {
        public int StreamId { get; set; }
        public virtual Stream Stream { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
