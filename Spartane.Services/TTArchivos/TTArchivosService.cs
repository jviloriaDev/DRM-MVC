using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Archivos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;
using Spartane.Services.TTArchivos;

namespace Spartane.Services.TTArchivos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class TTArchivosService: ITTArchivosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.TTArchivos.TTArchivos> _TTArchivosRepository;
        #endregion

        #region Ctor
        public TTArchivosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.TTArchivos.TTArchivos> TTArchivosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._TTArchivosRepository = TTArchivosRepository;
        }
        #endregion

        #region CRUD Operations
       

      
        public Spartane.Core.Domain.TTArchivos.TTArchivos Get(int? Key)
        {
            return this._TTArchivosRepository.Table.Where(f=>f.Folio == Key.Value).FirstOrDefault(); 
        }

        #endregion
    }
}
