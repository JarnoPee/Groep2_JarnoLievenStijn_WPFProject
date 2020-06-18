using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artmin_Models;

namespace Artmin_DAL
{
    public partial class Event : BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Event _event && EventID == _event.EventID;
                
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
