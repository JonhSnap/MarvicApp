using MarvicSolution.DATA.Configurations;
using MarvicSolution.DATA.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarvicSolution.DATA.EF
{
    public class MarvicDbContext : DbContext
    {
        public MarvicDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Su dung Fluent Api cai dat cac thuoc tinh cho Table va cac Fields
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectType_Configurations());
            modelBuilder.ApplyConfiguration(new Project_Configurations());
            modelBuilder.ApplyConfiguration(new App_User_Configurations());
            modelBuilder.ApplyConfiguration(new Issue_Configurations());
            modelBuilder.ApplyConfiguration(new Member_Configurations());
            modelBuilder.ApplyConfiguration(new Test_Configurations());
            modelBuilder.ApplyConfiguration(new Question_Configurations());
            modelBuilder.ApplyConfiguration(new Answer_Configurations());
            modelBuilder.ApplyConfiguration(new Comment_Configurations());
            modelBuilder.ApplyConfiguration(new Sprint_Configurations());
            modelBuilder.ApplyConfiguration(new Lablel_Configurations());
            modelBuilder.ApplyConfiguration(new Stage_Configurations());
            //modelBuilder.ApplyConfiguration(new Archieve_Configurations());

            //base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        // Cac table của db
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<App_User> App_Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Label> Labels { get; set; }
       // public DbSet<Archieve> Archieves { get; set; }
    }
}
