using CBAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBAdmin.Controllers
{
    public class Helper
    {
        public void Test(string id, Type X)
        {
            var session = DocumentStoreHolder.Store.OpenSession();

            session.Load<X>(id);

        }
    }
}
