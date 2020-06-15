using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Interpretacion_de_porcentaje_de_grasa_corporal
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Interpretacion_de_porcentaje_de_grasa_corporalService : IInterpretacion_de_porcentaje_de_grasa_corporalService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> _Interpretacion_de_porcentaje_de_grasa_corporalRepository;
        #endregion

        #region Ctor
        public Interpretacion_de_porcentaje_de_grasa_corporalService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> Interpretacion_de_porcentaje_de_grasa_corporalRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Interpretacion_de_porcentaje_de_grasa_corporalRepository = Interpretacion_de_porcentaje_de_grasa_corporalRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(bool ConRelaciones)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.ToList();
        }

        public IList<Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAllComplete(bool ConRelaciones)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Interpretacion_de_porcentaje_de_grasa_corporalPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Interpretacion_de_porcentaje_de_grasa_corporalRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_de_porcentaje_de_grasa_corporalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity, Spartane.Core.Domain.User.GlobalData Interpretacion_de_porcentaje_de_grasa_corporalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Interpretacion_de_porcentaje_de_grasa_corporal.Interpretacion_de_porcentaje_de_grasa_corporal entity, Spartane.Core.Domain.User.GlobalData Interpretacion_de_porcentaje_de_grasa_corporalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

