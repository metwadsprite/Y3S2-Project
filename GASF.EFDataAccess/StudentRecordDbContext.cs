using Microsoft.EntityFrameworkCore;
using GASF.ApplicationLogic.Data;

namespace GASF.EFDataAccess
{
    public class StudentRecordDbContext: DbContext
    {
        public StudentRecordDbContext(DbContextOptions<StudentRecordDbContext> options): base(options)
        {
        }

        public DbSet<CertificateForStudent> StudentCertificates { get; set; }
        public DbSet<CertificateForTeacher> TeacherCertificates { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<SchoolFee> SchoolFees { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupsCourses>()
                .HasKey(groupCourse => new { groupCourse.GroupId, groupCourse.CourseId });
            
            modelBuilder.Entity<GroupsCourses>()
                .HasOne(groupCourse => groupCourse.Group)
                .WithMany(group => group.GroupCourses)
                .HasForeignKey(groupCourse => groupCourse.GroupId);

            modelBuilder.Entity<GroupsCourses>()
                .HasOne(groupCourse => groupCourse.Course)
                .WithMany(course => course.GroupsCourses)
                .HasForeignKey(groupCourse => groupCourse.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(course => course.Exam)
                .WithOne(exam => exam.Course)
                .HasForeignKey<Course>(course => course.ExamId);
        }
    }
}