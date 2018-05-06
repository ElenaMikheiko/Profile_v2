using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Profile.Model.Models;

namespace Profile.DataAccess.Data
{
    public class ProfileDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Resume> Resume { get; set; }

        public DbSet<Summary> Summary { get; set; }

        public DbSet<Portfolio> Portfolio { get; set; }

        public DbSet<ForeignLanguage> ForeignLanguages { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<LanguageLevel> LanguageLevels { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Education> Education { get; set; }

        public DbSet<WorkExperience> WorkExperience { get; set; }

        public DbSet<MilitaryStatus> MilitaryStatus { get; set; }

        public DbSet<Recommendation> Recommendations { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<AdditionalInfo> AdditionalInfo { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Stream> Streams { get; set; }

        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<StreamSkill> StreamSkills { get; set; }

        public DbSet<StudentSkill> StudentSkills { get; set; }

        public DbSet<StudentStream> StudentStreams { get; set; }

        public DbSet<EducationLevel> EducationLevels { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
                //in case you chagned the TKey type
                //  entity.HasKey(key => new { key.UserId, key.RoleId });
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
                //in case you chagned the TKey type
                //  entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });       
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
                //in case you chagned the TKey type
                // entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });

            });

            builder.Entity<ApplicationUser>()
                .HasOne(u=>u.UserInfo)
                .WithOne(u=>u.User)
                .HasForeignKey<UserInfo>(u=>u.UserId).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Resume>()
                .HasOne(u => u.MilitaryStatus)
                .WithOne(u => u.Resume)
                .HasForeignKey<MilitaryStatus>(u => u.ResumeId);

            builder.Entity<Resume>()
                .HasOne(e => e.AdditionalInfo).WithOne(e => e.Resume);

            builder.Entity<Resume>()
                .HasOne(e => e.Summary).WithOne(e => e.Resume);

            builder.Entity<StudentSkill>()
            .HasKey(t => new { t.StudentId, t.SkillId });

            builder.Entity<StreamSkill>()
                .HasKey(t => new { t.StreamId, t.SkillId });

            builder.Entity<StudentStream>()
                .HasKey(t => new { t.StreamId, t.StudentId });

            builder.Entity<ForeignLanguage>()
               .HasKey(t => new { t.ResumeId, t.LanguageId, t.LanguageLevelId });

            builder.Entity<Skill>().HasIndex(s => s.Name).IsUnique(true);

            builder.Entity<Student>()
                .HasOne(s => s.UserInfo)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
