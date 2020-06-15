using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Examenes_Laboratorio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Examenes_Laboratorio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Examenes_LaboratorioService : IDetalle_Examenes_LaboratorioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> _Detalle_Examenes_LaboratorioRepository;
        #endregion

        #region Ctor
        public Detalle_Examenes_LaboratorioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> Detalle_Examenes_LaboratorioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Examenes_LaboratorioRepository = Detalle_Examenes_LaboratorioRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_LaboratorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Examenes_LaboratorioPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Examenes_LaboratorioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Examenes_LaboratorioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio entity, Spartane.Core.Domain.User.GlobalData Detalle_Examenes_LaboratorioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio entity, Spartane.Core.Domain.User.GlobalData Detalle_Examenes_LaboratorioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

