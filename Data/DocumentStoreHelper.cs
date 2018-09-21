using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBAdmin.Data
{
    public class DocumentStoreHolder
    {
        private static Lazy<DocumentStore> store = new Lazy<DocumentStore>(CreateStore);

        public static DocumentStore Store => store.Value;

        private static DocumentStore CreateStore()
        {


            DocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "DockerDB"
            };

            store.Initialize();

            return store;
        }
    }
}