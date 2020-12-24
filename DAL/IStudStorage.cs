using StudentsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsWebApp.DAL
{
    public interface IStudStorage
    {
        List<Group> GetAll();
        void AddOrUpdate(Student student);
        Student GetStudentById(int id);
        List<Group> GetGroups();
        void Delete(Student student);
        List<Student> GetStudentByName(string name);
    }
}
