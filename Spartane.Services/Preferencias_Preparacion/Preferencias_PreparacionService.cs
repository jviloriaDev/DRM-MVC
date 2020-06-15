using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Preferencias_Preparacion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Preferencias_Preparacion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Preferencias_PreparacionService : IPreferencias_PreparacionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> _Preferencias_PreparacionRepository;
        #endregion

        #region Ctor
        public Preferencias_PreparacionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> Preferencias_PreparacionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Preferencias_PreparacionRepository = Preferencias_PreparacionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(bool ConRelaciones)
        {
            return this._Preferencias_PreparacionRepository.Table.ToList();
        }

        public IList<Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> SelAllComplete(bool ConRelaciones)
        {
            return this._Preferencias_PreparacionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_PreparacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Preferencias_PreparacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_PreparacionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_PreparacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Preferencias_PreparacionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Preferencias_PreparacionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Preferencias_PreparacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion entity, Spartane.Core.Domain.User.GlobalData Preferencias_PreparacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Preferencias_Preparacion.Preferencias_Preparacion entity, Spartane.Core.Domain.User.GlobalData Preferencias_PreparacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

