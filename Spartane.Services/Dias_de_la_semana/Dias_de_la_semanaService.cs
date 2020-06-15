using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Dias_de_la_semana;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Dias_de_la_semana
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Dias_de_la_semanaService : IDias_de_la_semanaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> _Dias_de_la_semanaRepository;
        #endregion

        #region Ctor
        public Dias_de_la_semanaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> Dias_de_la_semanaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Dias_de_la_semanaRepository = Dias_de_la_semanaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> SelAll(bool ConRelaciones)
        {
            return this._Dias_de_la_semanaRepository.Table.ToList();
        }

        public IList<Core.Domain.Dias_de_la_semana.Dias_de_la_semana> SelAllComplete(bool ConRelaciones)
        {
            return this._Dias_de_la_semanaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dias_de_la_semanaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Dias_de_la_semanaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dias_de_la_semanaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semanaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Dias_de_la_semanaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Dias_de_la_semanaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Dias_de_la_semanaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana entity, Spartane.Core.Domain.User.GlobalData Dias_de_la_semanaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana entity, Spartane.Core.Domain.User.GlobalData Dias_de_la_semanaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

