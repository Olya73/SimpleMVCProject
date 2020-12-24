using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsWebApp.Models;

namespace StudentsWebApp.DAL
{
    public class StudDbStorage: IStudStorage
    {
        private readonly StudDbContext _context;

        public StudDbStorage(StudDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdate(Student student)
        {
            if (!_context.Entry<Student>(student).IsKeySet)
            {
                _context.Add(student);
            }
            else
            {
                _context.Update(student);
            }
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            _context.Remove(student);
            _context.SaveChanges();
        }

        public List<Group> GetAll()
        {
            return _context.Groups.Include(g => g.Students).ToList();
        }

        public List<Group> GetGroups()
        {
            return _context.Groups.ToList();
        }
        public List<Student> GetStudentByName(string name)
        {
            return _context.Students.Where(s => s.Name == name).ToList();
        }
        public Student GetStudentById(int id)
        {
            return _context.Students.Where(g => g.GroupID == id).FirstOrDefault();//Where(s => s.StudentID == id).ToList().FirstOrDefault();
        }
    }
}
