using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace Artmin_DAL
{
    public static class DatabaseOperations
    {
        public static List<Event> OphalenEvents()
        {
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                return artminEntities.Event
                    .Include(x => x.Eventtype)
                    .ToList();           
            }
        }
    }
}
