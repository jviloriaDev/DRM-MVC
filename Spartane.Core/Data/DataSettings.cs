using System;
using System.Collections.Generic;

namespace Spartane.Core.Data
{
    /// <summary>
    /// Data settings for the DAL
    /// </summary>
    public partial class DataSettings
    {
        public string DataProvider { get; set; }
        public string DataConnectionString { get; set; }
        public IDictionary<string, string> RawDataSettings { get; private set; }

        public bool IsValid()
        {
            return !String.IsNullOrEmpty(this.DataProvider) && !String.IsNullOrEmpty(this.DataConnectionString);
        }   
    }
}
