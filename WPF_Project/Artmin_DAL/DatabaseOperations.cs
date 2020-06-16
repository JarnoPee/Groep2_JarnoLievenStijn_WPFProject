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

        public static Event OphalenEventsViaId(int eventId)
        {
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                return artminEntities.Event
                    .Include(x => x.Eventtype)
                    .Where(x => x.EventID == eventId)
                    .SingleOrDefault();
            }
        }

        public static List<Eventtype> OphalenEventTypes()
        {
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                return artminEntities.Eventtype
                    .ToList();
            }
        }

        //public static Eventtype OphalenEventTypeViaId(int eventTypeId)
        //{
        //    using (ArtminEntities artminEntities = new ArtminEntities())
        //    {
        //        return artminEntities.Eventtype
        //            .Where(x => x.EventtypeID == eventTypeId)
        //            .SingleOrDefault();
        //    }
        //}

        public static int UpdateEvent(Event _event)
        {
            try
            {
                using (ArtminEntities artminEntities = new ArtminEntities())
                {
                    artminEntities.Entry(_event).State = EntityState.Modified;
                    return artminEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        public static int ToevoegenEvent(Event _event)
        {
            try
            {
                using (ArtminEntities artminEntities = new ArtminEntities())
                {
                    artminEntities.Event.Add(_event);
                    return artminEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
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
