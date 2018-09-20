using CBAdmin.Models;
using Microsoft.Extensions.Configuration;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBAdmin.Service
{
    public class StudentService : IStudentService
    {
        private IConfiguration _config; // this gets the settings from JSON config file
        private IDocumentStore _db;

        public StudentService(IConfiguration config)
        {
            _config = config;

            var documentStore = new DocumentStore
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "DockerDB"
            };

            _db = documentStore.Initialize();
        }

        public StudentService()
        {
            Console.WriteLine("Constructor without args");
        }



        public async Task<IList<Student>> GetStudentListAsynch()
        {
            var session = _db.OpenAsyncSession();

            var students = session.Query<Student>().ToListAsync();

            return await students;
        }

        public Student GetStudent(string id)
        {
            var session = _db.OpenAsyncSession();

            var student = session.LoadAsync<Student>(id);

            return student.Result;
        }

        public void SaveStudent(Student student)
        {
            // TODO: we have to set it this way so that ravendb creates a nice uuid for us. Remove to a better place.
            if (student.Id == null)
            {
                student.Id = string.Empty;
            }
            var session = _db.OpenSession();

            session.Store(student);
            session.SaveChanges();

        }

        public void DeleteStudent(string id)
        {
            var session = _db.OpenSession();

            session.Delete(id);
        }
    }
}
