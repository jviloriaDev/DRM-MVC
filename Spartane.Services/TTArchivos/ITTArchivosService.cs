using System;
using Spartane.Core.Domain.Departamento;
using System.Collections.Generic;
using Spartane.Core.Domain.Data; 

namespace Spartane.Services.TTArchivos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITTArchivosService
    {
        Spartane.Core.Domain.TTArchivos.TTArchivos Get(int? Key);
    }
}

