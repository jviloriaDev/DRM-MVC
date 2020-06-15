using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Identificaciones_Oficiales;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Identificaciones_Oficiales
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Identificaciones_OficialesService : IIdentificaciones_OficialesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> _Identificaciones_OficialesRepository;
        #endregion

        #region Ctor
        public Identificaciones_OficialesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> Identificaciones_OficialesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Identificaciones_OficialesRepository = Identificaciones_OficialesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(bool ConRelaciones)
        {
            return this._Identificaciones_OficialesRepository.Table.ToList();
        }

        public IList<Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAllComplete(bool ConRelaciones)
        {
            return this._Identificaciones_OficialesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Identificaciones_OficialesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Identificaciones_OficialesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Identificaciones_OficialesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_OficialesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Identificaciones_OficialesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Identificaciones_OficialesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Identificaciones_OficialesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales entity, Spartane.Core.Domain.User.GlobalData Identificaciones_OficialesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Identificaciones_Oficiales.Identificaciones_Oficiales entity, Spartane.Core.Domain.User.GlobalData Identificaciones_OficialesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

