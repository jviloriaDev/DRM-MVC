using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Preferencias_Grasas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Preferencias_Grasas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Preferencias_GrasasService : IPreferencias_GrasasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> _Preferencias_GrasasRepository;
        #endregion

        #region Ctor
        public Preferencias_GrasasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> Preferencias_GrasasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Preferencias_GrasasRepository = Preferencias_GrasasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> SelAll(bool ConRelaciones)
        {
            return this._Preferencias_GrasasRepository.Table.ToList();
        }

        public IList<Core.Domain.Preferencias_Grasas.Preferencias_Grasas> SelAllComplete(bool ConRelaciones)
        {
            return this._Preferencias_GrasasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_GrasasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Preferencias_GrasasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_GrasasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Preferencias_Grasas.Preferencias_GrasasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Preferencias_GrasasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Preferencias_GrasasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Preferencias_GrasasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas entity, Spartane.Core.Domain.User.GlobalData Preferencias_GrasasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Preferencias_Grasas.Preferencias_Grasas entity, Spartane.Core.Domain.User.GlobalData Preferencias_GrasasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

