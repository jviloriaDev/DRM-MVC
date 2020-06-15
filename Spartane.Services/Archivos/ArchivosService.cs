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

namespace Spartane.Services.Archivos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ArchivosService: IArchivosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        //private List<Spartane.Core.Domain.Archivos.Archivos> _Archivos;
        private readonly IRepository<Spartane.Core.Domain.Archivos.Archivos> _ArchivosRepository;
        #endregion

        #region Ctor
        public ArchivosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Archivos.Archivos> ArchivosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ArchivosRepository = ArchivosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._ArchivosRepository.Table.Count();
        }

        public IList<Spartane.Core.Domain.Archivos.Archivos> SelAll(bool ConRelaciones)
        {
            return this._ArchivosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Archivos.Archivos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ArchivosRepository.Table.Where(Where).ToList();
        }

        public IList<Spartane.Core.Domain.Archivos.Archivos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ArchivosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Archivos.Archivos GetByKey(int? Key, bool ConRelaciones)
        {
            return this._ArchivosRepository.Table
                .Where(v => v.Clave == Key.Value)
                .SingleOrDefault();
        }

        public bool Delete(int? Key, Spartane.Core.Domain.User.GlobalData DepartamentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            try
            {
                var entity = _ArchivosRepository.GetById(Key);
                _ArchivosRepository.Delete(entity);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Spartane.Core.Domain.Archivos.Archivos entity, Spartane.Core.Domain.User.GlobalData DepartamentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _ArchivosRepository.Insert(entity);
                rta = entity.Clave;

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Spartane.Core.Domain.Archivos.Archivos entity, Spartane.Core.Domain.User.GlobalData DepartamentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _ArchivosRepository.Update(entity);
                rta = entity.Clave;

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
        #endregion
    }
}
