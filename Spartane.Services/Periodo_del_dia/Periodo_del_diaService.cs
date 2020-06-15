using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Periodo_del_dia;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Periodo_del_dia
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Periodo_del_diaService : IPeriodo_del_diaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> _Periodo_del_diaRepository;
        #endregion

        #region Ctor
        public Periodo_del_diaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> Periodo_del_diaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Periodo_del_diaRepository = Periodo_del_diaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> SelAll(bool ConRelaciones)
        {
            return this._Periodo_del_diaRepository.Table.ToList();
        }

        public IList<Core.Domain.Periodo_del_dia.Periodo_del_dia> SelAllComplete(bool ConRelaciones)
        {
            return this._Periodo_del_diaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Periodo_del_diaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Periodo_del_diaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Periodo_del_diaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Periodo_del_dia.Periodo_del_diaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Periodo_del_diaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Periodo_del_diaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Periodo_del_diaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia entity, Spartane.Core.Domain.User.GlobalData Periodo_del_diaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia entity, Spartane.Core.Domain.User.GlobalData Periodo_del_diaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

