using System;
using System.Drawing;

namespace Spartane.Core.Domain.Binnacle
{
    /// <summary>
    /// User modules
    /// </summary>
    public partial class ModulesData: BaseEntity
    {
        /// <summary>
        /// Gest or Sets id module
        /// </summary>
        public int IdModulo { get; set; }
        /// <summary>
        /// Gets or sets module description
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Gets or sets module identificaction
        /// </summary>
        public String Module { get; set; }
        /// <summary>
        /// Gets or sets module name
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Gets or Sets module image
        /// </summary>
        //public Image Picture { get; set; }
        /// <summary>
        /// Gets or Set process identitfication
        /// </summary>
        public int ProcessId { get; set; }
    }
}
