using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Departamento
{
    /// <summary>
    /// User global data in application
    /// </summary>
    public partial class GlobalData: IDisposable
    {
        /// <summary>
        /// Gets or sets identificator
        /// </summary>
        public long Folio{ get; set; }
        /// <summary>
        /// Gets or sets user identificator
        /// </summary>
        public Nullable<int> UserID { get; set; }
        /// <summary>
        /// Gets or sets User name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets Computer name
        /// </summary>
        public string ComputerName { get; set; }
        /// <summary>
        /// Gets or sets Windows S.O version
        /// </summary>
        public string WindowsVersion { get; set; }
        /// <summary>
        /// Gets or sets Servidor name
        /// </summary>
        public String ServidorName { get; set; }
        /// <summary>
        /// Gets or sets Servidor Computer name
        /// </summary>
        public string ServidorNameComputer { get; set; }
        /// <summary>
        /// Gest or sets Database name
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// Gets Path skin
        /// </summary>
        public virtual string PathSkin { get; set; }
        /// <summary>
        /// Gets or sets Version data
        /// </summary>
        //public TTVersion.VersionData SystemVersion
        //{
        //    get { return systemVersion; }
        //    set { systemVersion = value; }
        //}
        /// <summary>
        /// Gest or set Temp files directory?¿
        /// </summary>
        public string AppToTempFiles { get; set; }
        /// <summary>
        /// Gets or sets user language
        /// </summary>
        //public GlobalDataLanguages Language { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
