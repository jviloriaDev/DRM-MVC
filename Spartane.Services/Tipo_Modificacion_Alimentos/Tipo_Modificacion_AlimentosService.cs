using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Tipo_Modificacion_Alimentos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_Modificacion_Alimentos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_Modificacion_AlimentosService : ITipo_Modificacion_AlimentosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> _Tipo_Modificacion_AlimentosRepository;
        #endregion

        #region Ctor
        public Tipo_Modificacion_AlimentosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> Tipo_Modificacion_AlimentosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_Modificacion_AlimentosRepository = Tipo_Modificacion_AlimentosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(bool ConRelaciones)
        {
            return this._Tipo_Modificacion_AlimentosRepository.Table.ToList();
        }

        public IList<Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAllComplete(bool ConRelaciones)
        {
            return this._Tipo_Modificacion_AlimentosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_Modificacion_AlimentosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_Modificacion_AlimentosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_Modificacion_AlimentosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_AlimentosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Tipo_Modificacion_AlimentosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_Modificacion_AlimentosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipo_Modificacion_AlimentosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos entity, Spartane.Core.Domain.User.GlobalData Tipo_Modificacion_AlimentosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos entity, Spartane.Core.Domain.User.GlobalData Tipo_Modificacion_AlimentosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

