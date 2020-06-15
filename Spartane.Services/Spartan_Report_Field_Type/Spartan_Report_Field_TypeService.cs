using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Report_Field_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Field_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_Field_TypeService : ISpartan_Report_Field_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type> _Spartan_Report_Field_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Report_Field_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type> Spartan_Report_Field_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_Field_TypeRepository = Spartan_Report_Field_TypeRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Report_Field_TypeRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Report_Field_TypeRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Field_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_Field_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Field_TypeRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Report_Field_TypePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_Field_TypeRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_Field_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Field_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Field_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

