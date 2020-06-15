using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spartane.Core
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public abstract class SpartaneBaseEntity
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as SpartaneBaseEntity);
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public virtual bool Equals(SpartaneBaseEntity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(SpartaneBaseEntity x, SpartaneBaseEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(SpartaneBaseEntity x, SpartaneBaseEntity y)
        {
            return !(x == y);
        }
    }
}
