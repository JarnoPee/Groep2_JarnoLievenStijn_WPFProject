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
        {     //Gemaakt door: Jarno Peeters - R0670336
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                var query = artminEntities.Notitie;
                return query.ToList();
            }
        }
        public static int VerwijderenNotitie(Notitie notitie)
        {    //Gemaakt door: Jarno Peeters - R0670336

            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                artminEntities.Entry(notitie).State = EntityState.Deleted;
                return artminEntities.SaveChanges();
            }
        }
        public static int AanpassenNotitie(Notitie notitie)
        {   //Gemaakt door: Jarno Peeters - R0670336
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                artminEntities.Entry(notitie).State = EntityState.Modified;
                return artminEntities.SaveChanges();
            }
        }
        public static int ToevoegenNotitie(Notitie notitie)
        {   //Gemaakt door: Jarno Peeters - R0670336
            try
            {
                using (ArtminEntities artminEntities = new ArtminEntities())
                {
                    artminEntities.Notitie.Add(notitie);
                    return artminEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static Event OphalenEventViaId(int EventId)
        {   //Stijn Beckers - r0795483
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                return artminEntities.Event
                    .Where(x => x.EventID == EventId)
                    .SingleOrDefault();
            }
        }
        public static Notitie OphalenNotitieViaId(int notitieId)
        {   //Gemaakt door: Jarno Peeters - R0670336
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                var query = artminEntities.Notitie.Where(x => x.NotitieID == notitieId);
                return query.SingleOrDefault();
            }
        }
    }
}
