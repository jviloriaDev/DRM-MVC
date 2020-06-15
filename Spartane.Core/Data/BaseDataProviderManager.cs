using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spartane.Core.Data
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public abstract class BaseDataProviderManager
    {
        protected BaseDataProviderManager(DataSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");
            this.Settings = settings;
        }
        protected DataSettings Settings { get; private set; }
        public abstract IDataProvider LoadDataProvider();
    }
}
