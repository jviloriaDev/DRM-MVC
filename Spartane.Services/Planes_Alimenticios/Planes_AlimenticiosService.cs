using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Planes_Alimenticios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Planes_Alimenticios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Planes_AlimenticiosService : IPlanes_AlimenticiosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> _Planes_AlimenticiosRepository;
        #endregion

        #region Ctor
        public Planes_AlimenticiosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> Planes_AlimenticiosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Planes_AlimenticiosRepository = Planes_AlimenticiosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> SelAll(bool ConRelaciones)
        {
            return this._Planes_AlimenticiosRepository.Table.ToList();
        }

        public IList<Core.Domain.Planes_Alimenticios.Planes_Alimenticios> SelAllComplete(bool ConRelaciones)
        {
            return this._Planes_AlimenticiosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_AlimenticiosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Planes_AlimenticiosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_AlimenticiosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Planes_Alimenticios.Planes_AlimenticiosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Planes_AlimenticiosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Planes_AlimenticiosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Planes_AlimenticiosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios entity, Spartane.Core.Domain.User.GlobalData Planes_AlimenticiosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Planes_Alimenticios.Planes_Alimenticios entity, Spartane.Core.Domain.User.GlobalData Planes_AlimenticiosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

