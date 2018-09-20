using CBAdmin.Models;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBAdmin.Data
{
    public static class DBInitializer
    {
        public static void initialize(IDocumentStore store)
        {

            clear(store);

            fill(store);

        }

        private static void fill(IDocumentStore store)
        {
            var session = store.OpenSession();

            var student = new Student[]
            {
                new Student{LastName="Müller", FirstMidName="Franz", Id = string.Empty, Gender = GenderType.Male, DateOfBirth = DateTime.Parse("1989-1-11")},
                new Student{LastName="Müller", FirstMidName="Heinz", Id = string.Empty, Gender = GenderType.Male, DateOfBirth = DateTime.Parse("1990-1-11")},
                new Student{LastName="Musterman", FirstMidName="Veronika", Id = string.Empty, Gender = GenderType.Female, DateOfBirth = DateTime.Parse("1991-2-12")}
            };

            foreach (Student s in student)
            {
                session.Store(s, null);
                session.SaveChanges();
            }

        }

        private static void clear(IDocumentStore store)
        {
            var session = store.OpenSession();

            var students = session.Query<Student>().ToList();

            foreach (Student s in students)
            {
                session.Delete(s);
                session.SaveChanges();
            }
        }
    }
}
