using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Metadata;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Metadata
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_MetadataService : ISpartan_MetadataService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> _Spartan_MetadataRepository;
        #endregion

        #region Ctor
        public Spartan_MetadataService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> Spartan_MetadataRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_MetadataRepository = Spartan_MetadataRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> SelAll(bool ConRelaciones)
        {
            return this._Spartan_MetadataRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Metadata.Spartan_Metadata> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_MetadataRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_MetadataRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_MetadataRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_MetadataRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Metadata.Spartan_MetadataPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_MetadataPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_MetadataRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_MetadataInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata entity, Spartane.Core.Domain.User.GlobalData Spartan_MetadataInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata entity, Spartane.Core.Domain.User.GlobalData Spartan_MetadataInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

