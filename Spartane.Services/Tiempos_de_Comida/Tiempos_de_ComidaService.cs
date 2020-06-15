using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Tiempos_de_Comida;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tiempos_de_Comida
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tiempos_de_ComidaService : ITiempos_de_ComidaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> _Tiempos_de_ComidaRepository;
        #endregion

        #region Ctor
        public Tiempos_de_ComidaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> Tiempos_de_ComidaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tiempos_de_ComidaRepository = Tiempos_de_ComidaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(bool ConRelaciones)
        {
            return this._Tiempos_de_ComidaRepository.Table.ToList();
        }

        public IList<Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> SelAllComplete(bool ConRelaciones)
        {
            return this._Tiempos_de_ComidaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tiempos_de_ComidaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tiempos_de_ComidaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tiempos_de_ComidaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_ComidaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Tiempos_de_ComidaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tiempos_de_ComidaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Tiempos_de_ComidaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida entity, Spartane.Core.Domain.User.GlobalData Tiempos_de_ComidaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Tiempos_de_Comida.Tiempos_de_Comida entity, Spartane.Core.Domain.User.GlobalData Tiempos_de_ComidaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

