using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net.NetworkInformation;

namespace Artmin_DAL
{
    public static class DatabaseOperations
    {
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
