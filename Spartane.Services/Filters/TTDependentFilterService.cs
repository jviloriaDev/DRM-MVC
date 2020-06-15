using Spartane.Core.Data;
using Spartane.Core.Domain.Columns;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Filters;
using Spartane.Core.Domain.Search;
using Spartane.Core.Domain.User;
using Spartane.Core.Exceptions;
using Spartane.Data.EF;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Spartane.Services.Filters
{
    public partial class TTDependentFilterService : ITTDependentFilterService
    {
        #region Fields
        public int iProcess = 6594;

        private readonly IRepository<TTDependentFilter> _ttFilterRepository;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly ITTSearchAdvancedDataService _tTSearchAdvancedDataService;
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="principalPageRepository">Affiliate repository</param>
        /// <param name="eventPublisher">Event published</param>
        public TTDependentFilterService(IRepository<TTDependentFilter> ttFilterRepository, IDataProvider dataProvider, IDbContext dbContext, ITTSearchAdvancedDataService tTSearchAdvancedDataService)
        {
            this._ttFilterRepository = ttFilterRepository;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._tTSearchAdvancedDataService = tTSearchAdvancedDataService;
        }

        #endregion

        #region Methods
        public int SelCount()
        {
            return this._ttFilterRepository.Table.Count();
        }

        public IList<TTDependentFilter> SelAll(bool ConRelaciones)
        {
            return this._ttFilterRepository.Table.ToList();
        }

        public IList<TTDependentFilter> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ttFilterRepository.Table.ToList();
        }

        public int CurrentPosicion(int? Key)
        {
            throw new NotImplementedException();
        }

        public TTDependentFilter GetByKey(int? Key, bool ConRelaciones)
        {
            return this._ttFilterRepository.GetById(Key);
        }

        public bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            try
            {
                var entity = _ttFilterRepository.GetById(Key);
                _ttFilterRepository.Delete(entity);
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

        public int Insert(TTDependentFilter entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _ttFilterRepository.Insert(entity);
                rta = entity.IdFiltro;
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

        public int Update(TTDependentFilter entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _ttFilterRepository.Update(entity);
                rta = entity.IdFiltro;
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

        public bool ValidaExistencia(int? Key)
        {
            var existencia = _ttFilterRepository.GetById(Key);
            return existencia != null;
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms. No existe el sp que ejecuta
        public void FillDataIdFiltro(object ctr)
        {
            throw new NotImplementedException();
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms. No existe el sp que ejecuta
        public void FillDataDT(object ctr)
        {
            throw new NotImplementedException();
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms. No existe el sp que ejecuta
        public void FillDataDT(object ctr, int Key)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
