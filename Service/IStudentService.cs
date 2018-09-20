using CBAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBAdmin.Service
{
    public interface IStudentService
    {
        Task<IList<Student>> GetStudentListAsynch();
        Student GetStudent(string id);
        void SaveStudent(Student student);
        void DeleteStudent(string id);
    }
}
