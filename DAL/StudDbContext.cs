using Microsoft.EntityFrameworkCore;
using StudentsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsWebApp.DAL
{
    public class StudDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Ignore(s => s.Fio);

            modelBuilder.Entity<Group>().HasData(
                new Group { GroupID = 1, GroupName = "радиофизика" },
                new Group { GroupID = 2, GroupName = "микроэлектроника" },
                new Group { GroupID = 3, GroupName = "общая физика" });
        }
        public StudDbContext(DbContextOptions<StudDbContext> options)
            : base(options)
        {

        }
    }
}
