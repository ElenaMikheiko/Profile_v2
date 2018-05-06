namespace Profile.Model.Models
{
    public class StudentSkill
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
