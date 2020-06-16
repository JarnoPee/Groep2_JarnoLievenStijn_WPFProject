using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;

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

        public static List<Notitie> OphalenNotitiesViaEventId(int eventId)
        {
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                var query = artminEntities.Notitie;
                return query.ToList();
            }
        }
    }
}
