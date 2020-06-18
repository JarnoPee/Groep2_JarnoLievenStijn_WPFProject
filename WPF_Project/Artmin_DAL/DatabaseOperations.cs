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
        public static List<Locatie> OphalenLocaties()
        {//Stijn Beckers - r0795483
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                var query = artminEntities.Locatie 
                    .OrderBy(x => x.Naam);
                return query.ToList();
            }
        }
        public static int UpdateEvent(Event @event)
        {//Stijn Beckers - r0795483 
            try
            {
                using (ArtminEntities artminEntities = new ArtminEntities())
                {
                    artminEntities.Entry(@event).State = EntityState.Modified;
                    return artminEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;

            }          
        }
        public static Event OphalenEventViaId(int EventId)
        {//Stijn Beckers - r0795483
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                return artminEntities.Event
                    .Include(x => x.Locatie)
                    .Where(x => x.EventID == EventId)
                    .SingleOrDefault();
            }
        }
        public static Locatie OphalenLocatieViaId(int locatieID)
        {//Stijn Beckers - r0795483
            using (ArtminEntities artminEntities = new ArtminEntities())
            {
                return artminEntities.Locatie
                    .Include(x => x.Events)
                    .Where(x => x.LocatieID == locatieID)
                    .SingleOrDefault();
            }
        }
        public static int ToevoegenLocatie(Locatie locatie)
        {//Stijn Beckers - r0795483
            try
            {
                using (ArtminEntities artminEntities = new ArtminEntities())
                {
                    artminEntities.Locatie.Add(locatie);
                    return artminEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }
    }
}
