using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estado_de_Animo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estado_de_Animo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estado_de_AnimoService : IEstado_de_AnimoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> _Estado_de_AnimoRepository;
        #endregion

        #region Ctor
        public Estado_de_AnimoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> Estado_de_AnimoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estado_de_AnimoRepository = Estado_de_AnimoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> SelAll(bool ConRelaciones)
        {
            return this._Estado_de_AnimoRepository.Table.ToList();
        }

        public IList<Core.Domain.Estado_de_Animo.Estado_de_Animo> SelAllComplete(bool ConRelaciones)
        {
            return this._Estado_de_AnimoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estado_de_AnimoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estado_de_AnimoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estado_de_AnimoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estado_de_Animo.Estado_de_AnimoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estado_de_AnimoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estado_de_AnimoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estado_de_AnimoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo entity, Spartane.Core.Domain.User.GlobalData Estado_de_AnimoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estado_de_Animo.Estado_de_Animo entity, Spartane.Core.Domain.User.GlobalData Estado_de_AnimoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

