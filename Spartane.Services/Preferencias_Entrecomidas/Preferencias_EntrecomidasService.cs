using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Preferencias_Entrecomidas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Preferencias_Entrecomidas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Preferencias_EntrecomidasService : IPreferencias_EntrecomidasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> _Preferencias_EntrecomidasRepository;
        #endregion

        #region Ctor
        public Preferencias_EntrecomidasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> Preferencias_EntrecomidasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Preferencias_EntrecomidasRepository = Preferencias_EntrecomidasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(bool ConRelaciones)
        {
            return this._Preferencias_EntrecomidasRepository.Table.ToList();
        }

        public IList<Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAllComplete(bool ConRelaciones)
        {
            return this._Preferencias_EntrecomidasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_EntrecomidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Preferencias_EntrecomidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_EntrecomidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_EntrecomidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Preferencias_EntrecomidasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Preferencias_EntrecomidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Preferencias_EntrecomidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas entity, Spartane.Core.Domain.User.GlobalData Preferencias_EntrecomidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Preferencias_Entrecomidas.Preferencias_Entrecomidas entity, Spartane.Core.Domain.User.GlobalData Preferencias_EntrecomidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

