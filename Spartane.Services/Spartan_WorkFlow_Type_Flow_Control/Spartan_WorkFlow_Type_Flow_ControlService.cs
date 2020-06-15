using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Type_Flow_Control
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Type_Flow_ControlService : ISpartan_WorkFlow_Type_Flow_ControlService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> _Spartan_WorkFlow_Type_Flow_ControlRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Type_Flow_ControlService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> Spartan_WorkFlow_Type_Flow_ControlRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Type_Flow_ControlRepository = Spartan_WorkFlow_Type_Flow_ControlRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_WorkFlow_Type_Flow_ControlPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Type_Flow_ControlRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Flow_ControlInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Flow_ControlInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Flow_ControlInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

