using OnlineSinav.DAL.Concrete.EntityFramework.Mapping;
using OnlineSinav.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.DAL.Concrete.EntityFramework
{
    public class OnlineSinavDbContext : DbContext
    {
        public OnlineSinavDbContext()
            //: base("Server=.;Database=OnlineSinav;Trusted_Connection=True")
            : base("server=.;database=OnlineSinav;Integrated Security = True;")
        {
            Database.SetInitializer<OnlineSinavDbContext>(new OnlineSinavDbInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ChoiceMapping());
            modelBuilder.Configurations.Add(new ExamMapping());
            modelBuilder.Configurations.Add(new LessonMapping());
            modelBuilder.Configurations.Add(new QuestionMapping());
            modelBuilder.Configurations.Add(new UserDetailMapping());
            modelBuilder.Configurations.Add(new UserExamMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserRoleMapping());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
    }

    class OnlineSinavDbInitializer : CreateDatabaseIfNotExists<OnlineSinavDbContext>
    {
        protected override void Seed(OnlineSinavDbContext context)
        {
            UserRole role = new UserRole()
            {
                Role = "Admin",
                IsActive = true
            };
            context.UserRoles.Add(role);

            role = new UserRole()
            {
                IsActive = true,
                Role = "User"
            };
            context.UserRoles.Add(role);
            context.SaveChanges();

            role = context.UserRoles.FirstOrDefault(a => a.Role == "Admin");

            User u = new User()
            {
                EMail = "akb@mail.com",
                IsActive = true,
                Name = "Akın",
                Surname = "Karabulut",
                Password = "12345",
                UserRole = role,
                UserRoleID = role.UserRoleID
            };

            context.SaveChanges();
        }
    }
}
