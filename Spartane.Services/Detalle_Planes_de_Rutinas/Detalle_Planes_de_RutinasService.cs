using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Planes_de_Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Planes_de_Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Planes_de_RutinasService : IDetalle_Planes_de_RutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> _Detalle_Planes_de_RutinasRepository;
        #endregion

        #region Ctor
        public Detalle_Planes_de_RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> Detalle_Planes_de_RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Planes_de_RutinasRepository = Detalle_Planes_de_RutinasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Planes_de_RutinasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Planes_de_RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas entity, Spartane.Core.Domain.User.GlobalData Detalle_Planes_de_RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas entity, Spartane.Core.Domain.User.GlobalData Detalle_Planes_de_RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

