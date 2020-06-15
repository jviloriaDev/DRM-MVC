using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Profesiones;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Profesiones
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ProfesionesService : IProfesionesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Profesiones.Profesiones> _ProfesionesRepository;
        #endregion

        #region Ctor
        public ProfesionesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Profesiones.Profesiones> ProfesionesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ProfesionesRepository = ProfesionesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Profesiones.Profesiones> SelAll(bool ConRelaciones)
        {
            return this._ProfesionesRepository.Table.ToList();
        }

        public IList<Core.Domain.Profesiones.Profesiones> SelAllComplete(bool ConRelaciones)
        {
            return this._ProfesionesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Profesiones.Profesiones> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ProfesionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Profesiones.Profesiones> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ProfesionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Profesiones.Profesiones> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ProfesionesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Profesiones.ProfesionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            ProfesionesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Profesiones.Profesiones> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ProfesionesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Profesiones.Profesiones GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Profesiones.Profesiones result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData ProfesionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Profesiones.Profesiones entity, Spartane.Core.Domain.User.GlobalData ProfesionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Profesiones.Profesiones entity, Spartane.Core.Domain.User.GlobalData ProfesionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

